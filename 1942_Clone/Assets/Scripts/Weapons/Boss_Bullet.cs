using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Bullet : Bullet
{

    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * -1.0f * speed;


    }

    // Update is called once per frame
    void Update()
    {
    }
 
    protected override void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Print name of the object it hits.
        Debug.Log(hitInfo.name);

        //Removes Bullet on hit.
        Object.Destroy(gameObject);


        //Impact Effect
        Instantiate(impactEffect, transform.position, transform.rotation);
        //Object.Destroy(gameObject);


        // ScoreBehaviour.AddScore(); future implementasjon

    }

}
