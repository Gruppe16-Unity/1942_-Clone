using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossEnemy : Enemy
{
  
    private Rigidbody2D rb;
    public GameObject BulletPrefab;
    public float maxHealth = 100f;
    private float currentHealth;
    public float moveSpeed = 4f;
    private float minX = -9f;
    private float maxX = 10f;
    private float nextShootTime;  // Time for the next shoot
    private float shootInterval;  // Random shoot interval between 1 and 3 seconds



    private void Start()
    {
        base.start();
        currentHealth = maxHealth;
         rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        rb.velocity = new Vector2(moveSpeed, 0f);

        // Set initial shoot interval
        SetRandomShootInterval();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage); // Call the base method for general damage logic
        StartCoroutine(BlinkCharacter());
        currentHealth -= damage; // Reduce the current health by the damage amount
        Debug.Log("Health:" + currentHealth);
        if (currentHealth <= 0f)
        {
            Die(); // If the health is zero or below, call the Die method
        }
    }
    private void Update()
    {
        // Check if it's time to shoot
        if (Time.time >= nextShootTime)
        {
            BossMovement();

            // Set a new random shoot interval
            SetRandomShootInterval();
        }
    }

    private void Die()
    {
        // Implement the logic for enemy death, such as destroying the GameObject or playing death animations
        Debug.Log("BasicEnemy has been defeated.");
        Destroy(gameObject);


    }
     private void BossMovement()
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
    }

    private void SetRandomShootInterval()
    {
        // Generate a random shoot interval between 1 and 3 seconds
        shootInterval = Random.Range(1f, 3f);
        nextShootTime = Time.time + shootInterval;
    }


}


