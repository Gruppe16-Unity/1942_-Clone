using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject boss;
    private bool bossKilled;
    private int currentLevel = 1;

    public EnemySpawner enemySpawner; // Reference to the EnemySpawner script
    public Enemy enemy;
    void Start()
    {
        bossKilled = false;
        SpawnBoss();
    }

    void Update()
    {
        if (bossKilled)
        {
            // Increase the level difficulty
            currentLevel++;
            Debug.Log("Level increased to: " + currentLevel);

            // Modify variables in the EnemySpawner script
            enemySpawner.spawnAmount += 1;
            enemySpawner.spawnCount = 0;
            enemySpawner.spawnInterval -= 0.1f;
            enemySpawner.setSpawnDelay -= 0.1f;


            //add ekstra health to all enemy 
            enemy.exstraHealth += 10f;

           
            bossKilled = false;
        }
    }

    void SpawnBoss()
    {
        // Instantiate the boss prefab
        Instantiate(boss, transform.position, Quaternion.identity);
    }

    public void BossKilled()
    {
        bossKilled = true;
    }
}
