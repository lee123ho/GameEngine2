using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectSlider_UI : MonoBehaviour
{
    private Slider _slider;
    private RectTransform _rectTransform;
    private Camera _camera;
    private Canvas _canvas;
    private exploObject _exploObject;
    private Vector2 _offset;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _rectTransform = GetComponent<RectTransform>();
        _camera = FindObjectOfType<Camera>();
    }

    public void Initialize(exploObject exploObject, Canvas canvas, Vector2 offset)
    {
        _exploObject = exploObject;
        _canvas = canvas;
        _offset = offset;

        _slider.maxValue = _exploObject.Stat.MaxHp;
    }

    private void Update()
    {
        if (_exploObject != null)
        {
            _slider.value = _exploObject.Stat.Hp;
            var point = _camera.WorldToViewportPoint(_exploObject.transform.position);
            var canvasHeight = _canvas.pixelRect.width;
            var canvasWidth = _canvas.pixelRect.height;
            _rectTransform.anchoredPosition = new Vector2(canvasHeight * point.x + _offset.x, canvasWidth * point.y + _offset.y);
        }
    }
}
