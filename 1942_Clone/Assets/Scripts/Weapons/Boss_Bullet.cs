using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Boss_Bullet : Bullet
{
    private Transform player;
    public Player player1;
    public Player2 player2;
    // LayerMask to define which layers the bullet should ignore
    public LayerMask ignoreLayers;

    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        targeting();

    }

    // Update is called once per frame
    void Update()
    {
    }

    protected override void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Check if the hit object is of type BasicEnemy or BossEnemy
        if (hitInfo.CompareTag("Player"))
        {
            
            

            // Print name of the object it hits
            Debug.Log(hitInfo.name);

            // Removes Bullet on hit
            Object.Destroy(gameObject);

            // Impact Effect
            Instantiate(impactEffect, transform.position, transform.rotation);


            //Bullets Damage.
            if (hitInfo.gameObject.GetComponent<Player>() != null)
            {
                hitInfo.gameObject.GetComponent<Player>().TakeDamage(2f);
            }

            else if (hitInfo.gameObject.GetComponent<Player2>() != null)
            {
                hitInfo.gameObject.GetComponent<Player2>().TakeDamage(2f);
            }
        }
        else { return; }

    }

    void targeting()
    {
        // Find all player objects in the scene with tags "Player1" and "Player2"
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        int randomIndex = Random.Range(0, players.Length);

        // Check if any player objects exist
        if (players.Length > 0)
        {
            player = players[randomIndex].transform;

            // Calculate the direction from the bullet to the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Set the bullet's velocity to move towards the player without homing behavior
            rb.velocity = direction * speed;
        }
        else
        {
            Debug.LogError("Player objects not found in the scene!");
        }
    }
 
}
