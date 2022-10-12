using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour
{
    public static float CurrentTime { get; private set; } = 0f;
    public static bool Paused { get; private set; } = true;

    private static Timeline Instance;

    public static void StartTimer()
    {
        Paused = false;
    }

    public static void PauseTimer()
    {
        Paused = true;
    }

    public static void StopTimer()
    {
        Paused = true;
        CurrentTime = 0f;
    }

    public static void RestartTimer()
    {
        CurrentTime = 0f;
        Paused = false;
    }

    public static void ResetTimer()
    {
        CurrentTime = 0f;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        if (Paused)
            return;
        CurrentTime += Time.deltaTime;
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
