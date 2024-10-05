using UnityEngine;

namespace LD56 {
	public class GameController : MonoBehaviour {
		private IGameState CurrentState { get; set; }

		[SerializeField] protected GameData gameData = new GameData();

		private void Start() {
			GameData.Data = gameData;
			SetState(GameplayState.State);
		}

		private void OnDestroy() {
			SetState(null);
		}

		private void SetState(IGameState state) {
			CurrentState?.Disable();
			CurrentState = state;
			CurrentState?.Enable();
		}

		private void Update() {
			CurrentState?.Update();
		}
	}
}