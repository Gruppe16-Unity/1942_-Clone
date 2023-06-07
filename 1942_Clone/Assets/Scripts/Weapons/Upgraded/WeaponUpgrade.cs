using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : BaseWeapon
{

    //private AudioSource blast;


    // Start is called before the first frame update
    void Start()
    {
     
       // blast = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    override public void Shoot(Vector3 firePointPosition)
    {
        //Shooting Logic
        Instantiate(BulletPrefab, firePointPosition + new Vector3(0, 1.1f, 0), Quaternion.identity);
        //blast.Play();
    }
}