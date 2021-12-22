using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageabale
{
    public float health = 3.0f;
    public int scoreValue = 100;
    public ParticleSystem spawnEffect;
    public ParticleSystem destroyEffect;
    public GameObject[] powerUpPrefab;
    //public PlayerSpawnManager spawnPlayer;
    private float spawnPosX = 11.5f;
    private float spawnPosZ = 11f;

    //public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {        
        spawnEffect.Play();
    }
    public void TakeDamage(float damage)
    {
        ParticleSystem explosionEffect = Instantiate(destroyEffect) as ParticleSystem;
        explosionEffect.transform.position = transform.position;

        health -= damage;
        //Debug.Log(gameObject.name + " took " + damage + " damage. ");
        if(health <= 0)
        {
           
            if (Random.Range(0, 100) < 24)
            {
                SpawnPowerUp();
            }          
            FindObjectOfType<AudioManager>().Play("Death");
            explosionEffect.Play();
            Destroy(explosionEffect.gameObject, 1);
            //Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(this.gameObject);

            GameManager.instance.EnemyCount();
            
            
        }
        GameManager.instance.AddScore();
        
    }
    void SpawnPowerUp()
    {
        int powerUpIndex = Random.Range(0, powerUpPrefab.Length);

        Vector3 spawnPos = new Vector3(Random.Range(spawnPosX, -spawnPosX), 0.6f, Random.Range(spawnPosZ, -spawnPosZ));
        Instantiate(powerUpPrefab[powerUpIndex], spawnPos, powerUpPrefab[powerUpIndex].transform.rotation);

    }

}
