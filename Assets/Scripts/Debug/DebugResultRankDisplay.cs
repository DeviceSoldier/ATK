using System.Collections;
using System.Collections.Generic;
using Nissensai2022.Runtime;
using UnityEngine;

#if UNITY_EDITOR
public class DebugResultRankDisplay : MonoBehaviour
{
    private GUIStyle style = new GUIStyle();
    private Rect rect = new Rect(1520, 20, 400, 100);

    private void Start()
    {
        style.fontSize = 32;
        style.normal.textColor = Color.red;
    }

    private void OnGUI()
    {
        if (ResultHandler.IsReady)
            GUI.Label(rect,
                $"Result: {ResultHandler.Rank} ({ResultHandler.Result.ToString("0.0")}/{(ResultHandler.Percentage * 100f).ToString("0.00")}%)",
                style);
    }
}
#endif