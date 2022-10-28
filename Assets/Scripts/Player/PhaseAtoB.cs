using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseAtoB : MonoBehaviour
{
    public float timer;
    public GameObject target;
    public bool positionA;
    public bool positionB;
    public bool positionC;
    public bool positionD;

    [SerializeField] private Transform PositionA;
    [SerializeField] private Transform PositionB;
    [SerializeField] private Transform PositionC;
    [SerializeField] private Transform PositionD;
    
    void Start()
    {
        //transform.position = PositionA.position;
        target = GameObject.Find("Hero");

        positionA = true;
        positionB = false;
        positionC = false;
        positionD = false;
    }
    void Update()
    {
        transform.LookAt(target.transform);

        timer += Time.deltaTime;

        if (timer >= 3)
        {
            positionA = false;
            positionB = true;
        }
        else if (timer >= 6)
        {
            positionB = false;
            positionC = true;
        }
        else if(timer >= 8)
        {
            positionC = false;
            positionD = true;
        }
        else
        {
            positionD = false;
        }

        
        
        if (positionA == true)
        {
            transform.position = PositionA.position;
        }
        
        if (positionB == true)
        {
            transform.position = PositionB.position;
        }
        
        if (positionC == true)
        {
            transform.position = PositionC.position;
        }
        
        if (positionD == true)
        {
            transform.position = PositionD.position;
        }
    }
}
