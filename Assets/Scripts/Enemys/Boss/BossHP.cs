using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : HPObject
{
    protected override void OnHpZero()
    {
        Destroy(gameObject);
    }
}
