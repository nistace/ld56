using LD56;
using UnityEngine;
using UnityEngine.Events;

public class BoxingGloveController : MonoBehaviour, IActionPerformer
{
    [SerializeField] protected PerformAction hitAction;
    [SerializeField] protected float force = 2000;
    [SerializeField] protected float cooldown = .2f;
    [SerializeField] protected Transform hitOriginPoint;
    [SerializeField] protected float hitDistance = .2f;
    [SerializeField] protected LayerMask hitMask;

    private float NextHitAllowedTime { get; set; }
    public UnityEvent<PerformAction> OnActionTriggered { get; } = new UnityEvent<PerformAction>();

    public bool TryPerformAction()
    {
        if (Time.time < NextHitAllowedTime) return false;

        var hit = false;
        if (Physics.Raycast(new Ray(hitOriginPoint.position, hitOriginPoint.forward * hitDistance), out var hitInfo, hitDistance, hitMask))
        {
            var target = hitInfo.collider.GetComponentInParent<IHittable>();
            target?.Hit(new HitData(hitInfo.point, force * hitOriginPoint.forward, 2));
            hit = target != null;
        }

        NextHitAllowedTime = Time.time + cooldown;
        OnActionTriggered.Invoke(hitAction);
        return hit;
    }

    private void OnDrawGizmos()
    {
        if (!hitOriginPoint) return;
        Gizmos.color = new Color(.4f, 0, 0);
        Gizmos.DrawLine(hitOriginPoint.position, hitOriginPoint.position + hitOriginPoint.forward * hitDistance);
    }
}
