using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactScale : MonoBehaviour
{
    // Start is called before the first frame update


    public float size = 100f;
    public GameObject target;
    public Vector3 speed = new Vector3(2, 2, 2);

    void Update()
    {
        target.transform.localScale += speed * Time.deltaTime;

        if (target.transform.localScale.x > size && target.transform.localScale.y > size &&
            target.transform.localScale.z > size)
        {
            Destroy(this.gameObject);
        }
    }
}