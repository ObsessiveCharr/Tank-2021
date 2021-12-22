using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] tankPrefab;
    private float spawnRangeZ = 10.5f;
    private float spawnPosX = 11f;
    private float spawnDelay = 1;
    private float spawnInterwal =5.0f;
    public static int maxEnemy = 10;
    int enemyCount = 0;
    

    // Start is called before the first frame update
    
    void Start()
    {
        
        InvokeRepeating("SpawnTank", spawnDelay, spawnInterwal);
    }

    // Update is called once per frame
    void Update()
    {
      


    }
    void SpawnTank()
    {
        int tankIndex = Random.Range(0, tankPrefab.Length);

        if (enemyCount >= maxEnemy)

            return;

        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosX), 0, spawnRangeZ);
        Instantiate(tankPrefab[tankIndex], spawnPos, tankPrefab[tankIndex].transform.rotation);
        enemyCount++;
        //print(enemyCount);
        
        
    }
}
