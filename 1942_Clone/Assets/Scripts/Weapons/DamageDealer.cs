
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float minDamage = 3f;
    public float maxDamage = 5f;
    public float criticalChance = 0.2f;
    public float criticalMultiplier = 1.4f;

    public GameObject Bulletprefab;


    private float BulletDamage()
    {
        float damage = CalculateDamage();

        if (IsCritical())
        {
            damage *= criticalMultiplier;
            Debug.Log("Critical Hit!");
        }

        return damage;
    }

    private float CalculateDamage()
    {
        return Random.Range(minDamage, maxDamage);
    }

    private bool IsCritical()
    {
        float randomValue = Random.Range(0f, 1f);
        return randomValue < criticalChance;
    }
    

    public void DealDamage(DamageAble target, float damage)
    {
        //target.TakeDamage(damage);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageAble attackable = other.GetComponent<DamageAble>();

        if (attackable != null)
        {
            float damage = CalculateDamage();

            if (IsCritical())
            {
                damage *= criticalMultiplier;
                Debug.Log("Critical Hit!");
            }

            //attackable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    
    
}
