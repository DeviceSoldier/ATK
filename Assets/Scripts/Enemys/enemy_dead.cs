using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_dead : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
           Destroy(this.gameObject);
        }
    }
}
