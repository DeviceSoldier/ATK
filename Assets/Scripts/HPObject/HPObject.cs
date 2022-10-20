using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HPObject : MonoBehaviour
{
    [SerializeField] protected float maxHp;
    [SerializeField] protected bool godMode;

    private Gage _gage = new Gage();
    public float Hp => _gage.Value;
    public float MaxHp => _gage.MaxValue;

    protected abstract void OnHpZero();

    public virtual void TakeDamage(float damage)
    {
        if (godMode)
            return;

        _gage.Add(-damage);
        if (Hp > 0)
            return;
        
        _gage.SetValue(0);
        OnHpZero();
    }

    protected void SetGodMode(bool god)
    {
        this.godMode = god;
    }

    protected virtual void Awake()
    {
        _gage.SetMax(maxHp);
        _gage.SetMin(0);
        _gage.SetValue(maxHp);
    }
}