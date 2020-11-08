// GENERATED AUTOMATICALLY FROM 'Assets/GameInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputActions"",
    ""maps"": [
        {
            ""name"": ""TPS"",
            ""id"": ""1278e1f6-db2c-40bb-8481-ab52f0f1b50b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5f8b941c-bb67-42df-a73a-33214955a922"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""ca5b7dcc-ba53-4803-b4c9-9342a20d8671"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""935afa2d-2859-4ac9-a724-415543b67131"",
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
                    ""id"": ""f1a1f910-13ce-46fc-b087-007c651148af"",
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
                    ""id"": ""ac11fb17-e5aa-4b5a-89c0-d07e03a212bc"",
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
                    ""id"": ""f136b865-018a-46ae-a535-db2469f31700"",
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
                    ""id"": ""d26c1be3-7d02-4c2e-a2e0-c37d5a020cd4"",
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
                    ""id"": ""e77d70cd-3465-44e5-bb3b-d4fedf477c48"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""TpsCamera"",
            ""id"": ""aa682ca6-f30e-4d85-8cc2-a8631fb2e26c"",
            ""actions"": [
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1e3aa1fa-f9b6-40c3-9b99-2a595f6e5a31"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""110988b2-ff86-4005-8a4f-a6a2411b5e1d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TPS
        m_TPS = asset.FindActionMap("TPS", throwIfNotFound: true);
        m_TPS_Move = m_TPS.FindAction("Move", throwIfNotFound: true);
        m_TPS_Sprint = m_TPS.FindAction("Sprint", throwIfNotFound: true);
        // TpsCamera
        m_TpsCamera = asset.FindActionMap("TpsCamera", throwIfNotFound: true);
        m_TpsCamera_Aim = m_TpsCamera.FindAction("Aim", throwIfNotFound: true);
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

    // TPS
    private readonly InputActionMap m_TPS;
    private ITPSActions m_TPSActionsCallbackInterface;
    private readonly InputAction m_TPS_Move;
    private readonly InputAction m_TPS_Sprint;
    public struct TPSActions
    {
        private @GameInputActions m_Wrapper;
        public TPSActions(@GameInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_TPS_Move;
        public InputAction @Sprint => m_Wrapper.m_TPS_Sprint;
        public InputActionMap Get() { return m_Wrapper.m_TPS; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TPSActions set) { return set.Get(); }
        public void SetCallbacks(ITPSActions instance)
        {
            if (m_Wrapper.m_TPSActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TPSActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TPSActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TPSActionsCallbackInterface.OnMove;
                @Sprint.started -= m_Wrapper.m_TPSActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_TPSActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_TPSActionsCallbackInterface.OnSprint;
            }
            m_Wrapper.m_TPSActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
            }
        }
    }
    public TPSActions @TPS => new TPSActions(this);

    // TpsCamera
    private readonly InputActionMap m_TpsCamera;
    private ITpsCameraActions m_TpsCameraActionsCallbackInterface;
    private readonly InputAction m_TpsCamera_Aim;
    public struct TpsCameraActions
    {
        private @GameInputActions m_Wrapper;
        public TpsCameraActions(@GameInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_TpsCamera_Aim;
        public InputActionMap Get() { return m_Wrapper.m_TpsCamera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TpsCameraActions set) { return set.Get(); }
        public void SetCallbacks(ITpsCameraActions instance)
        {
            if (m_Wrapper.m_TpsCameraActionsCallbackInterface != null)
            {
                @Aim.started -= m_Wrapper.m_TpsCameraActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_TpsCameraActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_TpsCameraActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_TpsCameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public TpsCameraActions @TpsCamera => new TpsCameraActions(this);
    public interface ITPSActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
    public interface ITpsCameraActions
    {
        void OnAim(InputAction.CallbackContext context);
    }
}
