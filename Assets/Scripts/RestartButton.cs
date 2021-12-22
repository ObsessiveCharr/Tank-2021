using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
        SaveManager.instance.playerLives = 3;
        SceneManager.LoadScene("Level 1");
    }
    public void MainMenu()
    {
        SaveManager.instance.playerLives = 3;
        SceneManager.LoadScene("MainMenu");
    }
}
