using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float speed;
    void Start()
    {
        Invoke("Dead",4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,0,speed)*Time.deltaTime;

        
    }

    void Dead()
    {
        Application.Quit();
    }
}
