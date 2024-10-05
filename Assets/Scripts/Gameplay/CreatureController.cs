using System;
using NiUtils.Extensions;
using UnityEngine;

namespace LD56 {
	public class CreatureController : MonoBehaviour {
		[SerializeField] protected Transform selfTransform;
		[SerializeField] protected float selfRotationSpeed = 8f;
		[SerializeField] protected new Rigidbody rigidbody;
		[SerializeField] protected GroundChecker groundChecker;
		[SerializeField] protected Transform armAimTarget;
		[SerializeField] protected float armAimMovementSlerpFactor = 8f;
		[SerializeField] protected float minAimTargetDistanceFromArm = 3;
		[SerializeField] protected float movementSpeed = .3f;
		[SerializeField] protected float jumpForce = 5;
		[SerializeField] protected float inputImpactInAir = .5f;

		private Vector3 MovementInput { get; set; }
		private Vector3 Movement { get; set; }
		private Vector3 AimTarget { get; set; }
		private float CurrentSelfRotationY { get; set; }

		public bool IsActiveCreature { get; set; }

		private void Start() {
			CurrentSelfRotationY = Vector3.SignedAngle(selfTransform.forward, Vector3.right, Vector3.up);
		}

		public void Move(Vector2 input) {
			if (!IsActiveCreature) return;
			MovementInput = input;
		}

		private void FixedUpdate() {
			rigidbody.isKinematic = groundChecker.IsOnGround && !IsActiveCreature;

			UpdateMovement();
			UpdateAim();
		}

		private void UpdateAim() {
			if (!IsActiveCreature) return;

			AimTarget = AimCastController.HitPoint;
			var armPositionOnPlane = armAimTarget.position.With(z: 0);
			var planeArmToAimTarget = AimTarget - armPositionOnPlane;
			if (planeArmToAimTarget.sqrMagnitude < minAimTargetDistanceFromArm * minAimTargetDistanceFromArm) {
				AimTarget = armPositionOnPlane + planeArmToAimTarget.normalized * minAimTargetDistanceFromArm;
			}

			var armToAimTarget = AimTarget - armAimTarget.position;

			var upVector = Vector3.Cross(Vector3.forward, armToAimTarget);
			if (Vector3.Angle(upVector, Vector3.up) > 90) upVector = -upVector;

			var targetRotation = Quaternion.LookRotation(armToAimTarget, upVector);
			armAimTarget.rotation = Quaternion.Slerp(armAimTarget.rotation, targetRotation, armAimMovementSlerpFactor * Time.deltaTime);

			var targetSelfRotationY = AimTarget.x < selfTransform.position.x ? 270 : 90;
			CurrentSelfRotationY = Mathf.MoveTowards(CurrentSelfRotationY, targetSelfRotationY, selfRotationSpeed * Time.deltaTime);
			selfTransform.rotation = Quaternion.Euler(0, CurrentSelfRotationY, 0);
		}

		private void UpdateMovement() {
			if (groundChecker.IsOnGround) {
				Movement = IsActiveCreature ? MovementInput : Vector3.zero;
			}
			else {
				Movement = Vector3.Lerp(Movement, IsActiveCreature ? MovementInput : Vector3.zero, inputImpactInAir * Time.deltaTime);
			}

			rigidbody.MovePosition(transform.position + Movement * (movementSpeed * Time.fixedDeltaTime));
		}

		public void Jump() {
			if (!IsActiveCreature) return;
			if (!groundChecker.IsOnGround) return;

			rigidbody.AddForce(Vector3.up * jumpForce);
		}

		private void OnDrawGizmos() {
			if (!IsActiveCreature) return;
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(AimTarget, .5f);
		}
	}
}