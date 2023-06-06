using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int spawnAmount;
    public int spawnCount;
    private bool newSpawn;
    public int level;
    Vector3 spawnRadius;
    public GameObject greenEnemy;
    public GameObject redEnemy;
    public GameObject blueEnemy;
    public GameObject boss;
    private GameObject Enemy;
    private Vector3 spawnPoint;

    public float spawnInterval = 1.5f;
    public float setSpawnDelay = 5f;

    void Start()
    {
        level = 1;
        spawnCount = 0;
        spawnAmount = 3;
        newSpawn = true;

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (newSpawn)
            {
                spawnPoint = SpawnPoint();
                Enemy = GetEnemyType();
                newSpawn = false;
            }

            spawnPoint.x += 1.5f;
            spawnPoint.y += 1.5f;
            GameObject newEnemy = Instantiate(Enemy, spawnPoint, Quaternion.Euler(0f, 0f, 180f));
            spawnCount++;

            if (spawnCount >= spawnAmount)
            {
                spawnCount = 0;
                newSpawn = true;
                yield return new WaitForSeconds(setSpawnDelay);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 SpawnPoint()
    {
        spawnRadius = new Vector3(0, 0, 0);
        spawnRadius.x += UnityEngine.Random.Range(-10f, 10f);
        return spawnRadius;
    }

    private GameObject GetEnemyType()
    {
        float randomValue = UnityEngine.Random.Range(0f, 1f);

        if (randomValue <= 0.33f)
        {
            return greenEnemy;
        }
        else if (randomValue > 0.66f)
        {
            return blueEnemy;
        }
        else
        {
            return redEnemy;
        }
    }
}
