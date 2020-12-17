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
    private MeshRenderer _renderer;
    public float ammoCount;
    public string LastGun;
    public int killZombieCount;
    public int remainingZombies;
    private float noDamageTime = 0.5f;
    private bool _isdamagable = true;
    public int stageNum;

    [SerializeField] private Stat _stat;
    [SerializeField] private Camera _cam;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed = 5f;

    public Stat Stat => _stat;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _renderer = GetComponent<MeshRenderer>();
        ammoCount = 0f;
        _stat.AddHp(_stat.MaxHp);
    }

    private void Update()
    {
        // Player 이동
        _agent.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * (_speed * Time.deltaTime));

        // 마우스 포인터 방향으로 transform.forward
        Physics.Raycast(_cam.ScreenPointToRay(Input.mousePosition), out var raycastHit, _groundLayer);
        var dir = raycastHit.point - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));

        if (ammoCount <= 0)
            GetGun("handgnun(clone)");
    }

    public void Damage(float damageAmount)
    {
        if (!_isdamagable) return;
        StartCoroutine(DamageRoutine(damageAmount));
    }

    private IEnumerator DamageRoutine(float damageAmount)
    {
        _stat.AddHp(-damageAmount);

        foreach (var child in GetComponentsInChildren<MeshRenderer>())
            child.enabled = false;
        _renderer.enabled = false;
        _isdamagable = false;

        yield return new WaitForSeconds(noDamageTime / 6);

        foreach (var child in GetComponentsInChildren<MeshRenderer>())
            child.enabled = true;
        _renderer.enabled = true;

        yield return new WaitForSeconds(noDamageTime / 6);

        foreach (var child in GetComponentsInChildren<MeshRenderer>())
            child.enabled = false;
        _renderer.enabled = false;

        yield return new WaitForSeconds(noDamageTime / 6);

        foreach (var child in GetComponentsInChildren<MeshRenderer>())
            child.enabled = true;
        _renderer.enabled = true;

        yield return new WaitForSeconds(noDamageTime / 6);

        foreach (var child in GetComponentsInChildren<MeshRenderer>())
            child.enabled = false;
        _renderer.enabled = false;

        yield return new WaitForSeconds(noDamageTime / 6);

        foreach (var child in GetComponentsInChildren<MeshRenderer>())
            child.enabled = true;
        _renderer.enabled = true;
        _isdamagable = true;
    }

    public void GetGun(string gunName)
    {
        if (transform.childCount > 2)
            for (int i = 2; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.SetActive(false);
        if (ammoCount <= 0)
            gunName = "handgun(clone)";
        if (gunName == "riflegun(clone)")
        {
            _stat.setRate(0.1f);
            _stat.setPower(1f);
        }
        else if (gunName == "shotgun(clone)")
        {
            _stat.setRate(1.5f);
            _stat.setPower(5f);
        }
        else
        {
            _stat.setRate(1f);
            _stat.setPower(1f);
        }

        LastGun = gunName;

        var gunObj = ObjectPoolManager.Instance.Spawn(gunName);
        Destroy(gunObj.GetComponent<Rigidbody>());
        Destroy(gunObj.GetComponent<BoxCollider>());
        gunObj.transform.position = transform.GetChild(1).transform.position;
        gunObj.transform.rotation = transform.GetChild(1).transform.rotation;
        gunObj.transform.SetParent(transform);
    }

    public int killZombie()
    {
        killZombieCount++;
        return remainingZombies--;
    }
}
