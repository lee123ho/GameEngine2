using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class StageSelect : MonoBehaviour, GameInputActions.INumberActions
{
    private GameInputActions _inputActions;
    private Player _player;

    private bool _stage1;
    private bool _stage2;
    private bool _stage3;

    private GameObject[] _spawnSpot;

    private void OnEnable()
    {
        if (_inputActions == null)
            _inputActions = new GameInputActions();

        _inputActions.Number.SetCallbacks(this);
        _inputActions.Enable();
    }

    private void Start()
    {
        _spawnSpot = GameObject.FindGameObjectsWithTag("Respawn");
        _player = GetComponent<Player>();
        _player.remainingZombies = 20;
    }

    private void Update()
    {
        if (_player.killZombieCount == 20)
        {
            _stage1 = true;
            _player.stageNum = 1;
            Move();
            _player.killZombieCount++;
        }

        if(_player.killZombieCount == 50)
        {
            _stage2 = true;
            _player.stageNum = 2;
            Move();
            _player.killZombieCount++;
        }
    }

    // Update is called once per frame
    void Move()
    {
        if (_stage1)
        {
            _player.remainingZombies = 30;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            transform.position = _spawnSpot[0].transform.position;
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            _stage1 = false;
        }

        if (_stage2)
        {
            _player.remainingZombies = 50;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            transform.position = _spawnSpot[1].transform.position;
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            _stage2 = false;
        }

        if (_stage3)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            transform.position = _spawnSpot[2].transform.position;
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            _stage3 = false;
        }
    }

    public void OnStage1(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _player.GetGun("riflegun(clone)");
            _player.ammoCount = 999;
        }
    }

    public void OnStage2(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            _player.killZombie();
    }

    public void OnStage3(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            _stage3 = true;
        else
            _stage3 = false;
    }
}
