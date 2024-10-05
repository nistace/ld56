using UnityEngine;

namespace LD56 {
	[CreateAssetMenu(menuName = "Config/" + nameof(PerformAction))]
	public class PerformAction : ScriptableObject {
		[SerializeField] protected string animatorParameterName;

		public string AnimatorParameterName => animatorParameterName;
	}
}