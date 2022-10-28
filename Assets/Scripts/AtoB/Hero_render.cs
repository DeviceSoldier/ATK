using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hero_render : MonoBehaviour
{
    public GameObject hero;
    public float Timer;
 
    void Start()
    {
        //Sphereオブジェクトを取得
        hero = GameObject.Find("Hero");
    }
 
    void Update()
    {
        Timer += Time.deltaTime;
        
        if (Timer >= 20.0f)
        {
            hero.GetComponent<Hero_active>().heroActive();
        }
        
        if (Timer >= 30.0f)
        {
            hero.GetComponent<Hero_active>().heroHide();
        }
    }
}
