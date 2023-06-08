using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bomb has collided with the player
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            // Handle player death (e.g., set health to zero, play death animation, etc.)
            player.Die();
        }

        // Explode the bomb
        Explode();
    }

    private void Explode()
    {
        // Perform explosion effects and kill enemies within the specified explosion radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            /*
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Kill the enemy
                enemy.Die();
            }
            */

            // Check if the collider belongs to the player
            Player player = collider.GetComponent<Player>();
            if (player != null)
            {
                // Kill the player
                player.Die();
            }

            // Destroy any other objects within the explosion radius
            Destroy(collider.gameObject);
        }

        // Destroy the bomb
        Destroy(gameObject);
    }

}
