using KPU.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoundChecker : MonoBehaviour
{
    private Player _player;
    private int _result;
    private int zombieCount;
    public float spawnTime = 5f;
    private float _time;

    private GameObject[] s1;
    private GameObject[] s2;
    private GameObject[] s3;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        s1 = GameObject.FindGameObjectsWithTag("s1_sp");
        s2 = GameObject.FindGameObjectsWithTag("s2_sp");
        s3 = GameObject.FindGameObjectsWithTag("s3_sp");
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time > spawnTime)
        {
            _result = UnityEngine.Random.Range(0, 4);
            if (_player.stageNum == 0)
            {
                if (_result == 0)
                {
                    var normalenemy = ObjectPoolManager.Instance.Spawn("enemy_normal");
                    normalenemy.GetComponent<NavMeshAgent>().enabled = false;
                    normalenemy.SetActive(true);
                    _result = UnityEngine.Random.Range(0, 4);
                    normalenemy.transform.position = s1[0].transform.position;
                    normalenemy.GetComponent<NavMeshAgent>().enabled = true;
                }
                else if (_result == 1)
                {
                    var rangeenemy = ObjectPoolManager.Instance.Spawn("enemy_range");
                    rangeenemy.GetComponent<NavMeshAgent>().enabled = false;
                    rangeenemy.SetActive(true);
                    _result = UnityEngine.Random.Range(0, 4);
                    rangeenemy.transform.position = s1[_result].transform.position;
                    rangeenemy.GetComponent<NavMeshAgent>().enabled = true;
                }
                else if (_result == 2)
                {
                    var tankenemy = ObjectPoolManager.Instance.Spawn("enemy_tank");
                    tankenemy.GetComponent<NavMeshAgent>().enabled = false;
                    tankenemy.SetActive(true);
                    _result = UnityEngine.Random.Range(0, 4);
                    tankenemy.transform.position = s1[_result].transform.position;
                    tankenemy.GetComponent<NavMeshAgent>().enabled = true;
                } 
            }

            if (_player.stageNum == 1)
            {
                spawnTime = 2.5f;
                if (_result == 0)
                {
                    var normalenemy = ObjectPoolManager.Instance.Spawn("enemy_normal");
                    normalenemy.GetComponent<NavMeshAgent>().enabled = false;
                    normalenemy.SetActive(true);
                    _result = UnityEngine.Random.Range(0, 4);
                    normalenemy.transform.position = s2[0].transform.position;
                    normalenemy.GetComponent<NavMeshAgent>().enabled = true;
                }
                else if (_result == 1)
                {
                    var rangeenemy = ObjectPoolManager.Instance.Spawn("enemy_range");
                    rangeenemy.GetComponent<NavMeshAgent>().enabled = false;
                    rangeenemy.SetActive(true);
                    _result = UnityEngine.Random.Range(0, 4);
                    rangeenemy.transform.position = s2[_result].transform.position;
                    rangeenemy.GetComponent<NavMeshAgent>().enabled = true;
                }
                else if (_result == 2)
                {
                    var tankenemy = ObjectPoolManager.Instance.Spawn("enemy_tank");
                    tankenemy.GetComponent<NavMeshAgent>().enabled = false;
                    tankenemy.SetActive(true);
                    _result = UnityEngine.Random.Range(0, 4);
                    tankenemy.transform.position = s2[_result].transform.position;
                    tankenemy.GetComponent<NavMeshAgent>().enabled = true;
                }
            }

            if (_player.stageNum == 2)
            {
                spawnTime = 1f;
                if (_result == 0)
                {
                    var normalenemy = ObjectPoolManager.Instance.Spawn("enemy_normal");
                    normalenemy.GetComponent<NavMeshAgent>().enabled = false;
                    normalenemy.SetActive(true);
                    _result = UnityEngine.Random.Range(0, 7);
                    normalenemy.transform.position = s3[0].transform.position;
                    normalenemy.GetComponent<NavMeshAgent>().enabled = true;
                }
                else if (_result == 1)
                {
                    var rangeenemy = ObjectPoolManager.Instance.Spawn("enemy_range");
                    rangeenemy.GetComponent<NavMeshAgent>().enabled = false;
                    rangeenemy.SetActive(true);
                    _result = UnityEngine.Random.Range(0, 7);
                    rangeenemy.transform.position = s3[_result].transform.position;
                    rangeenemy.GetComponent<NavMeshAgent>().enabled = true;
                }
                else if (_result == 2)
                {
                    var tankenemy = ObjectPoolManager.Instance.Spawn("enemy_tank");
                    tankenemy.GetComponent<NavMeshAgent>().enabled = false;
                    tankenemy.SetActive(true);
                    _result = UnityEngine.Random.Range(0, 7);
                    tankenemy.transform.position = s3[_result].transform.position;
                    tankenemy.GetComponent<NavMeshAgent>().enabled = true;
                }
            }
            _time = 0f;
            zombieCount++;
        }
    }
}
