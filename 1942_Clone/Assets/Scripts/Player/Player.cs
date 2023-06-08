using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, DamageAble
{
    //GameObject
    public GameObject impactEffect;
    private BaseWeapon weapon;
    public HealthBar healthbar;
    public Credit getCredit;

    [HideInInspector]
    public float CooldownTime = 0, shootCooldown = 0.2f; // Delay between shooting presses
    [HideInInspector]
    public float reloadTimer = 2f; // Time to reload
    [HideInInspector]
    private int currentAmmo, maxAmmo = 10;


    //Health & Credit 
    public SharedHP sharedHP;
    public float maxHealth;
    public float currentHealth;



    //Movement
    public float moveSpeed;


    [HideInInspector]
    //public Vector2 moveDir;
    private Vector3 Move;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;


    //References
    Rigidbody2D playerRigidbody2D;
    private Transform player;


    //bool
    public bool hasExtraBulletPowerUp = false;
    public bool hasFireRatePowerUp = false;
    public bool hasReloadSpeedPowerUp = false;

    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        weapon = GetComponent<BaseWeapon>();
        currentAmmo = maxAmmo;
        maxHealth = 15f;
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);


    }

    void Update()
    {
        //InputManagement();

        if (player != null)
        {

            HandleMovement();
            CooldownTime -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && CooldownTime <= 0f && currentAmmo > 0)
            {
                CooldownTime = shootCooldown;
                weapon.Shoot();
                currentAmmo--; // Decrease ammo count
                reloadTimer = 3f; // Start the reload timer
            }
            if (reloadTimer > 0f)
            {
                reloadTimer -= Time.deltaTime;
                if (reloadTimer <= 0f)
                {
                    Reload();
                }
            }
        }
    }


    void FixedUpdate()
    {
        //OnMove();
        playerRigidbody2D.MovePosition(transform.position + Move * moveSpeed * Time.deltaTime);
    }

    public void HandleMovement()
    {
        float x = 0f;
        float y = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            y = +1f;
            //Debug.Log("w pressed");
        }
        if (Input.GetKey(KeyCode.A))
        {
            x = -1f;
            //Debug.Log("q pressed");
        }
        if (Input.GetKey(KeyCode.S))
        {
            y = -1f;
            //Debug.Log("s pressed");
        }
        if (Input.GetKey(KeyCode.D))
        {
            x = +1f;
            //Debug.Log("d pressed");
        }

        Vector3 Move = new Vector3(x, y).normalized;
        transform.position += Move * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //kall destroyed animasion
        //Destroy(gameObject);
        TakeDamage(1f);
        Debug.Log("CollisionEnter");

        //Removes 
        //Object.Destroy(gameObject);

        //Impact Effect
        Instantiate(impactEffect, transform.position, transform.rotation);

    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Health: " + currentHealth);
        healthbar.SetHealth(currentHealth);
        if (currentHealth == 0f)
        {
            Die();
        }
    }
    public void Reload()
    {
        currentAmmo = 10;
    }

    public void Die()
    {
        Debug.Log("Player has been defeated.");
        Destroy(gameObject);
        WaitForSecondsCoroutine();
        SceneManager.LoadScene("GameOver");
       

    }

    private IEnumerator WaitForSecondsCoroutine()
    {
        Debug.Log("Coroutine started");

        yield return new WaitForSeconds(5);

        Debug.Log("Coroutine finished");
    }
    
    // Function to decrease HP
    public void DecreaseHP(int amount)
    {
        sharedHP.DecreaseSharedHealth(amount);
    }

    public void ApplyPowerUp(PowerUpType powerUp)
    {
        switch (powerUp)
        {
            case PowerUpType.ExtraBullet:
                if (!hasExtraBulletPowerUp)
                {
                    weapon.AddExtraBullet();
                    hasExtraBulletPowerUp = true;
                }
                break;
            case PowerUpType.FireRate:
                if (!hasFireRatePowerUp)
                {
                    weapon.IncreaseFireRate(0.3f);
                    hasFireRatePowerUp = true;
                }
                break;
            case PowerUpType.ReloadSpeed:
                if (!hasReloadSpeedPowerUp)
                {
                    weapon.DecreaseReloadSpeed(0.2f);
                    hasReloadSpeedPowerUp = true;
                }
                break;
        }
    }
}