using System.Linq;
using NiUtils.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace LD56
{
    public class GameController : MonoBehaviour
    {
        private IGameState CurrentState { get; set; }

        [SerializeField] protected GameData gameData = new GameData();

        private void Start()
        {
            gameData.Initialize(GetComponentsInChildren<BoxingGloveController>().Select(t => t as Component).Union(GetComponentsInChildren<ShieldController>())
                .Union(GetComponentsInChildren<GunController>()).Where(t => t).Select(t => t.GetComponentInParent<CreatureController>()).Where(t => t).ToArray());

            GameData.Data = gameData;
            SetState(GameplayState.State);
            InputManager.Controls.Player.Restart.AddPerformListenerOnce(HandleRestartPressed);
        }

        private void OnDestroy()
        {
            SetState(null);
            InputManager.Controls.Player.Restart.RemovePerformListener(HandleRestartPressed);
        }

        private void SetState(IGameState state)
        {
            CurrentState?.Disable();
            CurrentState = state;
            CurrentState?.Enable();
        }

        private void Update()
        {
            CurrentState?.Update();
        }

        private static void HandleRestartPressed(InputAction.CallbackContext obj) => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
