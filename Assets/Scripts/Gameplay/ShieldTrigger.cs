using System;
using System.Collections.Generic;
using UnityEngine;

namespace LD56 {
	public class ShieldTrigger : MonoBehaviour {
		private HashSet<IPropelable> PropelablesInTrigger { get; } = new HashSet<IPropelable>();

		private void OnTriggerEnter(Collider other) {
			var body = other.GetComponentInParent<IPropelable>();
			if (body != null) PropelablesInTrigger.Add(body);
		}

		private void OnTriggerExit(Collider other) {
			var body = other.GetComponentInParent<IPropelable>();
			if (body != null) PropelablesInTrigger.Remove(body);
		}

		public IEnumerable<IPropelable> GetPropelablesInTrigger() => PropelablesInTrigger;
	}
}