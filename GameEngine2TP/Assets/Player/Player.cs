using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private float _speed = 5f;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        var dir = (_cam.transform.forward * Input.GetAxis("Vertical") + _cam.transform.right * Input.GetAxis("Horizontal")).normalized;

        _agent.Move(new Vector3(dir.x, 0, dir.z) * (_speed * Time.deltaTime));

        transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
    }
}
