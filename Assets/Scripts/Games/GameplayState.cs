using NiUtils.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LD56 {
	public class GameplayState : IGameState {
		public static GameplayState State { get; } = new GameplayState();

		private int CurrentCreatureIndex { get; set; }
		private CreatureController CurrentCreature => GameData.Data.PlayerCreatures[CurrentCreatureIndex];

		private GameplayState() {
			InputManager.Controls.Player.Jump.AddPerformListenerOnce(HandleJumpPerformed);
			InputManager.Controls.Player.SwapCharacter.AddPerformListenerOnce(HandleSwapCharacterPerformed);
		}

		private void HandleSwapCharacterPerformed(InputAction.CallbackContext obj) => ChangeCreatureControl((CurrentCreatureIndex + 1).PosMod(GameData.Data.PlayerCreatures.Length));

		private void ChangeCreatureControl(int index) {
			CurrentCreature.IsActiveCreature = false;
			CurrentCreatureIndex = index.PosMod(GameData.Data.PlayerCreatures.Length);
			CurrentCreature.IsActiveCreature = true;
		}

		private void HandleJumpPerformed(InputAction.CallbackContext obj) => CurrentCreature.Jump();

		public void Enable() {
			ChangeCreatureControl(0);
			SetListenersEnabled(true);
		}

		private static void SetListenersEnabled(bool enabled) {
			InputManager.Controls.Player.Get().SetEnabled(enabled);
		}

		public void Disable() => SetListenersEnabled(false);

		public void Update() {
			CurrentCreature.Move(InputManager.Controls.Player.Move.ReadValue<Vector2>());
		}
	}
}