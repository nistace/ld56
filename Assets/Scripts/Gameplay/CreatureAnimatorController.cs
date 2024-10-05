using LD56;
using UnityEngine;

namespace LD56 {
	public class CreatureAnimatorController : MonoBehaviour {
		[SerializeField] protected Animator animator;
		private static readonly int onGroundAnimParam = Animator.StringToHash("OnGround");
		private CreatureController CreatureController { get; set; }
		private static readonly int xVelocityAnimParam = Animator.StringToHash("XVelocity");
		private static readonly int yVelocityAnimParam = Animator.StringToHash("YVelocity");

		private void Start() {
			CreatureController = GetComponentInParent<CreatureController>();
			CreatureController.OnActionPerformed.AddListener(HandleActionPerformed);
		}

		private void OnDestroy() {
			if (CreatureController) CreatureController.OnActionPerformed.RemoveListener(HandleActionPerformed);
		}

		private void HandleActionPerformed(PerformAction action) => animator.SetTrigger(action.AnimatorParameterName);

		private void Update() {
			animator.SetBool(onGroundAnimParam, CreatureController.IsOnGround);
			animator.SetFloat(xVelocityAnimParam, Mathf.Abs(CreatureController.Velocity.x));
			animator.SetFloat(yVelocityAnimParam, CreatureController.Velocity.y);
		}

		public void SetArmMovementAllowed() => CreatureController.ArmMovementAllowed = true;
		public void SetArmMovementDisallowed() => CreatureController.ArmMovementAllowed = false;
	}
}