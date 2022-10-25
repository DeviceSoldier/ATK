using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHit : MonoBehaviour
{
    private BossHP _bossHp;
    public float hitdamage;

    private void Start()
    {
        _bossHp = FindObjectOfType<BossHP>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // todo ダメージの当たり判定
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            _bossHp.TakeDamage(hitdamage);
            FindObjectOfType<PlayerGage>().gage.Add(0.04f);
        }
        
        if (collision.gameObject.CompareTag("Leftarm")||collision.gameObject.CompareTag("Guard"))
        {
            _bossHp.TakeDamage(hitdamage);
            collision.gameObject.GetComponentInParent<PlayerGage>().gage.Add(0.04f);
        }
    }
}
