using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerUpEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        Player player = target.GetComponent<Player>();
        if (player != null)
        {
            player.currentHealth += amount;
        }
    }
}
