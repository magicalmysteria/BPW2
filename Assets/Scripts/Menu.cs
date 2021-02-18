using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnRestart()
    {
        SceneManager.LoadScene("Menu");
    }
}
