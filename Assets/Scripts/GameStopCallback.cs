using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nissensai2022.Runtime;
using UnityEngine.SceneManagement;

public class GameStopCallback : MonoBehaviour
{
    public void OnGameStop()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
