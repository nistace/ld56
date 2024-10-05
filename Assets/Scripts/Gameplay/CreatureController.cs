using NiUtils.Extensions;
using UnityEngine;
using UnityEngine.Events;
using Quaternion = UnityEngine.Quaternion;

namespace LD56 {
	public class CreatureController : MonoBehaviour, ICameraTarget, IPropelable, IHittable {
		[SerializeField] protected HealthController healthController;
		[SerializeField] protected Transform selfTransform;
		[SerializeField] protected float selfRotationSpeed = 8f;
		[SerializeField] protected Transform bodyMid;
		[SerializeField] protected new Rigidbody rigidbody;
		[SerializeField] protected GroundChecker groundChecker;
		[SerializeField] protected Transform arm;
		[SerializeField] protected bool hasArmMovement = true;
		[SerializeField] protected float armAimMovementSlerpFactor = 8f;
		[SerializeField] protected float minAimTargetDistanceFromArm = 3;
		[SerializeField] protected float movementSpeed = .3f;
		[SerializeField] protected float jumpForce = 5;
		[SerializeField] protected float inputImpactInAir = .5f;
		[SerializeField] protected float cameraTargetPositionDistanceThreshold = 2;
		[SerializeField] protected float cameraTargetPositionDistance = 5;

		private IActionPerformer ActionPerformer { get; set; }
		private Vector3 MovementInput { get; set; }
		private Vector3 Movement { get; set; }
		private Vector3 ArmToAimTarget { get; set; } = Vector3.right;
		private float TargetSelfRotationY { get; set; } = 90;
		private float CurrentSelfRotationY { get; set; } = 90;
		private float KinematicForbiddenUntilTime { get; set; }

		public Vector3 CameraTargetPosition {
			get {
				if (Mathf.Abs(ArmToAimTarget.x) < cameraTargetPositionDistanceThreshold) return transform.position.With(y: 0);
				return transform.position.With(y: 0) + (ArmToAimTarget.x < 0 ? Vector3.left : Vector3.right) * cameraTargetPositionDistance;
			}
		}

		private bool IsActiveCreature { get; set; }
		public bool IsOnGround => groundChecker.IsOnGround;
		public Vector3 Velocity => rigidbody.velocity;
		public bool ArmMovementAllowed { get; set; } = true;
		public UnityEvent<PerformAction> OnActionPerformed { get; } = new UnityEvent<PerformAction>();
		public Transform BodyMid => bodyMid;

		private void Start() {
			ActionPerformer = arm.GetComponentInChildren<IActionPerformer>();
			ActionPerformer?.OnActionTriggered.AddListenerOnce(OnActionPerformed.Invoke);
			if (ActionPerformer is ShieldController shieldController) {
				shieldController.OnHit.AddListenerOnce(HandleShieldHit);
			}
			CurrentSelfRotationY = Vector3.SignedAngle(selfTransform.forward, Vector3.right, Vector3.up);
		}

		private void OnDestroy() {
			ActionPerformer?.OnActionTriggered.RemoveListener(OnActionPerformed.Invoke);
			if (ActionPerformer is ShieldController shieldController) {
				shieldController.OnHit.RemoveListener(HandleShieldHit);
			}
		}

		public void Move(Vector2 input) {
			if (!IsActiveCreature) return;
			MovementInput = input;
		}

		private void FixedUpdate() {
			rigidbody.isKinematic = groundChecker.IsOnGround && !IsActiveCreature && Time.time > KinematicForbiddenUntilTime;

			UpdateMovement();
			UpdateAim();
		}

		private void UpdateAim() {
			if (IsActiveCreature && InputManager.Controls.Player.Aim.IsPressed()) {
				var aimTarget = AimCastController.HitPoint;
				var armPositionOnPlane = arm.position.With(z: 0);
				var planeArmToAimTarget = aimTarget - armPositionOnPlane;

				if ((AimCastController.HitPoint - selfTransform.position).x < 0) TargetSelfRotationY = 270;
				else if ((AimCastController.HitPoint - selfTransform.position).x > 0) TargetSelfRotationY = 90;

				if (planeArmToAimTarget.sqrMagnitude < minAimTargetDistanceFromArm * minAimTargetDistanceFromArm) {
					aimTarget = armPositionOnPlane + planeArmToAimTarget.normalized * minAimTargetDistanceFromArm;
				}

				ArmToAimTarget = aimTarget - arm.position;
			}

			CurrentSelfRotationY = Mathf.MoveTowards(CurrentSelfRotationY, TargetSelfRotationY, selfRotationSpeed * Time.deltaTime);
			selfTransform.rotation = Quaternion.Euler(0, CurrentSelfRotationY, 0);
		}

		private void LateUpdate() {
			if (hasArmMovement && ArmMovementAllowed && Mathf.Approximately(CurrentSelfRotationY, TargetSelfRotationY)) {
				var upVector = Vector3.Cross(Vector3.forward, ArmToAimTarget);
				if (Vector3.Angle(upVector, Vector3.up) > 90) upVector = -upVector;

				var targetArmRotation = Quaternion.LookRotation(ArmToAimTarget, upVector);
				arm.rotation = Quaternion.Slerp(arm.rotation, targetArmRotation, armAimMovementSlerpFactor * Time.deltaTime);
			}
		}

		private void UpdateMovement() {
			if (groundChecker.IsOnGround) {
				Movement = IsActiveCreature ? MovementInput : Vector3.zero;
			}
			else {
				Movement = Vector3.Lerp(Movement, IsActiveCreature ? MovementInput : Vector3.zero, inputImpactInAir * Time.deltaTime);
			}

			if (IsActiveCreature) {
				rigidbody.velocity = rigidbody.velocity.With(x: Movement.x * movementSpeed);
			}
		}

		public void Jump() {
			if (!IsActiveCreature) return;
			if (!groundChecker.IsOnGround) return;

			rigidbody.AddForce(Vector3.up * jumpForce);
		}

		public void PerformAction() => ActionPerformer?.TryPerformAction();

		public void Propel(Vector3 force, float kinematicForbiddenUntilTime) {
			rigidbody.isKinematic = false;
			rigidbody.AddForce(force);
			KinematicForbiddenUntilTime = Mathf.Max(KinematicForbiddenUntilTime, Time.time + kinematicForbiddenUntilTime);
		}

		public void SetCreatureAsActive(bool active) {
			IsActiveCreature = active;
		}

		public void Hit(Vector3 force, float kinematicForbiddenUntilTime) {
			healthController.Damage();
			rigidbody.isKinematic = false;
			rigidbody.AddForce(force);
			KinematicForbiddenUntilTime = Mathf.Max(KinematicForbiddenUntilTime, Time.time + kinematicForbiddenUntilTime);
		}

		private void HandleShieldHit(Vector3 force, float kinematicForbiddenUntilTime) {
			if (ActionPerformer is not ShieldController shieldController) return;
			rigidbody.isKinematic = false;
			rigidbody.AddForce(force * shieldController.HitForceRatio);
			KinematicForbiddenUntilTime = Mathf.Max(KinematicForbiddenUntilTime, Time.time + kinematicForbiddenUntilTime * shieldController.HitForceRatio);
		}
	}
}