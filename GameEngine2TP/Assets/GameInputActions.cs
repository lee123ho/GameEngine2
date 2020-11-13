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
            ""name"": ""Number"",
            ""id"": ""2777d5ed-f5e9-4185-8208-4dd9929ebc46"",
            ""actions"": [
                {
                    ""name"": ""Stage1"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f2c32b40-624f-469b-83e8-8f5ac08a6c7c"",
                    ""expectedControlType"": ""Key"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Stage2"",
                    ""type"": ""PassThrough"",
                    ""id"": ""92f39144-ef54-4627-b006-19a562623685"",
                    ""expectedControlType"": ""Key"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Stage3"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ddfdf9d0-f9c8-4589-ab76-7454c79dfe71"",
                    ""expectedControlType"": ""Key"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8bdcb0d7-a1dc-4cc9-9524-3685ee317667"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stage1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""042ae2e5-bcd5-489a-b02a-85f47bcab359"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stage2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eeda4dde-3361-48ad-81a4-a2ee494e8329"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stage3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Number
        m_Number = asset.FindActionMap("Number", throwIfNotFound: true);
        m_Number_Stage1 = m_Number.FindAction("Stage1", throwIfNotFound: true);
        m_Number_Stage2 = m_Number.FindAction("Stage2", throwIfNotFound: true);
        m_Number_Stage3 = m_Number.FindAction("Stage3", throwIfNotFound: true);
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

    // Number
    private readonly InputActionMap m_Number;
    private INumberActions m_NumberActionsCallbackInterface;
    private readonly InputAction m_Number_Stage1;
    private readonly InputAction m_Number_Stage2;
    private readonly InputAction m_Number_Stage3;
    public struct NumberActions
    {
        private @GameInputActions m_Wrapper;
        public NumberActions(@GameInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Stage1 => m_Wrapper.m_Number_Stage1;
        public InputAction @Stage2 => m_Wrapper.m_Number_Stage2;
        public InputAction @Stage3 => m_Wrapper.m_Number_Stage3;
        public InputActionMap Get() { return m_Wrapper.m_Number; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NumberActions set) { return set.Get(); }
        public void SetCallbacks(INumberActions instance)
        {
            if (m_Wrapper.m_NumberActionsCallbackInterface != null)
            {
                @Stage1.started -= m_Wrapper.m_NumberActionsCallbackInterface.OnStage1;
                @Stage1.performed -= m_Wrapper.m_NumberActionsCallbackInterface.OnStage1;
                @Stage1.canceled -= m_Wrapper.m_NumberActionsCallbackInterface.OnStage1;
                @Stage2.started -= m_Wrapper.m_NumberActionsCallbackInterface.OnStage2;
                @Stage2.performed -= m_Wrapper.m_NumberActionsCallbackInterface.OnStage2;
                @Stage2.canceled -= m_Wrapper.m_NumberActionsCallbackInterface.OnStage2;
                @Stage3.started -= m_Wrapper.m_NumberActionsCallbackInterface.OnStage3;
                @Stage3.performed -= m_Wrapper.m_NumberActionsCallbackInterface.OnStage3;
                @Stage3.canceled -= m_Wrapper.m_NumberActionsCallbackInterface.OnStage3;
            }
            m_Wrapper.m_NumberActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Stage1.started += instance.OnStage1;
                @Stage1.performed += instance.OnStage1;
                @Stage1.canceled += instance.OnStage1;
                @Stage2.started += instance.OnStage2;
                @Stage2.performed += instance.OnStage2;
                @Stage2.canceled += instance.OnStage2;
                @Stage3.started += instance.OnStage3;
                @Stage3.performed += instance.OnStage3;
                @Stage3.canceled += instance.OnStage3;
            }
        }
    }
    public NumberActions @Number => new NumberActions(this);
    public interface INumberActions
    {
        void OnStage1(InputAction.CallbackContext context);
        void OnStage2(InputAction.CallbackContext context);
        void OnStage3(InputAction.CallbackContext context);
    }
}
