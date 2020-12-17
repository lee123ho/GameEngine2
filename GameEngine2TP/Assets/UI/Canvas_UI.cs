using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_UI : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _remainText;
    [SerializeField] private TextMeshProUGUI _gameEnd;
    [SerializeField] private Player _player;

    private void Start()
    {
        _slider.maxValue = _player.Stat.MaxHp;
    }

    private void Update()
    {
        _slider.value = _player.Stat.Hp;
        _text.text = $" Ammo : {_player.ammoCount}";
        _remainText.text = $"Remain : {_player.remainingZombies}";

        if (_player.Stat.Hp == 0)
        {
            transform.GetChild(2).gameObject.SetActive(true);
            _player.gameObject.SetActive(false);
        }

        if (_player.killZombieCount >= 100)
        {
            _gameEnd.text = "Victory!";
            transform.GetChild(2).gameObject.SetActive(true);
            _player.gameObject.SetActive(false);
        }
    }
}
