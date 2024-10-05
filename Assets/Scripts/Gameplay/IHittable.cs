using UnityEngine;

namespace LD56 {
	public interface IHittable {
		Transform transform { get; }
		public void Hit(Vector3 force, float kinematicForbiddenUntilTime);
	}
}