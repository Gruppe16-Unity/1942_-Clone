using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject BulletPrefab;
    public float damage, speed;
    private AudioSource blast;

    // Start is called before the first frame update
    void Start()
    {
        blast = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    /*
    if (Input.GetMouseButtonDown(0)) 
        {
            Shoot(pm.transform.position);
        
            

        }
     */   
    }



    virtual public void Shoot(Vector3 firePointPosition) 
    {
        //Shooting Logic
        Instantiate(BulletPrefab, firePointPosition + new Vector3(0, 1.1f, 0), Quaternion.identity);
        blast.Play();

    }

    public void StopShoot()
    {
    

    }
}
