using KPU.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageable
{
    private NavMeshAgent _agent;
    private GameInputActions _inputActions;
    public float ammoCount;

    [SerializeField] private Stat _stat;
    [SerializeField] private Camera _cam;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed = 5f;

    public Stat Stat => _stat;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        ammoCount = 0f;
    }

    private void Update()
    {
        // Player 이동
        _agent.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * (_speed * Time.deltaTime));

        // 마우스 포인터 방향으로 transform.forward
        Physics.Raycast(_cam.ScreenPointToRay(Input.mousePosition), out var raycastHit, _groundLayer);
        var dir = raycastHit.point - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
    }

    public void Damage(float damageAmount)
    {
        _stat.AddHp(-damageAmount);
    }

    public void GetGun(string gunName)
    {
        if (transform.childCount > 2)
            Destroy(transform.GetChild(2).gameObject);
        var gunObj = ObjectPoolManager.Instance.Spawn(gunName);
        Destroy(gunObj.GetComponent<Rigidbody>());
        gunObj.transform.position = transform.GetChild(1).transform.position;
        gunObj.transform.rotation = transform.GetChild(1).transform.rotation;
        gunObj.transform.SetParent(transform);
    }
}
