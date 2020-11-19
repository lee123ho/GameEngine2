using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankEnemy : MonoBehaviour, IDamageable
{
    private NavMeshAgent _agent;
    private Player _player;
    private EnemyState _state;
    private Coroutine _lifeRoutine;
    private float _timer;

    [SerializeField] private Stat _stat;
    [SerializeField] private float _attackRange;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        _state = EnemyState.Chasing;
        _stat.AddHp(_stat.MaxHp);
        _lifeRoutine = StartCoroutine(lifeRoutine());
    }

    private void OnDisable()
    {
        if (_lifeRoutine != null) StopCoroutine(_lifeRoutine);

        _lifeRoutine = null;
    }

    private IEnumerator lifeRoutine()
    {
        while (_state != EnemyState.Dead)
        {
            if (_state == EnemyState.Chasing) Chasing();
            else if (_state == EnemyState.Attacking) Attack();
            yield return null;
        }

        Death();
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }

    private void Attack()
    {
        if ((_player.transform.position - transform.position).magnitude <= _attackRange && _timer <= _stat.AttackRate)
        {
            _player.Damage(_stat.AttackPower);



            _timer = 0f;
        }
        else
            _timer = Time.deltaTime;
    }

    private void Chasing()
    {
        _agent.SetDestination(_player.transform.position);
    }

    public void Damage(float damageAmount)
    {
        _stat.AddHp(-damageAmount);
        if(_stat.Hp <= 0)
        {
            _state = EnemyState.Dead;
        }
    }
}
