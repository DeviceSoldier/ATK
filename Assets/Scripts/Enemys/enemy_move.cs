using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    public GameObject target;  //�ǂ��^�[�Q�b�g
    public float speed;         //�ړ����x
    public bool dead;           //�I�u�W�F�N�g�̏���

    void Start()
    {
        speed = 9.5f;
        dead = false;
    }
    void Update()
    {
        if (dead == false)
        {
            transform.LookAt(target.transform);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            dead = true;
        }
    }
}
