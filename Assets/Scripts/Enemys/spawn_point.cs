using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_point : MonoBehaviour
{
    public Transform target;
    public GameObject enemy;
    public GameObject obj;
    public Vector3 offset;
    public float spawn_time;
    public float spawn_timing;
    public bool spawn = false;
    public float delete;

    void Update()
    {
        spawn_time += 1 * Time.deltaTime;
        delete += 1 * Time.deltaTime;

        if (spawn_time >= 20)
        {
            spawn = true;
            spawn_time = 0;
        }

        if (spawn == true)
        {
            this.transform.position = target.position + offset;
            if (spawn_time >= spawn_timing)
            {
                obj = (GameObject)Instantiate(enemy, this.transform.position, Quaternion.identity);
                obj.transform.parent = this.transform;
                spawn_time = 0;
            }
        }

        if (delete >= 39)
        {
            Destroy(this.gameObject);
        }
    }

}
