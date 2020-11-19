using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU.Manager;

public class RangeEnemyShootController : MonoBehaviour
{
    private Player _player;
    private RangeEnemy _rangeEnemy;

    private float _timer;

    private void Awake()
    {
        _rangeEnemy = GetComponent<RangeEnemy>();
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        var playerPos = _player.transform.position;

        // 연사 속도 제어
        if (_timer <= _rangeEnemy.Stat.AttackRate) return;

        // 사망 확인
        if (_rangeEnemy.State == EnemyState.Dead) return;

        var bulletObj = ObjectPoolManager.Instance.Spawn("enemybullet");
        var shootPoint = GameObject.FindGameObjectWithTag("gPoint");
        bulletObj.SetActive(true);
        bulletObj.transform.position = shootPoint.transform.position;

        var bullet = bulletObj.GetComponent<enemyBullet>();
        if (!(bullet is null))
        {
            var dir = playerPos - transform.position;
            var normalized = new Vector3(dir.x, 0f, dir.z).normalized;

            bullet.Shoot(normalized, _rangeEnemy.Stat.ShootSpeed, _rangeEnemy.Stat.AttackPower);

            _timer = 0f;
        }
    }
}
