using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayerHealth : MonoBehaviour, IDamagePlayer
{
    public int playerLives = 3;
    public int maxPlayer = 1;
    //public GameObject[] hearts;
    private float spawnPosX = 3f;
    private float spawnPosZ = 11f;
    public GameObject playerPrefab;
    public ParticleSystem explosionEffect;
    public ParticleSystem shieldEffect;
    public ParticleSystem respawEffect;
    public Text playerLife;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawPoint;
    // Start is called before the first frame update
    void Start()
    {
        playerLives = SaveManager.instance.playerLives;
       
        ShieldPowerUp.shieldOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerLife.text = playerLives.ToString();
    }
    public void TakeDamage(int damage)
    {
        playerLives -= damage;
        //Destroy(hearts[playerLives].gameObject);
        //Debug.Log("Number of lives is : " + playerLives);
        SavePlayer();


        ParticleSystem destroyEffect = Instantiate(explosionEffect) as ParticleSystem;
        destroyEffect.transform.position = transform.position;
        
        SteelDestroyPowerUp.steelDestroy = false;
        if (playerLives == 5)
        {
            FindObjectOfType<AudioManager>().Play("Death");
            destroyEffect.Play();
            Destroy(destroyEffect.gameObject, 1);
            respawEffect.Play();
            respaw();
            //SpawnPlayer();
            //  Destroy(this.gameObject);

        }
        if (playerLives == 4)
        {
            FindObjectOfType<AudioManager>().Play("Death");
            destroyEffect.Play();
            respawEffect.Play();

            Destroy(destroyEffect.gameObject, 1);

            respaw();
            //   SpawnPlayer();
            //  Destroy(this.gameObject);

        }
        if (playerLives == 3)
        {
            FindObjectOfType<AudioManager>().Play("Death");
            destroyEffect.Play();
            Destroy(destroyEffect.gameObject, 1);
            respawEffect.Play();

            respaw();
            //  SpawnPlayer();
            Destroy(this.gameObject);


        }
        if (playerLives == 2)
        {
            FindObjectOfType<AudioManager>().Play("Death");
            destroyEffect.Play();
            Destroy(destroyEffect.gameObject, 1);
            respawEffect.Play();

            respaw();
            // SpawnPlayer();
            // Destroy(this.gameObject);

        }
        if (playerLives == 1)
        {
            FindObjectOfType<AudioManager>().Play("Death");
            destroyEffect.Play();
            Destroy(destroyEffect.gameObject, 1);
            respawEffect.Play();

            respaw();
           // SpawnPlayer();
          //  Destroy(this.gameObject);
        }
        if (playerLives <= 0)
        {
            FindObjectOfType<AudioManager>().Play("Death");
            destroyEffect.Play();
            Destroy(destroyEffect.gameObject, 1);
            //Debug.Log("Player is dead!");
            Destroy(this.gameObject);
            FindObjectOfType<GameManager>().GameOver();
        }



    }
    public void SpawnPlayer()
    {
        Vector3 spawnPos = new Vector3(-spawnPosX, 0, -spawnPosZ);
        Instantiate(playerPrefab, spawnPos, playerPrefab.transform.rotation);
    }
    public void SavePlayer()
    {
        //PlayerPrefs.SetInt("PlayerLives", playerLives);
        SaveManager.instance.playerLives = playerLives;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Shield")
        {
            shieldEffect.Play();
            StartCoroutine(stopEffect());
            // Destroy(shieldEffect.gameObject, 10);
            // ParticleSystem shield = Instantiate(shieldEffect) as ParticleSystem;
            // shield.transform.position = transform.position;
        }
        if (other.gameObject.tag == "Life")
        {
            if (playerLives < 5)
            {
                FindObjectOfType<AudioManager>().Play("PowerUp");
                playerLives++;
                playerLife.text = playerLives.ToString();
                Debug.Log(playerLives);
                SavePlayer();
                Destroy(other.gameObject);
            }
            else
            {

                Debug.Log(playerLives);
                Destroy(other.gameObject);
            }

        }
    }
    IEnumerator stopEffect()
    {
        yield return new WaitForSeconds(10);
        shieldEffect.Stop();
    }
    void respaw()
    {
        Player.transform.position = respawPoint.transform.position;
    }
}
