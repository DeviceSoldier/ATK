using System.Collections;
using System.Collections.Generic;
using Nissensai2022.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStopCallback : MonoBehaviour
{
    public void OnGameStop()
    {
        SceneManager.LoadScene("OutGame");
    }
}
