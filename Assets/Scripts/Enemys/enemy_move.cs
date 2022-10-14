using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemy_move : MonoBehaviour
{
    private GameObject target;  //追うターゲット
    public float speed;         //移動速度
    public bool dead;           //オブジェクトの消去

    void Start()
    {
        dead = false;
        target = GameObject.Find("PlayerOBJ");
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
