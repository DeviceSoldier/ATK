using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_move : MonoBehaviour
{
    public bool Run;
    public bool Jump;
    public bool Fall;
    public bool Landing;
    public float speed;
    private GameObject jumpPoint;
    private GameObject fallPoint;
    private GameObject landingPoint;
    void Start()
    {
        Run = true;
        Jump = false;
        Fall = false;
        Landing = false;
        jumpPoint = GameObject.Find("B");
        fallPoint = GameObject.Find("C");
        landingPoint = GameObject.Find("D");
    }

    // Update is called once per frame
    void Update()
    {
        if (Run == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(jumpPoint.transform.position.x, jumpPoint.transform.position.y, jumpPoint.transform.position.z), speed * Time.deltaTime);
        }
        
        if (Jump == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(fallPoint.transform.position.x, fallPoint.transform.position.y, fallPoint.transform.position.z), speed * Time.deltaTime);
        }
        
        if (Fall == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(landingPoint.transform.position.x, landingPoint.transform.position.y, landingPoint.transform.position.z), speed * Time.deltaTime);
        }
        
        if (Landing == true)
        {
            speed = 0.0f;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("jump"))
        {
            Run = false;
            Jump = true;
            speed = 50.0f;
        }
        
        if (col.CompareTag("fall"))
        {
            Jump = false;
            Fall = true;
            speed = 77.5f;
        }
        
        if (col.CompareTag("landing"))
        {
            Fall = false;
            Landing = true;
        }
    }
}
