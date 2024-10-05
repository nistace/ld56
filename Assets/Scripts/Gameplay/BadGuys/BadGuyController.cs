using NiUtils.Extensions;
using UnityEngine;

namespace LD56 {
	public class BadGuyController : MonoBehaviour {
		[SerializeField] private GunController gun;
		[SerializeField] private new Rigidbody rigidbody;
		[SerializeField] private Transform aimTransform;
		[SerializeField] private float aimMovementSlerpFactor = 3;
		[SerializeField] private Transform pathParent;
		[SerializeField] private float getTargetRefreshTime = .4f;
		[SerializeField] private float smoothMovement = 1;
		[SerializeField] private float maxSpeed = 3;
		[SerializeField] private float distanceToPathNode = .5f;

		private Vector3 smoothVelocity;

		private CreatureController Target { get; set; }
		private int TargetPathNodeIndex { get; set; }
		private Transform TargetPathNode => pathParent.GetChild(TargetPathNodeIndex);
		private float NextRefreshTargetTime { get; set; }

		private void Start() {
			if (pathParent.childCount > 0) {
				transform.position = pathParent.GetChild(0).position;
				TargetPathNodeIndex = 0;
				if (pathParent.childCount > 1) {
					aimTransform.forward = pathParent.GetChild(1).position - transform.position;
					TargetPathNodeIndex = 1;
				}
			}
		}

		private void FixedUpdate() {
			RefreshTarget();
			RefreshMovement();
			RefreshAim();
			RefreshShoot();
		}

		private void RefreshAim() {
			var targetPosition = Target ? Target.BodyMid.position : pathParent.childCount > 1 ? TargetPathNode.position : transform.position + transform.forward;

			var selfToAimTarget = targetPosition - aimTransform.position;
			var upVector = Vector3.Cross(Vector3.forward, selfToAimTarget);

			var targetArmRotation = Quaternion.LookRotation(selfToAimTarget, upVector);
			aimTransform.rotation = Quaternion.Slerp(aimTransform.rotation, targetArmRotation, aimMovementSlerpFactor * Time.deltaTime);
		}

		private void RefreshShoot() {
			if (!Target) return;
			if (Vector3.Angle(aimTransform.forward, Target.BodyMid.position - aimTransform.position) > 1) return;

			gun.TryPerformAction();
		}

		private void RefreshMovement() {
			var targetPosition = Target ? transform.position : TargetPathNode.position;
			Vector3.SmoothDamp(transform.position, targetPosition, ref smoothVelocity, smoothMovement, maxSpeed);
			rigidbody.velocity = smoothVelocity;

			if ((transform.position - TargetPathNode.position).sqrMagnitude < distanceToPathNode * distanceToPathNode) {
				TargetPathNodeIndex = (TargetPathNodeIndex + 1).PosMod(pathParent.childCount);
			}
		}

		private void RefreshTarget() {
			if (Time.time < NextRefreshTargetTime) return;
			if (CheckTarget(Target, out _)) return;

			Target = default;
			var bestSqrDistance = float.MaxValue;
			foreach (var creature in GameData.Data.PlayerCreatures) {
				if (CheckTarget(creature, out var sqrDistance) && sqrDistance < bestSqrDistance) {
					Target = creature;
					bestSqrDistance = sqrDistance;
				}
			}

			NextRefreshTargetTime = Time.time + getTargetRefreshTime;
		}

		private bool CheckTarget(CreatureController target, out float sqrDistance) {
			sqrDistance = default;
			if (!target) return false;
			if (!((target.BodyMid.position - gun.ShotOriginPosition).sqrMagnitude < gun.SqrRange)) return false;
			if (!Physics.Raycast(new Ray(gun.ShotOriginPosition, target.BodyMid.position - gun.ShotOriginPosition), out var hitInfo, gun.Range, gun.HitMask)
				|| hitInfo.collider.GetComponentInParent<CreatureController>() != target) return false;
			sqrDistance = (hitInfo.point - transform.position).sqrMagnitude;
			return true;
		}

		private void OnDrawGizmos() {
			if (!pathParent) return;
			if (pathParent.childCount == 0) return;

			Gizmos.color = Color.blue;
			for (var i = 0; i < pathParent.childCount; ++i) {
				Gizmos.DrawSphere(pathParent.GetChild(i).position, .3f);
				Gizmos.DrawLine(pathParent.GetChild(i).position, pathParent.GetChild((i + 1) % pathParent.childCount).position);
				Gizmos.color = (Gizmos.color * .9f).With(a: 1);
			}
		}
	}
}