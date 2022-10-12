using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doragon_Move_A_Test : MonoBehaviour
{
    public float spinspeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, spinspeed, 0));
    }
}
