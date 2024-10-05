using UnityEngine;

namespace LD56 {
	public class HealthController : MonoBehaviour {
		[SerializeField] protected int maxHealth;
		[SerializeField] protected int health;
		[SerializeField] protected bool resetHealthOnStart = true;

		private void Start() {
			if (resetHealthOnStart) {
				health = maxHealth;
			}
		}

		public void Damage() => Change(-1);

		public void Heal() => Change(1);

		private void Change(int delta) => health = Mathf.Clamp(health + delta, 0, maxHealth);
	}
}