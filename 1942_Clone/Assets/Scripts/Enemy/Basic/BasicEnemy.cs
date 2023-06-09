using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy, DamageAble
{
    public float currentHealth; // Current health of the enemy
    public float maxHealth;    // Maximum health of the enemy
    public float moveSpeed;     // Movement speed of the enemy
    public float fireRate = 10f;     // Fire rate of the enemy's weapon

    private float Multiplier;
    private int level;
    private float Map_Level;
    private float nextShootTime;  // Time for the next shoot
    private float shootInterval;  // Random shoot interval between 1 and 3 seconds


    public GameObject BulletPrefab;
    private Transform player;       // Reference to the player's transform
    public Rigidbody2D rb;
    public PowerUpDropper powerUpDropper;
    
    private void Start()
    {
        base.start(); // Call the base class's Start method

        rb = GetComponent<Rigidbody2D>();
        level = FindAnyObjectByType<EnemySpawner>().level;
        player = FindObjectOfType<Player>().transform;  // Find and assign the player's transform   

        //Stats Adjustments
        Map_Level = (float)level;
        currentHealth =  maxHealth * StatsIncreaser(Map_Level); // Set the current health to the maximum health
     
        // StartCoroutine(AttackCoroutine());           // Start the attack coroutine if needed
    }

    override public void TakeDamage(float damage)
    {
        base.TakeDamage(damage);                          // Call the base class's TakeDamage method
        currentHealth -= damage;                          // Reduce the current health by the damage amount
        Debug.Log("Health: " + currentHealth);

        StartCoroutine(BlinkCharacter());                 // Start the blink coroutine for visual feedback

        if (currentHealth <= 0f)
        {
            GameManager.Instance.IncreaseScore(10);       // Increase the player's score when the enemy is defeated
            Die();                                        // Call the Die method
        }
    }

    private void Die()
    {
        GM.EnemyCount--;                                  // Decrement the enemy count in the game manager
        Debug.Log("BasicEnemy has been defeated.");
        Destroy(gameObject);                             // Destroy the enemy game object
        DropPowerUp();
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            // weapon.Shoot(transform.position);           //
            yield return new WaitForSeconds(fireRate);    // Wait for the specified fire rate
        }
    }

    private void Update()
    {
        Movement(); // Move the boss enemy

        // Check if it's time to shoot
        if (Time.time >= nextShootTime)
        {
            SetRandomShootInterval(); // Set a new random shoot interval

            Instantiate(BulletPrefab, transform.position + new Vector3(0f, -2, 0f), Quaternion.identity);
            // Instantiate a bullet prefab at a specific position relative to the boss enemy
        }
    }

    private void Movement()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            // Move the enemy towards the player's position at the specified move speed
        }
    }
    private void SetRandomShootInterval()
    {
        // Generate a random shoot interval between 1 and 3 seconds

        shootInterval = Random.Range(1f, 3f);
        nextShootTime = Time.time + shootInterval;
    }

    private float StatsIncreaser(float level)
    {
       if (level == 0) { Multiplier = 1.00f; }
       if (level == 1) { Multiplier = 1.25f; }
       if (level == 2) { Multiplier = 1.50f; }
       if (level == 3) { Multiplier = 1.65f; }
       if (level == 4) { Multiplier = 1.75f; }
       if (level == 5) { Multiplier = 1.85f; }
       if (level == 6) { Multiplier = 2.00f; }
    
        return Multiplier;
    }

    protected void DropPowerUp()
    {
        //Debug.Log("truffet powerup");
        GameObject tokenPrefab = powerUpDropper.DetermineDropToken();

        if (tokenPrefab != null)
        {
            Instantiate(tokenPrefab, transform.position, Quaternion.identity);
        }
       
    }

}
