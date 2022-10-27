using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_active : MonoBehaviour
{
    public void heroActive()
    {
        gameObject.SetActive (true);//表示
    }
 
    public void heroHide()
    {
        gameObject.SetActive (false);//非表示
    }
}
