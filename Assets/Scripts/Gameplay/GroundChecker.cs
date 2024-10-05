using System.Collections.Generic;
using UnityEngine;

namespace LD56 {
	public class GroundChecker : MonoBehaviour {
		private HashSet<GameObject> Grounds { get; } = new HashSet<GameObject>();
		public bool IsOnGround => Grounds.Count > 0;

		private void OnTriggerEnter(Collider other) => Grounds.Add(other.gameObject);

		private void OnTriggerExit(Collider other) => Grounds.Remove(other.gameObject);
	}
}