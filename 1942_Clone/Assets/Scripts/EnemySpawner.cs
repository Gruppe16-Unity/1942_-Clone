using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int spawnAmount;
    private int spawnCount;
    //private float spawnTime;
    private bool isSpawning;
    public int level;
    Vector3 spawnRadius;
    //public GameObject GetGameobject<Player>;
    public GameObject Enemy;

    // sett en varibal lik gameobject enemytype for hvilken tyhpe enemy som skal bli spawna 

    void Start()
    {
        level = 1;
        spawnCount = 0;
        spawnAmount = 1;
        isSpawning = true;
    }

    void Update()
    {
        if (isSpawning)
        {

            Spawner();
        }
    }


    private void Spawner()
    {
        if (spawnAmount > spawnCount)
        {
            spawnRadius = new Vector3(1, 1, 0);
            isSpawning = true;
            float placex = spawnRadius.x * UnityEngine.Random.Range(-10f, 10f);
            float placey = spawnRadius.y;

            Vector3 randSpawnPoint = new Vector3(placex, placey).normalized;
            Instantiate(Enemy, randSpawnPoint, Quaternion.identity);
            spawnCount++;
        }
        else
        {
            level += 1;
            spawnAmount += 2;
            isSpawning = false;
        }
    }


}

