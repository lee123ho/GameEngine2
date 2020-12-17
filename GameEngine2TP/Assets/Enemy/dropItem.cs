using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropItem : MonoBehaviour
{
    private int _result;
    public string itemName;
    private void Awake()
    {
        _result = Random.Range(0, 2);
        if (_result == 0)
        {
            _result = Random.Range(0, 6);
            if (_result == 0)
                itemName = "handgun(clone)";
            else if (_result == 1)
                itemName = "riflegun(clone)";
            else if (_result == 2)
                itemName = "shotgun(clone)";
        }
        else
        {
            _result = Random.Range(0, 10);
            if (_result == 0 || _result == 1 || _result == 2 || _result == 3 || _result == 4)
                itemName = "bullet";
            else if (_result == 5 || _result == 6)
                itemName = "healpack";
        }
    }

    public string getItemName()
    {
        return itemName;
    }
}
