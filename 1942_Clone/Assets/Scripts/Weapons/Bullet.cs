using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip[] audioClips;
    protected AudioClip Bullet_Trigger, Bullet_Hit;
    AudioSource audioSource;

    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        rb.velocity = transform.up * speed;
        
        AudioClip Bullet_Trigger = audioClips[0];
        AudioClip Bullet_Hit = audioClips[1];
    }

    protected virtual void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Print name of the object it hits.
        Debug.Log(hitInfo.name);

        //Removes Bullet on hit.
        Object.Destroy(gameObject);

        //Impact Effect
        Instantiate(impactEffect, transform.position, transform.rotation);
        Object.Destroy(gameObject);
        

        // ScoreBehaviour.AddScore(); future implementasjon
    }
}
