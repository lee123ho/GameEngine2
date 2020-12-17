using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemySlider_UI : MonoBehaviour
{
    private Slider _slider;
    private RectTransform _rectTransform;
    private Camera _camera;
    private Canvas _canvas;
    private NormalEnemy _normalEnemy;
    private RangeEnemy _rangeEnemy;
    private TankEnemy _tankEnemy;
    private Vector2 _offset;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _rectTransform = GetComponent<RectTransform>();
        _camera = FindObjectOfType<Camera>();
    }

    public void Initialize(NormalEnemy normalEnemy, Canvas canvas, Vector2 offset)
    {
        _normalEnemy = normalEnemy;
        _canvas = canvas;
        _offset = offset;

        _slider.maxValue = _normalEnemy.Stat.MaxHp;
        _slider.value = _normalEnemy.Stat.Hp;
    }
    public void Initialize(RangeEnemy rangeEnemy, Canvas canvas, Vector2 offset)
    {
        _rangeEnemy = rangeEnemy;
        _canvas = canvas;
        _offset = offset;

        _slider.maxValue = _rangeEnemy.Stat.MaxHp;
        _slider.value = _rangeEnemy.Stat.Hp;
    }
    public void Initialize(TankEnemy tankEnemy, Canvas canvas, Vector2 offset)
    {
        _tankEnemy = tankEnemy;
        _canvas = canvas;
        _offset = offset;

        _slider.maxValue = _tankEnemy.Stat.MaxHp;
        _slider.value = _tankEnemy.Stat.Hp;
    }

    private void Update()
    {
        if (_normalEnemy != null)
        {
            _slider.value = _normalEnemy.Stat.Hp;
            var point = _camera.WorldToViewportPoint(_normalEnemy.transform.position);
            var canvasHeight = _canvas.pixelRect.width;
            var canvasWidth = _canvas.pixelRect.height;
            _rectTransform.anchoredPosition = new Vector2(canvasHeight * point.x + _offset.x, canvasWidth * point.y + _offset.y);
        }
        if (_rangeEnemy != null)
        {
            _slider.value = _rangeEnemy.Stat.Hp;
            var point = _camera.WorldToViewportPoint(_rangeEnemy.transform.position);
            var canvasHeight = _canvas.pixelRect.width;
            var canvasWidth = _canvas.pixelRect.height;
            _rectTransform.anchoredPosition = new Vector2(canvasHeight * point.x + _offset.x, canvasWidth * point.y + _offset.y);
        }

        if (_tankEnemy != null)
        {
            _slider.value = _tankEnemy.Stat.Hp;
            var point = _camera.WorldToViewportPoint(_tankEnemy.transform.position);
            var canvasHeight = _canvas.pixelRect.width;
            var canvasWidth = _canvas.pixelRect.height;
            _rectTransform.anchoredPosition = new Vector2(canvasHeight * point.x + _offset.x, canvasWidth * point.y + _offset.y);
        }
    }
}
