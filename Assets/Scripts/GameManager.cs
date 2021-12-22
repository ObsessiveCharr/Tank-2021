using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public int score;
    //public int Highscore;
    public Text playerScore;
    public int enemyDeadCount;
    public Animator transition;
    public float transitionTime = 5f;
    public Text loadedLevel;
    
    
    

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("StartSound");
        loadedLevel.text = SceneManager.GetActiveScene().name.ToString();
        score = PlayerPrefs.GetInt("Score");
        playerScore.text = PlayerPrefs.GetInt("Score").ToString();
        
        
    }

    // Start is called before the first frame update
    private void Awake()
    {
        //loadedLevel.text = SceneManager.GetActiveScene().name.ToString();
        /*if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }*/
        instance = this;
    }
    private void Update()
    {
        if(enemyDeadCount == SpawnManager.maxEnemy)
        {
            
            SaveData();
            LoadNextLevel();
        }
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt("Score", score);
        
               
    }
    /*public void SavePlayer()
    {
        PlayerPrefs.SetInt("PlayerLives", playerHealth.playerLives);
    }*/

    public void AddScore()
    {
       score += 50;
       //enemyDeadCount += 1;
       playerScore.text = score.ToString();
       //PlayerPrefs.SetInt("HighScore", score);
       //PlayerPrefs.SetInt("Lives", playerHealth.playerLives);
    }
    public void EnemyCount()
    {
        enemyDeadCount += 1;
    }

    public void GameOver()
    {
        PlayerPrefs.DeleteKey("Score");
        SceneManager.LoadScene("GameOver");
    }
    public void LoadNextLevel()
    {
        
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);

    }
    /*public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        //SaveManager.instance.playerLives = 3;
        PlayerPrefs.DeleteKey("Score");
        SceneManager.LoadScene("Lvl1");
        
    }*/

}
