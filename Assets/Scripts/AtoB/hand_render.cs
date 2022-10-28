using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand_render : MonoBehaviour
{
    public GameObject hand;
    public float Timer;
     
    void Start()
    {
        //Sphereオブジェクトを取得
        hand = GameObject.Find("Service Provider (Desktop)");
    }
    
    void Update()
    {
        Timer += Time.deltaTime; 
        if (Timer >= 20.0f) 
        { 
            hand.GetComponent<Hero_active>().heroHide();
        }
        
        if (Timer >= 30.0f) 
        { 
            hand.GetComponent<Hero_active>().heroActive();
        }
    }
}
