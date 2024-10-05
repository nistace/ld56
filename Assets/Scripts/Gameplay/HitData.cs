using System;
using UnityEngine;
namespace LD56
{
    [Serializable]
    public class HitData
    {
        [SerializeField] protected Vector3 point;
        [SerializeField] protected Vector3 force;
        [SerializeField] protected float kinematicAllowedInTime;

        public Vector3 Point => point;
        public Vector3 Force => force;
        public float KinematicAllowedInTime => kinematicAllowedInTime;

        public HitData() { }
        public HitData(Vector3 point, Vector3 force, float kinematicAllowedInTime)
        {
            this.point = point;
            this.force = force;
            this.kinematicAllowedInTime = kinematicAllowedInTime;
        }
    }
}
