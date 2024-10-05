using LD56;
using UnityEngine;
using UnityEngine.Events;

namespace LD56 {
	public class ShieldController : MonoBehaviour, IActionPerformer {
		[SerializeField] protected PerformAction propelAction;
		[SerializeField] protected ShieldTrigger trigger;
		[SerializeField] protected float force = 1000;
		[SerializeField] protected float cooldown = .4f;
		[SerializeField] protected float propelablesKinematicForbiddenDelay = 1;

		private float NextUsageMinTime { get; set; }

		public UnityEvent<PerformAction> OnActionTriggered { get; } = new UnityEvent<PerformAction>();

		public bool TryPerformAction() {
			if (Time.time < NextUsageMinTime) return false;
			foreach (var body in trigger.GetPropelablesInTrigger()) {
				body.Propel(transform.forward * force, Time.time + propelablesKinematicForbiddenDelay);
			}
			OnActionTriggered.Invoke(propelAction);
			NextUsageMinTime = Time.time + cooldown;
			return true;
		}
	}
}