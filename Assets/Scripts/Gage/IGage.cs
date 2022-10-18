using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGage<T>
{
    public T Add(T value);
    public void SetValue(T value);
    public void SetMax(T value);
    public void SetMin(T value);
    public T Value { get; }
    public float Percentage { get; }

}
