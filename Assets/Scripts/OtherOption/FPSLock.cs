using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLock : MonoBehaviour
{
    // ŒÅ’è‚·‚éfps‚Ì”‚ğ“ü‚ê‚é
    public int fpslock;
    // ŒÅ’è‚·‚éfps‚Ì”‚ğ“ü‚ê‚é
    void Start()
    {
        // fpslock‚Å“ü‚ê‚½”’l‚ğfps‚ÅŒÅ’è‚·‚é
        Application.targetFrameRate = fpslock;
        // fpslock‚Å“ü‚ê‚½”’l‚ğfps‚ÅŒÅ’è‚·‚é
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
