using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDropper : MonoBehaviour
{
    
    public float dropChanceSmall = 0.4f;
    public float dropChanceMedium = 0.3f;
    public float dropChanceLarge = 0.1f;

    public GameObject SmallHealthBuff;
    public GameObject MediumHealthBuff;
    public GameObject LargeHealthBuff;

    public GameObject DetermineDropToken()
    {
        float dropResult = UnityEngine.Random.Range(0f, 1f);

        if (dropResult >= dropChanceSmall)
        {

            return SmallHealthBuff;
        }
        else if (dropResult < dropChanceLarge)
        {
            return MediumHealthBuff;
        }
        else
        {
            return LargeHealthBuff;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("PowerUp picked up" + gameObject);
        }

        Destroy(gameObject);
    }


}
