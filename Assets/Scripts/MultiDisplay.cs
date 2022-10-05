using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDisplay : MonoBehaviour
{
    void Start()
    {
        foreach(var display in Display.displays)
            display.Activate();
    }
}
