using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBulletEffect : MonoBehaviour
{
    public GameObject bullet;
    public GameObject fire;
    void Start()
    {
        var pos = this.gameObject.transform.position;
            
        var t = Instantiate(fire) as GameObject;
        t.transform.position = pos;
            
        Vector3 vec = bullet.transform.position - pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
