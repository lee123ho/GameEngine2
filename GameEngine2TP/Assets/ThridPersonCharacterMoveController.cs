using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThridPersonCharacterMoveController : MonoBehaviour, GameInputActions.ITPSActions
{
    private CharacterController _characterController;
    private GameInputActions _InputActions;
    private Vector2 _moveActionValue;
    private float _fallingSpeed = 0f;

    private const float gravity = 9.8f;

    [SerializeField] private float characterMoveSpeed = 10f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        if (_InputActions == null)
            _InputActions = new GameInputActions();

        _InputActions.TPS.SetCallbacks(this);
        _InputActions.TPS.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        var verticalVector = transform.forward * _moveActionValue.y * Time.deltaTime * characterMoveSpeed;
        var horizontalVector = transform.right * _moveActionValue.x * Time.deltaTime * characterMoveSpeed;
       _characterController.Move(verticalVector + horizontalVector);

        _fallingSpeed -= Time.deltaTime * gravity;
        _characterController.Move(new Vector3(0, _fallingSpeed, 0));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveActionValue = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
    }
}
