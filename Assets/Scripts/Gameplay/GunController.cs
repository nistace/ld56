using System;
using NiUtils.Extensions;
using UnityEngine;

namespace LD56 {
	public class GunController : MonoBehaviour {
		[SerializeField] protected Transform redDotOrigin;
		[SerializeField] protected Transform redDot;
		[SerializeField] protected float redDotMaxDistance = 50;
		[SerializeField] protected LayerMask redDotCastMask;

		private static Collider[] CastNonAllocArray { get; } = Array.Empty<Collider>();

		private void LateUpdate() {
			if (!redDotOrigin || !redDot) return;

			var redDotActive = Physics.OverlapSphereNonAlloc(redDotOrigin.position, .01f, CastNonAllocArray, redDotCastMask) == 0;
			redDot.gameObject.SetActive(redDotActive);

			if (redDotActive) {
				var hitPosition = redDotOrigin.position + redDotOrigin.forward * redDotMaxDistance;
				if (Physics.Raycast(new Ray(redDotOrigin.position, redDotOrigin.forward), out var hitInfo, redDotMaxDistance, redDotCastMask)) {
					hitPosition = hitInfo.point;
				}

				var distance = (hitPosition - redDotOrigin.position).magnitude;
				redDot.localScale = redDot.localScale.With(z: distance);
				redDot.localPosition = new Vector3(0, 0, distance / 2);
			}
		}
	}
}