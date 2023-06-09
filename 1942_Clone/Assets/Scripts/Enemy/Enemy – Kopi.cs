using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, DamageAble
{
    public float blinkDuration = 0.2f; // Duration of each blink
    public Color blinkColor = Color.red; // Color to blink
    private SpriteRenderer characterRenderer; // Reference to the character's sprite renderer
    private Color originalColor; // Original color of the character
    public float exstraHealth;
    public AudioSource Bullet_Hit;

    //References
    public GameManager GM;
    public NormalWeapon weapon;
    public virtual void TakeDamage(float damage)
    {
        // Play Sound if they get hit.
        Bullet_Hit.Play();
        // Implement general damage logic for all enemy types
        Debug.Log("Enemy took damage: " + damage);
    }

    virtual protected void start() 
    {
        GM = FindAnyObjectByType<GameManager>();
        Bullet_Hit = GetComponent<AudioSource>();
        characterRenderer = GetComponent<SpriteRenderer>();
        originalColor = characterRenderer.color;


    }


    private void OnDestroy()
    {
        //drop powerups??
    }
    protected virtual IEnumerator BlinkCharacter()
    {

        // Blink the character red for the specified duration
        characterRenderer.color = blinkColor;
        yield return new WaitForSeconds(blinkDuration);

        // Change the color back to the original color
        characterRenderer.color = originalColor;
        
        
    }
}
