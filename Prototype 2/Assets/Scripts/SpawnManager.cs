using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float TopSpawnPosZ = 15;
    private float BottomSpawnPosZ = 1;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    private UpdatePlayerStats Stats;

    // Start is called before the first frame update
    void Start()
    {
        Stats = GameObject.Find("PlayerStats").GetComponent<UpdatePlayerStats>();

        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnRandomAnimal()
    {
        if (Stats.getHealth() > 0)
        {
            // from 0 to length
            int animalIndex = Random.Range(0, animalPrefabs.Length); // random aninmal
            Vector3 spawnPosX = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, TopSpawnPosZ); // random position x
            Vector3 RightSpawnZ = new Vector3(spawnRangeX, 0, Random.Range(BottomSpawnPosZ, TopSpawnPosZ)); // random position z right
            Vector3 LeftSpawnZ = new Vector3(-spawnRangeX, 0, Random.Range(BottomSpawnPosZ, TopSpawnPosZ)); // random position z left

            switch(Random.Range(0, 4))
            {
                case 1:
                    Instantiate(animalPrefabs[animalIndex], spawnPosX, animalPrefabs[animalIndex].transform.rotation);
                    break;
                case 2:
                    Instantiate(animalPrefabs[animalIndex], LeftSpawnZ, Quaternion.Euler(0, 90, 0));
                    break;
                case 3:
                    Instantiate(animalPrefabs[animalIndex], RightSpawnZ, Quaternion.Euler(0, 270, 0));
                    break;
            }
        }
        
    }
}
