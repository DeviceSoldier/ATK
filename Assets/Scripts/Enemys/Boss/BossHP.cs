using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : HPObject
{
    public GameObject deleteobj;
    public Slider Slider;
    
    protected override void OnHpZero()
    {
        Destroy(deleteobj);
    }

    private void Start()
    {
        Slider.maxValue = MaxHp;
    }

    private void Update()
    {
        Slider.value = Hp;
    }
}
