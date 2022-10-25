using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpDown : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;
    [SerializeField] private Transform camerasTransform;
    [SerializeField] private float angleSpeed = 10f;
    [SerializeField] private float speed = 10f;
    private float _currentAngle = 0f;
    private float _targetAngle = 0f;
    private float _currentHeight = 0f;
    private float _targetHeight = 0f;

    public void SetTargetAngle(float value)
    {
        _targetAngle = value;
    }

    public void SetTargetHeight(float value)
    {
        _targetHeight = camerasTransform.position.y + value;
    }


    void UpdateAngle()
    {
        if (Mathf.Approximately(_currentAngle, _targetAngle))
            return;
        if (_currentAngle < _targetAngle)
        {
            _currentAngle += speed * Time.deltaTime;
            if (_currentAngle >= _targetAngle)
                _currentAngle = _targetAngle;
        }
        else
        {
            _currentAngle -= speed * Time.deltaTime;
            if (_currentAngle <= _targetAngle)
                _currentAngle = _targetAngle;
        }

        foreach (var cam in cameras)
        {
            var rotation = cam.transform.rotation.eulerAngles;
            rotation.x = _currentAngle;
            Debug.Log(rotation);
            cam.transform.rotation = Quaternion.Euler(rotation);
        }
    }

    void UpdateHeight()
    {
        _currentHeight = camerasTransform.position.y;
        Debug.Log($"{_currentHeight} {_targetHeight}");
        if (Mathf.Approximately(_currentHeight, _targetHeight))
            return;
        if (_currentHeight < _targetHeight)
        {
            _currentHeight += speed * Time.deltaTime;
            if (_currentHeight >= _targetHeight)
                _currentHeight = _targetHeight;
        }
        else
        {
            _currentHeight -= speed * Time.deltaTime;
            if (_currentHeight <= _targetHeight)
                _currentHeight = _targetHeight;
        }

        var pos = camerasTransform.position;
        pos.y = _currentHeight;
        camerasTransform.position = pos;
    }

    void Update()
    {
        UpdateAngle();
        UpdateHeight();
    }
}