using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("MainMenuSound");
        FindObjectOfType<AudioManager>().Loop("MainMenuSound");

    }
    public void StartGame()
    {
        //SaveManager.instance.playerLives = 3;
        PlayerPrefs.DeleteKey("Score");
        SceneManager.LoadScene("Level 1");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
