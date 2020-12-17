using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class explosion : MonoBehaviour
{
    private Coroutine _LifeTime;

    private void OnEnable()
    {
        _LifeTime = StartCoroutine(LifeTime());
    }

    private void OnDisable()
    {
        StopCoroutine(_LifeTime);
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
