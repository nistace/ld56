using System;
using UnityEngine;

namespace LD56
{
    public class GameplayCameraController : MonoBehaviour
    {

        [SerializeField] protected float movementSmoothness = 1;
        [SerializeField] protected float movementMaxVelocity = 3;
        [SerializeField] protected Transform lookAt;

        private Vector3 movementVelocity;
        public ICameraTarget Target { get; set; }

        public void SnapToTarget()
        {
            transform.position = Target.CameraTargetPosition;
            movementVelocity = Vector3.zero;

        }

        private void FixedUpdate()
        {
            if (Target == null) return;
            transform.position = Vector3.SmoothDamp(transform.position, Target.CameraTargetPosition, ref movementVelocity, movementSmoothness, movementMaxVelocity);
        }
    }
}
