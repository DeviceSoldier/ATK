using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLock : MonoBehaviour
{
    // �Œ肷��fps�̐�������
    public int fpslock;
    // �Œ肷��fps�̐�������
    void Start()
    {
        // fpslock�œ��ꂽ���l��fps�ŌŒ肷��
        Application.targetFrameRate = fpslock;
        // fpslock�œ��ꂽ���l��fps�ŌŒ肷��
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
