using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
public class DebugTimelineDisplay : MonoBehaviour
{
	private GUIStyle style = new GUIStyle();
	private Rect rect = new Rect(20, 20, 100, 100);
	private PhaseManager phaseManager;

	private void Start()
	{
		style.fontSize = 32;
		style.normal.textColor = Color.red;
		phaseManager = FindObjectOfType<PhaseManager>();
	}

	private void OnGUI()
	{
		GUI.Label(rect, $"{phaseManager.StateMachine.CurrentNodeId}:{((int)Timeline.CurrentTime).ToString()}", style);
	}
}
#endif