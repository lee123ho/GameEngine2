using KPU.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploObject : MonoBehaviour, IDamageable
{
    private Canvas_UI _canvas;
    private objectSlider_UI _objectHealthBar;
    private GameObject _particle;
    private MeshRenderer[] _renderer;
    private string[] _hitExplo = { "player", "Enemy" };
    public Vector2 _offset;
    public float exploRadius;

    [SerializeField] private Stat _stat;

    public Stat Stat => _stat;

    private void Update()
    {
        if (_stat.Hp == 0)
        {
            Explosion();
            _objectHealthBar.gameObject.SetActive(false);
            enabled = false;
        }
    }

    private void OnEnable()
    {
        _renderer = GetComponentsInChildren<MeshRenderer>();
        _stat.AddHp(_stat.MaxHp);

        var objectHealthBarGameObject = ObjectPoolManager.Instance.Spawn("objectslider");
        _objectHealthBar = objectHealthBarGameObject.GetComponent<objectSlider_UI>();
        _canvas = FindObjectOfType<Canvas_UI>();
        _objectHealthBar.Initialize(this, _canvas.GetComponent<Canvas>(), _offset);
        _objectHealthBar.transform.parent = _canvas.transform;
        if (_stat.Hp != _stat.MaxHp)
            _objectHealthBar.gameObject.SetActive(true);
    }

    private void Explosion()
    {
        _particle = ObjectPoolManager.Instance.Spawn("exploparticle");
        _particle.transform.position = transform.position;
        _particle.SetActive(true);

        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, exploRadius, Vector3.up, 0f, LayerMask.GetMask(_hitExplo));
        foreach(var rayhit in rayHits)
        {
            if (rayhit.transform.GetComponent<NormalEnemy>() != null)
                rayhit.transform.GetComponent<NormalEnemy>().Damage(5f);
            else if (rayhit.transform.GetComponent<RangeEnemy>() != null)
                rayhit.transform.GetComponent<RangeEnemy>().Damage(5f);
            else if (rayhit.transform.GetComponent<TankEnemy>() != null)
                rayhit.transform.GetComponent<TankEnemy>().Damage(5f);
            else if (rayhit.transform.GetComponent<Player>() != null)
                rayhit.transform.GetComponent<Player>().Damage(5f);
        }

        foreach (var material in _renderer)
            material.material.color = Color.black;

    }

    public void Damage(float damageAmount)
    {
        _stat.AddHp(-damageAmount);
    }
}