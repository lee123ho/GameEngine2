using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _player.GetGun(gameObject.name.ToLower());
            gameObject.SetActive(false);
        }
    }
}
