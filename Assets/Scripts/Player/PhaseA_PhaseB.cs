using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseA_PhaseB : MonoBehaviour
{
    [SerializeField] private Vector3 phaseBPos= new Vector3(495,3.26f,50f);
    // Start is called before the first frame update
    void Start()
    {
        transform.position = phaseBPos;
        transform.LookAt(phaseBPos+Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
