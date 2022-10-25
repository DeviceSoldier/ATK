using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spder_Dead : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0)*Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
