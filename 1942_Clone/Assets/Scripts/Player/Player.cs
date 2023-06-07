using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour //, DamageAble
{
    public GameObject impactEffect;
    private BaseWeapon weapon;

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


    }

    void Update()
    {
        //InputManagement();
        

        HandleMovement();

        if(Input.GetMouseButtonDown(0))
        {
            weapon.Shoot(transform.position);
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
}
