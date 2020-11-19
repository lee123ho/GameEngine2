using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct Stat
{
    [SerializeField] private float _maxHp;
    [SerializeField] private float _shootSpeed;
    [SerializeField] private float _attackRate;
    [SerializeField] private float _attackPower;

    private float _hp;

    public Stat(float maxHp = 10, float shootSpeed = 40f, float attackRate = 0.1f,
        float attackPower = 0.1f)
    {
        _maxHp = maxHp;
        _hp = maxHp;
        _shootSpeed = shootSpeed;
        _attackRate = attackRate;
        _attackPower = attackPower;
    }

    public float MaxHp => _maxHp;

    public float Hp => _hp;

    public float ShootSpeed => _shootSpeed;

    public float AttackRate => _attackRate;

    public float AttackPower => _attackPower;

    public void AddHp(float hpAmount)
    {
        _hp = Mathf.Clamp(_hp + hpAmount, 0, _maxHp);
    }
}
