using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
public class DebugPlayerGageDisplay : MonoBehaviour
{
	private GUIStyle style = new GUIStyle();
	private Rect rect = new Rect(20, 120, 800, 100);
	private PlayerGage playerGage;

	private void Start()
	{
		style.fontSize = 32;
		style.normal.textColor = Color.red;
		playerGage = FindObjectOfType<PlayerGage>();
	}

	private void OnGUI()
	{
		GUI.Label(rect, $"{playerGage.gage.Value.ToString("0.00")}/{playerGage.gage.MaxValue.ToString("0.00")}({(playerGage.gage.Percentage * 100f).ToString("0.00")}%)", style);
	}
}
#endif