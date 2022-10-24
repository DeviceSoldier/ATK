using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OuttoTitle : MonoBehaviour
{
    public float time;
    void Start()
    {
        Invoke("SceneChange",time);
    }

    // Update is called once per frame
    void SceneChange()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
