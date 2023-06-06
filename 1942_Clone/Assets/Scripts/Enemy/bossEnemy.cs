using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossEnemy : Enemy
{
    public float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage); // Call the base method for general damage logic

        currentHealth -= damage; // Reduce the current health by the damage amount
        Debug.Log("Health:" + currentHealth);
        if (currentHealth <= 0f)
        {
            Die(); // If the health is zero or below, call the Die method
        }
    }

    private void Die()
    {
        // Implement the logic for enemy death, such as destroying the GameObject or playing death animations
        Debug.Log("BasicEnemy has been defeated.");
        //Destroy(gameObject);


    }
}
