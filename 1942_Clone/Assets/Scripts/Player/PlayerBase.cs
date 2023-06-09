using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class PlayerBase : MonoBehaviour, DamageAble
{
    // GameObject
    public GameObject impactEffect;
    protected BaseWeapon weapon;
    public HealthBar healthbar;
    public Credit getCredit;

    [HideInInspector]
    protected float CooldownTime = 0, shootCooldown = 0.2f; // Delay between shooting presses
    [HideInInspector]
    public float reloadTimer = 2f; // Time to reload
    [HideInInspector]
    protected int currentAmmo, maxAmmo = 10;


    // Health & Credit 
    public SharedHP sharedHP;
    public float maxHealth;
    public float currentHealth;

    // Movement
    public float moveSpeed;

    [HideInInspector]
    protected Vector3 Move;

    // References
    protected Rigidbody2D playerRigidbody2D;

    protected virtual void Start()
    {
        WeaponSwap();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        currentAmmo = maxAmmo;
        maxHealth = 15f;
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    protected virtual void Update()
    {
        if (CooldownTime > 0f)
            CooldownTime -= Time.deltaTime;

        if (Input.GetKeyDown(GetShootKeyCode()) && CooldownTime <= 0f && currentAmmo > 0)
        {
            CooldownTime = shootCooldown;
            weapon.Shoot(transform.position);
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

    protected abstract KeyCode GetShootKeyCode();

    protected void FixedUpdate()
    {
        playerRigidbody2D.MovePosition(transform.position + Move * moveSpeed * Time.deltaTime);
    }

    protected abstract void HandleMovement();

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(5f);
            Debug.Log("CollisionEnter");
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Health: " + currentHealth);
        healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void Reload()
    {
        currentAmmo = 10;
    }

    private void Die()
    {
        Debug.Log("Player has been defeated.");
        Destroy(gameObject);
        StartCoroutine(WaitForSecondsCoroutine());
        SceneManager.LoadScene("GameOver");
    }

    private System.Collections.IEnumerator WaitForSecondsCoroutine()
    {
        Debug.Log("Coroutine started");

        yield return new WaitForSeconds(5);

        Debug.Log("Coroutine finished");
    }

    public void DecreaseHP(int amount)
    {
        sharedHP.DecreaseSharedHealth(amount);
    }

    public void WeaponSwap()
    {
        weapon = null; // Reset the weapon variable

        // Check if AdvancedWeaponUpgrade script is active
        AdvancedWeaponUpgrade advancedWeapon = GetComponent<AdvancedWeaponUpgrade>();
        if (advancedWeapon != null && advancedWeapon.enabled)
        {
            weapon = advancedWeapon;
            return;
        }

        // Check if WeaponUpgrade script is active
        WeaponUgrade weaponUpgrade = GetComponent<WeaponUgrade>();
        if (weaponUpgrade != null && weaponUpgrade.enabled)
        {
            weapon = weaponUpgrade;
            return;
        }

        // Check if NormalWeapon script is active
        NormalWeapon normalWeapon = GetComponent<NormalWeapon>();
        if (normalWeapon != null && normalWeapon.enabled)
        {
            weapon = normalWeapon;
            return;
        }
    }
}

