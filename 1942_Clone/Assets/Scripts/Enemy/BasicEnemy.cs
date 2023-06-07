using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour, DamageAble
{
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float fireRate = 10f;

    private float currentHealth;
    private Transform player;
    private BaseWeapon weapon;

    private void Start()
    {
        currentHealth = maxHealth;
        player = FindObjectOfType<Player>().transform;
        weapon = GetComponent<BaseWeapon>();

      //  StartCoroutine(AttackCoroutine());
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Health: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("BasicEnemy has been defeated.");
        Destroy(gameObject);
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            weapon.Shoot(transform.position);
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}
