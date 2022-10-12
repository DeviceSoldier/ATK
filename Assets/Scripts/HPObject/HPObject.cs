using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HPObject : MonoBehaviour
{
    [SerializeField] protected float maxHp;
    public float hp { get; private set; }
    [SerializeField] protected bool godMode;

    protected abstract void OnHpZero();

    public virtual void TakeDamage(float damage)
    {
        if (godMode)
            return;
        
        hp -= damage;
        if (hp > 0)
            return;
        
        hp = 0;
        OnHpZero();
    }

    protected void SetGodMode(bool god)
    {
        this.godMode = god;
    }

    protected virtual void Awake()
    {
        hp = maxHp;
    }
}