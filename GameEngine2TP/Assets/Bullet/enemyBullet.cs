using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Coroutine _bulletLifeTime;

    private float _power;
    private float _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _bulletLifeTime = StartCoroutine(BulletLiftTime());
        _rigidbody.velocity = Vector3.zero;
    }

    private void OnDisable()
    {
        if (_bulletLifeTime == null) return;

        StopCoroutine(_bulletLifeTime);
        _bulletLifeTime = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("exploObj"))
        {
            var damagable = collision.gameObject.GetComponent<IDamageable>();
            damagable.Damage(_power);
        }
        gameObject.SetActive(false);
    }

    private IEnumerator BulletLiftTime()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    public void Shoot(Vector3 vec, float speed, float power)
    {
        _power = power;
        _speed = speed;

        _rigidbody.AddForce(vec * _speed, ForceMode.Impulse);
    }
}
