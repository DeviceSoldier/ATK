using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_spawn : MonoBehaviour
{
    public float spawnTime;
    public GameObject Hero;
    void Start()
    {
        Instantiate(Hero, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= 1.0f)
        {
            //Instantiate(Hero, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
