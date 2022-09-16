//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.2
//     from Assets/Input/InputActions.inputactions
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

public partial class @InputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""HumanoidLand"",
            ""id"": ""dc35b000-9ab3-4ef2-95f9-a53a5f85024b"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""a4362223-fdb4-4ef6-ac45-6fb2f295d29c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""4a6983bb-de06-4bd9-b061-291727de3126"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Value"",
                    ""id"": ""bfb8019e-5194-499e-a1a3-21d9b1f1c7e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""2fa93f2c-c270-4d1b-a285-99c4c5085f8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""eaecf600-5fa2-47b2-a14e-5e73d6e6eeb7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7e06b30b-3c25-4f6d-8baa-fe5098af4000"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""0359dde3-dbcd-46c1-b7a7-e991c591a6e3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0d9ea0d7-6286-45bc-89a1-d70129c52a96"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d7cb687a-3742-479c-812f-88896c736aad"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""65a46a3a-6526-4e5e-abba-12d833cbba51"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3599e1de-a180-448f-b91e-c566f5e2537e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""21c605ad-c876-4fa3-88f2-b823fb593b9a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0a2a1b91-e78a-4584-b77b-27f449eb6dc0"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""df15e570-70ec-4699-b778-7e8bdf777980"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""756ff1d1-b045-43c6-80db-a4da0bc61cc9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d233e119-52c0-4656-ab8a-e6ad738e84ad"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3cc5fcf3-1c82-4de1-946f-b28303ad5d3a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e919bd17-1d8b-4e55-b24d-b0ce1c37c919"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b6781c1-02ff-4d54-b023-d42dcdecfa34"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18b5159f-77d8-4e62-b24d-150d98e0bfde"",
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
                    ""id"": ""249913cc-3ef7-4948-aa0b-8a6f6a388fa7"",
                    ""path"": ""<Keyboard>/r"",
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
        // HumanoidLand
        m_HumanoidLand = asset.FindActionMap("HumanoidLand", throwIfNotFound: true);
        m_HumanoidLand_Walk = m_HumanoidLand.FindAction("Walk", throwIfNotFound: true);
        m_HumanoidLand_Look = m_HumanoidLand.FindAction("Look", throwIfNotFound: true);
        m_HumanoidLand_Dash = m_HumanoidLand.FindAction("Dash", throwIfNotFound: true);
        m_HumanoidLand_Jump = m_HumanoidLand.FindAction("Jump", throwIfNotFound: true);
        m_HumanoidLand_Restart = m_HumanoidLand.FindAction("Restart", throwIfNotFound: true);
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

    // HumanoidLand
    private readonly InputActionMap m_HumanoidLand;
    private IHumanoidLandActions m_HumanoidLandActionsCallbackInterface;
    private readonly InputAction m_HumanoidLand_Walk;
    private readonly InputAction m_HumanoidLand_Look;
    private readonly InputAction m_HumanoidLand_Dash;
    private readonly InputAction m_HumanoidLand_Jump;
    private readonly InputAction m_HumanoidLand_Restart;
    public struct HumanoidLandActions
    {
        private @InputActions m_Wrapper;
        public HumanoidLandActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_HumanoidLand_Walk;
        public InputAction @Look => m_Wrapper.m_HumanoidLand_Look;
        public InputAction @Dash => m_Wrapper.m_HumanoidLand_Dash;
        public InputAction @Jump => m_Wrapper.m_HumanoidLand_Jump;
        public InputAction @Restart => m_Wrapper.m_HumanoidLand_Restart;
        public InputActionMap Get() { return m_Wrapper.m_HumanoidLand; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HumanoidLandActions set) { return set.Get(); }
        public void SetCallbacks(IHumanoidLandActions instance)
        {
            if (m_Wrapper.m_HumanoidLandActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnWalk;
                @Look.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnLook;
                @Dash.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnDash;
                @Jump.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnJump;
                @Restart.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnRestart;
            }
            m_Wrapper.m_HumanoidLandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
            }
        }
    }
    public HumanoidLandActions @HumanoidLand => new HumanoidLandActions(this);
    public interface IHumanoidLandActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
    }
}