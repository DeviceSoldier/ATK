using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BossHP))]
public class BossHit : MonoBehaviour
{
    private BossHP _bossHp;

    private void Start()
    {
        _bossHp = gameObject.GetComponent<BossHP>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // todo ダメージの当たり判定
        if (collision.gameObject.CompareTag(""))
        {
            _bossHp.TakeDamage(1f);
        }
    }
}
