using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    public GameObject[] spawnPoints;
    public float spawnInterval = 1.0f;
    public GameObject enemyPrefab;

    private float currentSpawnTime;

    void Start()
    {
        currentSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= currentSpawnTime)
        {
            // Spawn enemy
            int randomIndex = Random.Range(0, spawnPoints.Length);
            GameObject spawnPoint = spawnPoints[randomIndex];
            Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

            // Reset spawn timer
            currentSpawnTime = Time.time + spawnInterval;
        }
    }
}
