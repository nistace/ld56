using System;
using System.Collections.Generic;
using NiUtils.Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace LD56 {
	public class GunController : MonoBehaviour, IActionPerformer {
		[SerializeField] protected PerformAction shootAction;
		[SerializeField] protected int maxAmmunition = 10;
		[SerializeField] protected int ammo = 10;
		[SerializeField] protected float cooldown = .1f;
		[FormerlySerializedAs("redDotOrigin")] [SerializeField] protected Transform shotOrigin;
		[SerializeField] protected Transform redDot;
		[SerializeField] protected float range = 50;
		[FormerlySerializedAs("mask")] [FormerlySerializedAs("redDotCastMask")] [SerializeField] protected LayerMask hitMask;

		private static Collider[] CastNonAllocArray { get; } = Array.Empty<Collider>();

		public Vector3 ShotOriginPosition => shotOrigin.position;
		public LayerMask HitMask => hitMask;
		public float Range => range;
		public float SqrRange => range * range;
		private Collider AimHit { get; set; }
		private float NextShotAllowedTime { get; set; }
		private Dictionary<Collider, HealthController> HealthControllerPerTarget { get; } = new Dictionary<Collider, HealthController>();
		public HealthController GetCurrentAimHitHealthController => AimHit && HealthControllerPerTarget.TryGetValue(AimHit, out var healthController) ? healthController : default;
		public UnityEvent<PerformAction> OnActionTriggered { get; } = new UnityEvent<PerformAction>();

		private HealthController AimHitHealthController {
			get {
				if (AimHit == null) return null;
				if (!HealthControllerPerTarget.ContainsKey(AimHit)) HealthControllerPerTarget.Add(AimHit, AimHit.GetComponentInParent<HealthController>());
				return HealthControllerPerTarget[AimHit];
			}
		}

		private void Start() {
			ammo = maxAmmunition;
		}

		private void LateUpdate() {
			if (!shotOrigin || !redDot) return;

			var redDotActive = Physics.OverlapSphereNonAlloc(shotOrigin.position, .01f, CastNonAllocArray, hitMask) == 0;
			redDot.gameObject.SetActive(redDotActive);

			if (redDotActive) {
				var hitPosition = shotOrigin.position + shotOrigin.forward * range;
				if (Physics.Raycast(new Ray(shotOrigin.position, shotOrigin.forward), out var hitInfo, range, hitMask)) {
					AimHit = hitInfo.collider;
					hitPosition = hitInfo.point;
				}
				else {
					AimHit = default;
				}

				var distance = (hitPosition - shotOrigin.position).magnitude;
				redDot.localScale = redDot.localScale.With(z: distance);
				redDot.localPosition = new Vector3(0, 0, distance / 2);
			}
		}

		public bool TryPerformAction() {
			if (Time.time < NextShotAllowedTime) return false;
			if (ammo == 0) return false;
			ammo--;
			if (AimHitHealthController) AimHitHealthController.Damage();
			NextShotAllowedTime = Time.time + cooldown;
			OnActionTriggered.Invoke(shootAction);
			return true;
		}
	}
}