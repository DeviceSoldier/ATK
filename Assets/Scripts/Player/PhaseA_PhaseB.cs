using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseA_PhaseB : MonoBehaviour
{
    [SerializeField] private Vector3 phaseBPos= new Vector3(495,3.26f,50f);

    [SerializeField] private Transform phaseBStartPoint;
    [SerializeField] private Transform phaseCStartPoint;
    
    void Start()
    {
        //transform.position = phaseBPos;
        //transform.LookAt(phaseBPos+Vector3.forward);
        transform.position = phaseBStartPoint.position;
        transform.LookAt(phaseCStartPoint.position);
    }

}
