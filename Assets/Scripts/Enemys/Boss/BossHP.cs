using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : HPObject
{
    public GameObject deleteobj;
    protected override void OnHpZero()
    {
        Destroy(deleteobj);
    }
}
