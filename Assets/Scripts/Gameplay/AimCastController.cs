using LD56;
using NiUtils.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LD56 {
	public class AimCastController : MonoBehaviour {
		[SerializeField] protected new Camera camera;
		[SerializeField] protected float maxDistance = 50;

		public static Vector3 HitPoint { get; private set; }

		private void Update() {
			transform.position = transform.position.With(x: camera.transform.position.x);
			var cursorPosition = Mouse.current.position.value;

			if (Physics.Raycast(camera.ScreenPointToRay(cursorPosition), out var hitInfo, maxDistance, LayerMask.GetMask("AimCast"))) {
				HitPoint = hitInfo.point;
			}
		}

		private void OnDrawGizmos() {
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(HitPoint, .6f);
		}
	}
}