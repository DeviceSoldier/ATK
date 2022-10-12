using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseA_EndMove_A_Test : MonoBehaviour
{
    public GameObject Doragon;
    public GameObject DoragonBullet;
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Enemy")
        {
            Doragon.GetComponent<Doragon_Move_A_Test>().enabled = false;
            DoragonBullet.GetComponent<Doragon_Attack_A_Test>().enabled = false;
            Player.GetComponent<PhaseA_TargetLook>().enabled = false;
            Player.GetComponent<PlayerMove_1005>().enabled = true;
            Player.GetComponent<PhaseA_PhaseB>().enabled = true;
        }
    }
}
