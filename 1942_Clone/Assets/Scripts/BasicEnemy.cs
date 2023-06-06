using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    // random som velger mellom de ulike type basicenemy som blir gitt ved gameobject basicenemyspawn = valg basicenemy
    // kan også klassefisere ulike flystiller ved bruk av prefab som har andre stats 
    private float green = 0.33f;
    private float blue = 0.66f;



    public GameObject greenEnemy;
    public GameObject redEnemy;
    public GameObject blueEnemy;


    public GameObject BasicEnemyType()
    {
        float spawnResult = UnityEngine.Random.Range(0f, 1f);

        if (spawnResult <= green)
        {
            return greenEnemy;
        }
        else if (spawnResult > blue)
        {
            return blueEnemy;
        }
        else
        {
            
            return redEnemy;
        }
    }

    

   
}
