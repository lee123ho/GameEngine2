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
        if (_player.ammoCount <= 0 && _player.LastGun != "handgun(clone)") return; 

        var bulletGameObject = ObjectPoolManager.Instance.Spawn("playerbullet");
        bulletGameObject.SetActive(true);
        bulletGameObject.transform.position = transform.GetChild(1).position;

        var bullet = bulletGameObject.GetComponent<playerBullet>();
        if (!(bullet is null))
        {
            if(_player.LastGun == "shotgun(clone)")
            {
                bullet.Shoot(_player.transform.forward, _player.Stat.ShootSpeed, _player.Stat.AttackPower);
                _player.ammoCount -= 5f;
            }
            else if (_player.LastGun == "riflegun(clone)")
            {
                bullet.Shoot(_player.transform.forward, _player.Stat.ShootSpeed, _player.Stat.AttackPower);

                _player.ammoCount--;
            }
            else if (_player.LastGun == "handgun(clone)")
            {
                bullet.Shoot(_player.transform.forward, _player.Stat.ShootSpeed, _player.Stat.AttackPower);
            }



            _timer = 0f; // timer reset
        }
    }
}
