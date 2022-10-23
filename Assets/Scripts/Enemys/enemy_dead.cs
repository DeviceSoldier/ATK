using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_dead : MonoBehaviour
{
    public float deadtime;

    private void Update()
    {
        deadtime += 1 * Time.deltaTime;
        if (deadtime >= 18)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Impact"))
        {
            Destroy(this.gameObject,2f);
        }

        if (col.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
