using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
public class DebugBossHPDisplay : MonoBehaviour
{
    private HPObject _hpObject;
    private GUIStyle style = new GUIStyle();
    private Rect rect = new Rect( Screen.width/2f, 20, 100, 100);

    private void Start()
    {
        _hpObject = FindObjectOfType<BossHP>();
        style.fontSize = 32;
        style.normal.textColor = Color.red;
    }

    private void OnGUI()
    {
        GUI.Label(rect, ((int)_hpObject.hp).ToString(), style);
    }
}
#endif