using System;
using System.Collections;
using System.Collections.Generic;
using Nissensai2022.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartCallback : MonoBehaviour
{
    public void OnGameStart()
    {
        SceneManager.LoadScene("TestScene");
    }
}
