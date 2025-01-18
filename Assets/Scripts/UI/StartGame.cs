using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartGameUI : MonoBehaviour
{
    public void LoadingGame()
    {
        SceneManager.LoadScene("Bubble Killer");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
