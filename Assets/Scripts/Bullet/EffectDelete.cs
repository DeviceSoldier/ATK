using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDelete : MonoBehaviour
{
    public float Breaktime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Breakeffect",Breaktime);
    }

    
    void Breakeffect()
    {
        Destroy(this.gameObject);
    }
}
