using UnityEngine.Events;

namespace LD56 {
	public interface IActionPerformer {
		public bool TryPerformAction();

		public UnityEvent<PerformAction> OnActionTriggered { get; }
	}
}