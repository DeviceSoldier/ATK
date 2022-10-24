using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseA_TargetLook : MonoBehaviour
{
    public GameObject Doragon;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Doragon.transform);
        var rotation = transform.rotation;
        var qua = Quaternion.Euler(0f, rotation.eulerAngles.y, rotation.eulerAngles.z);
        rotation = qua;
        transform.rotation = rotation;
    }
}