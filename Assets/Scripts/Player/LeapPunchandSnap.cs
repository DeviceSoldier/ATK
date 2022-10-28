using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapPunchandSnap : MonoBehaviour
{
    
    private Vector3 prevPosition;
    private Vector3 velocity;

    public GameObject Enemy;
    public GameObject Bullet;
    public float hitcount;
    public GameObject bullets;
    public GameObject fire;
    void Start()
    {
        prevPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.deltaTime, 0))
            return;
        var position = transform.position;
        velocity = (position - prevPosition) / Time.deltaTime;
        prevPosition = position;
        print($"velocity = {velocity.magnitude}");
    }
    private void OnCollisionEnter(Collision collision)
    {
        

        if(collision.gameObject.tag == "Bullet")
        {
            if (velocity.magnitude >= hitcount)
            {
                var pos = this.gameObject.transform.position;
                var t = Instantiate(Bullet) as GameObject;
                t.transform.position = pos;
                Vector3 vec = Enemy.transform.position - pos;
            }
        }
        if (CompareTag("Enemy"))
        {
            if (velocity.magnitude >= hitcount)
            {
                Destroy(collision.gameObject);
                var pos = this.gameObject.transform.position;
            
                var t = Instantiate(fire) as GameObject;
                t.transform.position = pos;
            
                Vector3 vec = bullets.transform.position - pos;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Enemy"))
        {
            if (velocity.magnitude >= hitcount)
            {
                Destroy(other.gameObject);
                var pos = this.gameObject.transform.position;
            
                var t = Instantiate(fire) as GameObject;
                t.transform.position = pos;
            
                Vector3 vec = bullets.transform.position - pos;
            }
        }
    }
}
