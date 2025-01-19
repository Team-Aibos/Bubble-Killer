using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void LoadingGame()
    {
        SceneManager.LoadScene("Start Scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}