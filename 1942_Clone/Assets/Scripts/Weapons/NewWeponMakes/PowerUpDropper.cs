using UnityEngine;
using System.Collections.Generic;
using Power;
public class PowerUpDropper : MonoBehaviour
{
    public List<PowerUpData> powerUps;
    public float dropChance = 1f;

    public void DropPowerUp()
    {
        if (Random.value <= dropChance)
        {
            GameObject powerUpPrefab = GetRandomPowerUpPrefab();
            if (powerUpPrefab != null)
            {
                Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    private GameObject GetRandomPowerUpPrefab()
    {
        float randomValue = Random.value;

        if (randomValue < 0.33f)
        {
            // Get the ExtraBullet power-up prefab from the powerUps list
            PowerUpData extraBulletPowerUp = powerUps.Find(powerUp => powerUp.powerUpType == PowerUpType.ExtraBullet);
            if (extraBulletPowerUp != null)
            {
                return extraBulletPowerUp.powerUpPrefab;
            }
        }
        else if (randomValue < 0.66f)
        {
            // Get the FireRate power-up prefab from the powerUps list
            PowerUpData fireRatePowerUp = powerUps.Find(powerUp => powerUp.powerUpType == PowerUpType.FireRate);
            if (fireRatePowerUp != null)
            {
                return fireRatePowerUp.powerUpPrefab;
            }
        }
        else
        {
            // Get the ReloadSpeed power-up prefab from the powerUps list
            PowerUpData reloadSpeedPowerUp = powerUps.Find(powerUp => powerUp.powerUpType == PowerUpType.ReloadSpeed);
            if (reloadSpeedPowerUp != null)
            {
                return reloadSpeedPowerUp.powerUpPrefab;
            }
        }

        return null; // No valid power-up prefab found
    }
}
