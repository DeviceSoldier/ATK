using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AtoB_doragon : MonoBehaviour
{
    [SerializeField] private Transform phaseAtoBStartPoint;
    private GameObject AtoB_a;
    private GameObject AtoB_b;
    public float speed;
    public bool up;
    public bool down;
    void Start()
    {
        AtoB_a = GameObject.Find("AtoB_A");
        AtoB_b = GameObject.Find("AtoB_B");
        transform.position = phaseAtoBStartPoint.position;
        up = true;
        down = false;
        speed = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (up == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(AtoB_a.transform.position.x, AtoB_a.transform.position.y, AtoB_a.transform.position.z), speed * Time.deltaTime);
        }

        if (down == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(AtoB_b.transform.position.x, AtoB_b.transform.position.y, AtoB_b.transform.position.z), speed * Time.deltaTime);
            up = false;
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("up"))
        {
            up = false;
            down = true;
            speed = 100f;
        }

        if (col.CompareTag("down"))
        {
            down = false;
            down = false;
            speed = 0f;
        }
    }
}
