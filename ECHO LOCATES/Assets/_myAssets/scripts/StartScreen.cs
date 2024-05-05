using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene: MonoBehaviour
{
    public string gamePlay;

    public void LoadLevel()
    {
        SceneManager.LoadScene(gamePlay);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}