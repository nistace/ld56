//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Inputs/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace LD56
{
    public partial class @Controls: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""fc1e6fc7-4b0b-482c-89d3-b0af75d163de"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""add17208-b6a7-440d-9e5a-143993463060"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""94042673-a3b0-4274-b3eb-988897679ae0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""e0ea6c33-e78e-4cbd-bf8a-0de2652ce9f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""7bf85956-d1bf-484b-bc78-5b72709ec794"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectCharacter0"",
                    ""type"": ""Button"",
                    ""id"": ""a0365c21-7b7a-47d9-9a2b-3f36fe91863e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectCharacter1"",
                    ""type"": ""Button"",
                    ""id"": ""2cd47b24-3c7f-4117-9a4c-f89bf80b16fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectCharacter2"",
                    ""type"": ""Button"",
                    ""id"": ""b23a298d-a968-4b0a-9281-5cfa1330a733"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectCharacter3"",
                    ""type"": ""Button"",
                    ""id"": ""5b6a314a-f6e4-484e-94b1-a1a0ce3df030"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectCharacter4"",
                    ""type"": ""Button"",
                    ""id"": ""e25e49d4-2977-4b90-8a59-2c8c14e54dbb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""fdd08167-735e-4e2d-9ec9-f476235e355f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""56f8423e-447b-4e2e-a75a-c2e602fbb17d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13bf8d30-aef8-4bb9-9e9c-7216f6d19901"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b335579a-95ef-4045-89f2-2dee73accf8a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""72bcd1ba-ca4d-43f0-9c3c-51c20abc7596"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0dcdf1da-376e-41e9-8767-4d1f700a9a20"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""03d38cd8-4135-4f73-8d9f-55ac134755b9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fa0982b4-b5f0-4026-9588-0a5202885c53"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""aee59bd0-6ec5-49f7-a1a9-988dd65e08b5"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c432ab1-5361-45e7-92f0-9d076168bd7c"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCharacter0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbf7e720-135c-437b-8694-50ca0a637efb"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCharacter0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55aa25cf-dfc1-4403-9bf8-ac2104f58793"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCharacter1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""859f033d-0ade-4042-8810-fa2df7129c43"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCharacter1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""507ab2a1-e1c0-4079-bec7-32e108b4b218"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCharacter2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c951bba-2500-402d-a8c1-68e0063c21bd"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCharacter2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d28284e-dfa5-4bdb-853e-8a23fe8951ec"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCharacter3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b7996dd-2ea1-4da0-bca3-376721728518"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCharacter3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63a4bf56-a8c9-4e9c-8e86-bda391f36412"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCharacter4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e15c16b0-f4f3-443c-8966-e5f3bc88be96"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCharacter4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7cb8136-7a1d-4fd5-9647-8472d8ac0c94"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
            m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
            m_Player_Action = m_Player.FindAction("Action", throwIfNotFound: true);
            m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
            m_Player_SelectCharacter0 = m_Player.FindAction("SelectCharacter0", throwIfNotFound: true);
            m_Player_SelectCharacter1 = m_Player.FindAction("SelectCharacter1", throwIfNotFound: true);
            m_Player_SelectCharacter2 = m_Player.FindAction("SelectCharacter2", throwIfNotFound: true);
            m_Player_SelectCharacter3 = m_Player.FindAction("SelectCharacter3", throwIfNotFound: true);
            m_Player_SelectCharacter4 = m_Player.FindAction("SelectCharacter4", throwIfNotFound: true);
            m_Player_Restart = m_Player.FindAction("Restart", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Player
        private readonly InputActionMap m_Player;
        private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
        private readonly InputAction m_Player_Move;
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_Action;
        private readonly InputAction m_Player_Aim;
        private readonly InputAction m_Player_SelectCharacter0;
        private readonly InputAction m_Player_SelectCharacter1;
        private readonly InputAction m_Player_SelectCharacter2;
        private readonly InputAction m_Player_SelectCharacter3;
        private readonly InputAction m_Player_SelectCharacter4;
        private readonly InputAction m_Player_Restart;
        public struct PlayerActions
        {
            private @Controls m_Wrapper;
            public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Player_Move;
            public InputAction @Jump => m_Wrapper.m_Player_Jump;
            public InputAction @Action => m_Wrapper.m_Player_Action;
            public InputAction @Aim => m_Wrapper.m_Player_Aim;
            public InputAction @SelectCharacter0 => m_Wrapper.m_Player_SelectCharacter0;
            public InputAction @SelectCharacter1 => m_Wrapper.m_Player_SelectCharacter1;
            public InputAction @SelectCharacter2 => m_Wrapper.m_Player_SelectCharacter2;
            public InputAction @SelectCharacter3 => m_Wrapper.m_Player_SelectCharacter3;
            public InputAction @SelectCharacter4 => m_Wrapper.m_Player_SelectCharacter4;
            public InputAction @Restart => m_Wrapper.m_Player_Restart;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void AddCallbacks(IPlayerActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @SelectCharacter0.started += instance.OnSelectCharacter0;
                @SelectCharacter0.performed += instance.OnSelectCharacter0;
                @SelectCharacter0.canceled += instance.OnSelectCharacter0;
                @SelectCharacter1.started += instance.OnSelectCharacter1;
                @SelectCharacter1.performed += instance.OnSelectCharacter1;
                @SelectCharacter1.canceled += instance.OnSelectCharacter1;
                @SelectCharacter2.started += instance.OnSelectCharacter2;
                @SelectCharacter2.performed += instance.OnSelectCharacter2;
                @SelectCharacter2.canceled += instance.OnSelectCharacter2;
                @SelectCharacter3.started += instance.OnSelectCharacter3;
                @SelectCharacter3.performed += instance.OnSelectCharacter3;
                @SelectCharacter3.canceled += instance.OnSelectCharacter3;
                @SelectCharacter4.started += instance.OnSelectCharacter4;
                @SelectCharacter4.performed += instance.OnSelectCharacter4;
                @SelectCharacter4.canceled += instance.OnSelectCharacter4;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
            }

            private void UnregisterCallbacks(IPlayerActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @Action.started -= instance.OnAction;
                @Action.performed -= instance.OnAction;
                @Action.canceled -= instance.OnAction;
                @Aim.started -= instance.OnAim;
                @Aim.performed -= instance.OnAim;
                @Aim.canceled -= instance.OnAim;
                @SelectCharacter0.started -= instance.OnSelectCharacter0;
                @SelectCharacter0.performed -= instance.OnSelectCharacter0;
                @SelectCharacter0.canceled -= instance.OnSelectCharacter0;
                @SelectCharacter1.started -= instance.OnSelectCharacter1;
                @SelectCharacter1.performed -= instance.OnSelectCharacter1;
                @SelectCharacter1.canceled -= instance.OnSelectCharacter1;
                @SelectCharacter2.started -= instance.OnSelectCharacter2;
                @SelectCharacter2.performed -= instance.OnSelectCharacter2;
                @SelectCharacter2.canceled -= instance.OnSelectCharacter2;
                @SelectCharacter3.started -= instance.OnSelectCharacter3;
                @SelectCharacter3.performed -= instance.OnSelectCharacter3;
                @SelectCharacter3.canceled -= instance.OnSelectCharacter3;
                @SelectCharacter4.started -= instance.OnSelectCharacter4;
                @SelectCharacter4.performed -= instance.OnSelectCharacter4;
                @SelectCharacter4.canceled -= instance.OnSelectCharacter4;
                @Restart.started -= instance.OnRestart;
                @Restart.performed -= instance.OnRestart;
                @Restart.canceled -= instance.OnRestart;
            }

            public void RemoveCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPlayerActions instance)
            {
                foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        public interface IPlayerActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnAction(InputAction.CallbackContext context);
            void OnAim(InputAction.CallbackContext context);
            void OnSelectCharacter0(InputAction.CallbackContext context);
            void OnSelectCharacter1(InputAction.CallbackContext context);
            void OnSelectCharacter2(InputAction.CallbackContext context);
            void OnSelectCharacter3(InputAction.CallbackContext context);
            void OnSelectCharacter4(InputAction.CallbackContext context);
            void OnRestart(InputAction.CallbackContext context);
        }
    }
}
