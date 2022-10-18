using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Gage : IGage<float>
{
	private float _value = 0f;
	private float _maxValue = 100f;
	private float _minValue = 0f;
	private float _duration = 100f;

	public float Value => _value;

	public float MaxValue => _maxValue;

	public float MinValue => _minValue;

	public float Percentage => (_value - _minValue) / _duration;

	public float Add(float value)
	{
		_value += value;

		if (_value > _maxValue)
			_value = _maxValue;
		else if (_value < _minValue)
			_value = _minValue;

		return _value;
	}

	public void SetMax(float value)
	{
		_maxValue = value;
		_duration = _maxValue - _minValue;
		Assert.IsTrue(_duration > 0);
	}

	public void SetMin(float value)
	{
		_minValue = value;
		_duration = _maxValue - _minValue;
		Assert.IsTrue(_duration > 0);
	}

	public void SetValue(float value)
	{
		_value = value;

		if (_value > _maxValue)
			_value = _maxValue;
		else if (_value < _minValue)
			_value = _minValue;
	}
}
