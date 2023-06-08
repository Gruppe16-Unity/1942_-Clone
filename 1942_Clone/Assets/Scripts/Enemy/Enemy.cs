using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : DamageAble
{
    public float blinkDuration = 0.2f; // Duration of each blink
    public Color blinkColor = Color.red; // Color to blink
    protected SpriteRenderer characterRenderer; // Reference to the character's sprite renderer
    protected Color originalColor; // Original color of the character
    public float exstraHealth;
    public AudioSource Bullet_Hit;

    //References
    public GameManager GM;
    public NormalWeapon weapon;

    public abstract void TakeDamage(float damage);


    public abstract void Die();

    protected virtual IEnumerator BlinkCharacter()
    {
        // Blink the character red for the specified duration
        characterRenderer.color = blinkColor;
        yield return new WaitForSeconds(blinkDuration);

        // Change the color back to the original color
        characterRenderer.color = originalColor;
    }
}
