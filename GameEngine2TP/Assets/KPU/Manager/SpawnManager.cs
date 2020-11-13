using System.Collections;
using KPU.Manager;
using UnityEngine;
using UnityEngine.AI;


namespace KPU.Manager
{
    public class SpawnManager : SingletonBehaviour<SpawnManager>
    {
        private void Start()
        {
            var barriers = GameObject.FindGameObjectsWithTag("ObstacleSP");
            foreach (var p in barriers)
            {
                ObjectPoolManager.Instance.Spawn("barrier", p.transform.position, new Quaternion(0f, Random.value, 0f, p.transform.rotation.w));
            }
        }
    }
}
