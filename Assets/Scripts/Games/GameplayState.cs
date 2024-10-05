using NiUtils.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LD56
{
    public class GameplayState : IGameState
    {
        public static GameplayState State { get; } = new GameplayState();

        private int CurrentCreatureIndex { get; set; }
        private CreatureController CurrentCreature => GameData.Data.PlayerCreatures[CurrentCreatureIndex];

        private GameplayState()
        {
            InputManager.Controls.Player.Jump.AddPerformListenerOnce(HandleJumpPerformed);
            InputManager.Controls.Player.Action.AddPerformListenerOnce(HandleActionPerformed);
            InputManager.Controls.Player.SelectCharacter0.AddPerformListenerOnce(HandleSelectCharacter0);
            InputManager.Controls.Player.SelectCharacter1.AddPerformListenerOnce(HandleSelectCharacter1);
            InputManager.Controls.Player.SelectCharacter2.AddPerformListenerOnce(HandleSelectCharacter2);
            InputManager.Controls.Player.SelectCharacter3.AddPerformListenerOnce(HandleSelectCharacter3);
            InputManager.Controls.Player.SelectCharacter4.AddPerformListenerOnce(HandleSelectCharacter4);
        }
        private void HandleSelectCharacter0(InputAction.CallbackContext obj) => ChangeCreatureControl(0);
        private void HandleSelectCharacter1(InputAction.CallbackContext obj) => ChangeCreatureControl(1);
        private void HandleSelectCharacter2(InputAction.CallbackContext obj) => ChangeCreatureControl(2);
        private void HandleSelectCharacter3(InputAction.CallbackContext obj) => ChangeCreatureControl(3);
        private void HandleSelectCharacter4(InputAction.CallbackContext obj) => ChangeCreatureControl(4);

        private void ChangeCreatureControl(int index)
        {
            CurrentCreature.SetCreatureAsActive(false);
            CurrentCreatureIndex = index.PosMod(GameData.Data.PlayerCreatures.Count);
            CurrentCreature.SetCreatureAsActive(true);
            GameData.Data.Camera.Target = CurrentCreature;
        }

        private void HandleJumpPerformed(InputAction.CallbackContext obj) => CurrentCreature.Jump();
        private void HandleActionPerformed(InputAction.CallbackContext obj) => CurrentCreature.PerformAction();

        public void Enable()
        {
            ChangeCreatureControl(0);
            GameData.Data.Camera.SnapToTarget();
            SetListenersEnabled(true);
        }

        private static void SetListenersEnabled(bool enabled)
        {
            InputManager.Controls.Player.Get().SetEnabled(enabled);
        }

        public void Disable() => SetListenersEnabled(false);

        public void Update()
        {
            CurrentCreature.Move(InputManager.Controls.Player.Move.ReadValue<Vector2>());
        }
    }
}
