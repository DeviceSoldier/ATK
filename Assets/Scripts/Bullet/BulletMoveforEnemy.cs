using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveforEnemy : MonoBehaviour
{
    private GameObject target;
    public float speed;
    void Start()
    {
        target = GameObject.Find("Chest");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.position += transform.forward * speed;
    }
}
