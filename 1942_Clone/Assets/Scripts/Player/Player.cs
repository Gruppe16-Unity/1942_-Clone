using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour //, DamageAble
{
    public GameObject impactEffect;
    private BaseWeapon weapon;

    [HideInInspector]
    private float CooldownTime = 0, shootCooldown = 0.2f; // Delay between shooting presses
    [HideInInspector]
    public float reloadTimer = 2f; // Time to reload
    [HideInInspector]
    private int currentAmmo, maxAmmo = 10;


    //Movement
    public float moveSpeed;

    [HideInInspector]
    //public Vector2 moveDir;
    private Vector3 Move;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    

    //References
    Rigidbody2D playerRigidbody2D;
  
    void Start()
    {

        playerRigidbody2D = GetComponent<Rigidbody2D>();
        weapon = GetComponent<BaseWeapon>();
        currentAmmo = maxAmmo;


    }

    void Update()
    {
        //InputManagement();
        

        HandleMovement();
        CooldownTime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && CooldownTime <= 0f && currentAmmo > 0)
        {
            CooldownTime = shootCooldown;
            weapon.Shoot(transform.position);
            currentAmmo--; // Decrease ammo count
            reloadTimer = 3f; // Start the reload timer
        }
        if (reloadTimer > 0f)
        {
            reloadTimer -= Time.deltaTime;
            if (reloadTimer <= 0f)
            {
                Reload();
            }
        }
    }


    void FixedUpdate()
    {
        //OnMove();
        playerRigidbody2D.MovePosition(transform.position + Move * moveSpeed * Time.deltaTime);
    }
/*
    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
        }

        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
        }
    }
*/
    public void HandleMovement()
    {
        float x = 0f;
        float y = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            y = +1f;
            //Debug.Log("w pressed");
        }
        if (Input.GetKey(KeyCode.A))
        {
            x = -1f;
            //Debug.Log("q pressed");
        }
        if (Input.GetKey(KeyCode.S))
        {
            y = -1f;
            //Debug.Log("s pressed");
        }
        if (Input.GetKey(KeyCode.D))
        {
            x = +1f;
            //Debug.Log("d pressed");
        }

        Vector3 Move = new Vector3(x, y).normalized;
        transform.position += Move * moveSpeed * Time.deltaTime;
    }


    /*
    void OnMove()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
    */


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //kall destroyed animasion
        //Destroy(gameObject);
        Debug.Log("CollisionEnter");
        
        //Removes 
        //Object.Destroy(gameObject);

        //Impact Effect
        Instantiate(impactEffect, transform.position, transform.rotation);

    }

    public void Reload()
    {
        currentAmmo = 10;
    }

}
