using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCharacterCarmeraController : MonoBehaviour, GameInputActions.ITpsCameraActions
{
    private GameInputActions _inputActions;
    private Vector2 _mouseDeltaVector;
    private float _carmeraRotation;

    [SerializeField] private Transform _carmeraTransform;
    [SerializeField] private float _mouseSensitivity = 100f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        if (_inputActions == null)
            _inputActions = new GameInputActions();

        _inputActions.TpsCamera.SetCallbacks(this);
        _inputActions.TpsCamera.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void Update()
    {
        var horizontalDirection = _mouseDeltaVector.x * Time.deltaTime * _mouseSensitivity;
        transform.Rotate(0, horizontalDirection, 0);

        _carmeraRotation = Mathf.Clamp(_carmeraRotation - _mouseDeltaVector.y * Time.deltaTime * _mouseSensitivity, -90f, 90f);
        _carmeraTransform.localRotation = Quaternion.Euler(_carmeraRotation, 0, 0);
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        _mouseDeltaVector = context.ReadValue<Vector2>();
    }
}
