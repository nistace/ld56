using System;
using UnityEngine;
namespace LD56
{
    public class SimpleHittable : MonoBehaviour, IHittable
    {

        [SerializeField] protected new Rigidbody rigidbody;
        [SerializeField] protected float maxMagnitude = float.MaxValue;
        [SerializeField] protected bool applyAtPoint = true;
        [SerializeField] protected bool neverKinematic = true;

        private float NextKinematicAllowedTime { get; set; }

        private void FixedUpdate()
        {
            RefreshKinematic();
        }

        private void RefreshKinematic()
        {

            if (neverKinematic) return;
            if (rigidbody.isKinematic) return;
            if (rigidbody.velocity.sqrMagnitude > .01f) return;
            if (Time.time < NextKinematicAllowedTime) return;

            rigidbody.isKinematic = true;
        }

        public void Hit(HitData hitData)
        {
            rigidbody.isKinematic = false;
            if (applyAtPoint)
            {
                rigidbody.AddForceAtPosition(Vector3.ClampMagnitude(hitData.Force, maxMagnitude), hitData.Point);

            }
            else
            {
                rigidbody.AddForce(Vector3.ClampMagnitude(hitData.Force, maxMagnitude));

            }
            NextKinematicAllowedTime = Mathf.Max(NextKinematicAllowedTime, Time.time + hitData.KinematicAllowedInTime);
        }
    }
}
