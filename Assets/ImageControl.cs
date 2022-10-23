using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageControl : MonoBehaviour
{
    float alfa;
    float speed = 0.25f;
    float red, green, blue;

    void Start () {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }

    void Update () {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa += speed*Time.deltaTime;
    }
}
