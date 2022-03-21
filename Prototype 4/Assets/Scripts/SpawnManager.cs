using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;

    // ENEMY
    public int enemyCount;
    private int waveNum = 1;

    // POWER UP
    public GameObject powerupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNum);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; // array length returned

        if(enemyCount.Equals(0))
        {
            SpawnEnemyWave(++waveNum);
            SpawnPowerup();
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float SpawnPosX = Random.Range(-spawnRange, spawnRange);
        float SpawnPosZ = Random.Range(-spawnRange, spawnRange);

        return  new Vector3(SpawnPosX, 0, SpawnPosZ);
    }

    private void SpawnEnemyWave(int enemies)
    {
        for(int i = 0; i < enemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    public int getWaveNum()
    { return waveNum; }
}
