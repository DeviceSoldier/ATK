using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLock : MonoBehaviour
{
    // 固定するfpsの数を入れる
    public int fpslock;
    // 固定するfpsの数を入れる
    void Start()
    {
        // fpslockで入れた数値をfpsで固定する
        Application.targetFrameRate = fpslock;
        // fpslockで入れた数値をfpsで固定する
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
