using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doragon_Attack_A_Test : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;

    public float ReSpawnTime;
    private float currentTime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        currentTime += Time.deltaTime;
        if (ReSpawnTime < currentTime)
        {
            currentTime = 0;
            
            var pos = this.gameObject.transform.position;
            
            var t = Instantiate(Bullet) as GameObject;
            
            t.transform.position = pos;
            
            Vector3 vec = Player.transform.position - pos;
            
            t.GetComponent<Rigidbody>().velocity = vec;
        }
    }
}
