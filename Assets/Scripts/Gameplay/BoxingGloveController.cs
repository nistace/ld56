using LD56;
using UnityEngine;
using UnityEngine.Events;

public class BoxingGloveController : MonoBehaviour, IActionPerformer {
	[SerializeField] protected PerformAction hitAction;
	[SerializeField] protected float force = 2000;
	[SerializeField] protected float cooldown = .2f;
	[SerializeField] protected Transform hitPosition;
	[SerializeField] protected float hitRadius = .2f;
	[SerializeField] protected LayerMask hitMask;

	private float NextShotAllowedTime { get; set; }
	public UnityEvent<PerformAction> OnActionTriggered { get; } = new UnityEvent<PerformAction>();

	private Collider[] HitColliderNonAlloc { get; } = new Collider[3];

	public bool TryPerformAction() {
		if (Time.time < NextShotAllowedTime) return false;

		var hitTargets = Physics.OverlapSphereNonAlloc(hitPosition.position, hitRadius, HitColliderNonAlloc, hitMask);

		IHittable target = null;
		for (var i = 0; target == null && i < hitTargets; ++i) {
			target = HitColliderNonAlloc[i].GetComponentInParent<IHittable>();
			if (transform.IsChildOf(target.transform)) target = default;
		}
		target?.Hit(force * hitPosition.forward, 2);
		NextShotAllowedTime = Time.time + cooldown;
		OnActionTriggered.Invoke(hitAction);
		return target != null;
	}

	private void OnDrawGizmos() {
		if (!hitPosition) return;
		Gizmos.color = new Color(.4f, 0, 0);
		Gizmos.DrawSphere(hitPosition.position, hitRadius);
	}
}