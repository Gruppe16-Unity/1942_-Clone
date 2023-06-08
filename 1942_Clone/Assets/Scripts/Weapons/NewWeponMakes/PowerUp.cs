using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.ApplyPowerUp(powerUpType);
            Destroy(gameObject);
        }
    }
}
