using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AtoB_doragon : MonoBehaviour
{
    [SerializeField] private Transform phaseAtoBStartPoint;
    private GameObject A;
    private GameObject B;
    public float speed;
    public bool start;
    public bool end;
    void Start()
    {
        A = GameObject.Find("AtoB_A");
        B = GameObject.Find("AtoB_B");
        transform.position = phaseAtoBStartPoint.position;
        start = true;
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(A.transform.position.x, A.transform.position.y, A.transform.position.z), speed * Time.deltaTime);
        }

        if (end == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(B.transform.position.x, B.transform.position.y, B.transform.position.z), speed * Time.deltaTime);
            start = false;
        }
    }
}
