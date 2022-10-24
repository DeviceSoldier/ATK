using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_dead2 : MonoBehaviour
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
        if(col.CompareTag("Guard"))
        {
            Destroy(this.gameObject,2f);
        }

        if (col.CompareTag("Leftarm"))
        {
            Destroy(this.gameObject);
        }
    }
}
