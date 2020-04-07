using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRange = 9.0f;
    private int enemyCount;
    private int waveNumber;

    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 1;
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, generateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, generateSpawnPosition(), powerupPrefab.transform.rotation);
        }


    }

    Vector3 generateSpawnPosition()
    {

        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomSpawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomSpawnPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, generateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
