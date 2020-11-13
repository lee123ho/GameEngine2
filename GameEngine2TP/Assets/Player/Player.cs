using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameInputActions _inputActions;

    [SerializeField] private Camera _cam;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float _speed = 5f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Player 이동
        _agent.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * (_speed * Time.deltaTime));

        // 마우스 포인터 방향으로 transform.forward
        Physics.Raycast(_cam.ScreenPointToRay(Input.mousePosition), out var raycastHit, groundLayer);
        var dir = raycastHit.point - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
    }
}
