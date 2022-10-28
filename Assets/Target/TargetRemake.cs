using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRemake : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Guard"))
        {
            transform.Rotate(new Vector3(speed, 0, 0));
            Invoke("Okiagari",2f);
        }
        if(other.CompareTag("Leftarm"))
        {
            transform.Rotate(new Vector3(speed, 0, 0));
            Invoke("Okiagari",2f);
        }
    }

    void Okiagari()
    {
        transform.Rotate(new Vector3(-speed,0,0));
    }
}
