using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _offSet;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = _target.transform.position;
        _offSet = new Vector3(-0.5f, 15.5f, -12.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _target.transform.position + _offSet;
    }
}
