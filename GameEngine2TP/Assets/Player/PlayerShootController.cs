using KPU.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    private Player _player;
    private float _timer;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Camera _cam;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        // Time
        _timer += Time.deltaTime;

        if (_timer <= _player.Stat.AttackRate) return; // Shoot Rate 타이머가 안되었을 때.

        if (!Input.GetMouseButton(0)) return; // 마우스 클릭 여부 확인.
        if (_player.ammoCount <= 0) return; 

        var bulletGameObject = ObjectPoolManager.Instance.Spawn("playerbullet");
        bulletGameObject.SetActive(true);
        bulletGameObject.transform.position = transform.GetChild(1).position;

        var bullet = bulletGameObject.GetComponent<playerBullet>();
        if (!(bullet is null) && Physics.Raycast(_cam.ScreenPointToRay(Input.mousePosition), out var raycastHit, groundLayer))
        {
            var dir = raycastHit.point - transform.GetChild(1).position;
            var normalizedDir = new Vector3(dir.x, 0, dir.z).normalized;

            bullet.Shoot(normalizedDir, _player.Stat.ShootSpeed, _player.Stat.AttackPower);

            _player.ammoCount--;

            _timer = 0f; // timer reset
        }
    }
}
