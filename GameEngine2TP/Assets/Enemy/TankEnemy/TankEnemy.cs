using KPU.Manager;
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
    private Canvas_UI _canvas;
    private enemySlider_UI _enemyHealthBar;
    private dropItem _drop;

    [SerializeField] private Stat _stat;
    [SerializeField] private float hitPlayerDistanceOffset = 1f;

    public Stat Stat => _stat;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        _drop = GetComponent<dropItem>();
        _state = EnemyState.Chasing;
        _stat.AddHp(_stat.MaxHp);

        var enemyHealthBarGameObject = ObjectPoolManager.Instance.Spawn("enemyslider");
        _enemyHealthBar = enemyHealthBarGameObject.GetComponent<enemySlider_UI>();
        _canvas = FindObjectOfType<Canvas_UI>();
        _enemyHealthBar.Initialize(this, _canvas.GetComponent<Canvas>(), new Vector2(0f, 45f));
        _enemyHealthBar.transform.parent = _canvas.transform;
        _enemyHealthBar.gameObject.SetActive(true);

        _lifeRoutine = StartCoroutine(lifeRoutine());
    }

    private void OnDisable()
    {
        if (_lifeRoutine != null) StopCoroutine(_lifeRoutine);

        _lifeRoutine = null;
    }

    private void Update()
    {
        if (transform.position.y < -5)
        {
            transform.position = new Vector3(transform.position.x, 5f, transform.position.z);
            GetComponent<NavMeshAgent>().enabled = true;
        }
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
        _player.killZombie();
        if (_drop.getItemName() != "none")
        {
            var dropitem = ObjectPoolManager.Instance.Spawn(_drop.getItemName());
            dropitem.transform.position = transform.position + new Vector3(0f, 0.5f, 0f);
        }
        _enemyHealthBar.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void Attack()
    {
        if ((_player.transform.position - transform.position).magnitude <= hitPlayerDistanceOffset && _timer >= _stat.AttackRate)
        {
            _player.Damage(_stat.AttackPower);

            _timer = 0f;
        }
        else
            _timer = Time.deltaTime;

        if ((_player.transform.position - transform.position).magnitude >= hitPlayerDistanceOffset)
            _state = EnemyState.Chasing;
    }

    private void Chasing()
    {
        _agent.SetDestination(_player.transform.position);

        var dir = (_player.transform.position - transform.position);
        if (dir.magnitude <= hitPlayerDistanceOffset) _state = EnemyState.Attacking;
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
