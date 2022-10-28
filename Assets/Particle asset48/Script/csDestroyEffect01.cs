using System;
using UnityEngine;
using System.Collections;

public class csDestroyEffect01 : MonoBehaviour {
    private void Start()
    {
        Invoke("effect",1f);
    }

    void effect()
    {
        Destroy(this.gameObject);
    }
}
