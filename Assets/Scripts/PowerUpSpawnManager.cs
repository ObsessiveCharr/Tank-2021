using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnManager : MonoBehaviour
{
    public GameObject[] powerUpPrefab;
    private float spawnDelay = 5;
    private float spawnInterwal = 30.0f;
    private float spawnPosX = 11.5f;
    private float spawnPosZ = 11f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerUp", spawnDelay, spawnInterwal);
    }

    // Update is called once per frame
    void SpawnPowerUp()
    {
        int powerUpIndex = Random.Range(0, powerUpPrefab.Length);

        Vector3 spawnPos = new Vector3(Random.Range(spawnPosX, -spawnPosX), 0.6f, Random.Range(spawnPosZ, -spawnPosZ));
        Instantiate(powerUpPrefab[powerUpIndex], spawnPos, powerUpPrefab[powerUpIndex].transform.rotation);

    }
}
