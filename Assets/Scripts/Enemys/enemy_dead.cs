using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_dead : MonoBehaviour
{
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
