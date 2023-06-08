using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy, DamageAble
{
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float fireRate = 2f;

    private float currentHealth;
    private Transform player;
    private float nextFireTime;

    private void Start()
    {
        base.Start();
        currentHealth = maxHealth;
        player = FindObjectOfType<Player>().transform;
        nextFireTime = Time.time;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        currentHealth -= damage;
        if (currentHealth < 0f)
        {
            Debug.Log("Health: " + currentHealth);
            Die();
            GameManager.Instance.IncreaseScore(10);
            currentHealth = 0f; // Ensure health doesn't go below zero
        }
            StartCoroutine(BlinkCharacter());

    }

        private void Die()
    {
        Debug.Log("BasicEnemy has been defeated.");
        Destroy(gameObject);
        base.OnDestroy();
        GM.EnemyCount--;
    }

    private void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
          
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enenmy"))
        {
            TakeDamage(10f);
        }
    }

    private void Shoot()
    {
        FindObjectOfType<BaseWeapon>().EnemyShoot(transform, player.transform, 1);
    }
}
