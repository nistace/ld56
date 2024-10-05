using UnityEngine;

namespace LD56 {
	public interface IPropelable {
		public void Propel(Vector3 force, float kinematicForbiddenUntilTime);
	}
}