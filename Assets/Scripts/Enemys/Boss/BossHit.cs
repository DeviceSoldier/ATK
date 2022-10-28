using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHit : MonoBehaviour
{
    private BossHP _bossHp;
    public float hitdamage;
    public GameObject bullets;
    public GameObject fire;

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
            var pos = this.gameObject.transform.position;
            
            var t = Instantiate(fire) as GameObject;
            t.transform.position = pos;
            
            Vector3 vec = bullets.transform.position - pos;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Leftarm")||collision.gameObject.CompareTag("Guard"))
        {
            Debug.Log("Attack");
            
        }
    }
}
