using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : DamageAble
{
    
    public virtual void TakeDamage(float damage)
    {
        // Implement general damage logic for all enemy types
        Debug.Log("Enemy took damage: " + damage);
    }


    private void OnDestroy()
    {
        //drop powerups??
    }

}
