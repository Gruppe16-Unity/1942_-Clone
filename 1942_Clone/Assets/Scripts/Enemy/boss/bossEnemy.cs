using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy, DamageAble
{
    private Rigidbody2D rb;
    public GameObject BulletPrefab;

    public float moveSpeed = 4f;
    public float level, Map_Level;
    public float maxHealth = 100f;

    private float currentHealth;
    private float minX = -9f;
    private float maxX = 10f;
    private float nextShootTime;  // Time for the next shoot
    private float shootInterval;  // Random shoot interval between 1 and 3 seconds
    private float Multiplier;

    private void Start()
    {
        base.start(); // Call the base class's Start() method

        //RigidBody
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveSpeed, 0f);

        //Stats Adjustments
        Map_Level = (float)level;
        currentHealth = maxHealth * StatsIncreaser(Map_Level); // Set the current health based on the level

        // Set initial shoot interval
        SetRandomShootInterval();
    }

    private void Update()
    {
        // Check if it's time to shoot
        if (Time.time >= nextShootTime)
        {
            Movement(); // Move the boss enemy
            SetRandomShootInterval(); // Set a new random shoot interval
        }
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage); // Call the base class's TakeDamage() method for general damage logic
        StartCoroutine(BlinkCharacter()); // Start a coroutine to make the character blink when damaged
        currentHealth -= damage; // Reduce the current health by the damage amount
        Debug.Log("Health:" + currentHealth);
        if (currentHealth <= 0f)
        {
            GM.EnemyBoss = 0;
            GameManager.Instance.IncreaseScore(100);
            Die(); // If the health is zero or below, call the Die() method
        }
    }

    private void Die()
    {
        // Implement the logic for enemy death, such as destroying the GameObject or playing death animations
        Debug.Log("BossEnemy has been defeated.");
        Destroy(gameObject);
    }

    private void Movement()
    {
        Vector3 currentPosition = transform.position;

        // Ensure the boss stays within the specified X range
        if (transform.position.x <= minX)
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
        else if (transform.position.x >= maxX)
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }

        Instantiate(BulletPrefab, transform.position + new Vector3(0f, -2, 0f), Quaternion.identity);
        // Instantiate a bullet prefab at a specific position relative to the boss enemy
    }

    private void SetRandomShootInterval()
    {
        // Generate a random shoot interval between 1 and 3 seconds
        shootInterval = Random.Range(1f, 3f);
        nextShootTime = Time.time + shootInterval;
    }

    private float StatsIncreaser(float level)
    {
        // Calculate a multiplier based on the given level
        if (level == 0) { Multiplier = 1.00f; }
        if (level == 1) { Multiplier = 1.25f; }
        if (level == 2) { Multiplier = 1.50f; }
        if (level == 3) { Multiplier = 1.65f; }
        if (level == 4) { Multiplier = 1.75f; }
        if (level == 5) { Multiplier = 1.85f; }
        if (level == 6) { Multiplier = 2.00f; }

        return Multiplier;
    }
}
