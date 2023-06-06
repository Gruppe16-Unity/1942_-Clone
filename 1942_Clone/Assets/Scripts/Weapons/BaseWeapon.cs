using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject BulletPrefab;
    public float damage, speed;
    protected PlayerMovement pm;
    Collider2D bulletCollider;

    // Start is called before the first frame update
    void Start()
    {
        bulletCollider = GetComponent<Collider2D>();
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
            bulletCollider.enabled = true;

        }
       
        


        
    }



    void Shoot() 
    {
        //Shooting Logic

        Instantiate(BulletPrefab, pm.transform.position + new Vector3(0, 1.1f, 0), Quaternion.identity);
    
    }

    public void StopShoot()
    {
        bulletCollider.enabled = false;

    }
}
