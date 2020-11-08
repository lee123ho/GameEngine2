using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Player _player;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        _agent.SetDestination(_player.transform.position);
    }
}
