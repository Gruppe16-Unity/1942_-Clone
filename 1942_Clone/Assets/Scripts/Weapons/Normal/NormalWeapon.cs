using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NormalWeapon : BaseWeapon
{
    public Transform firepoint;
    public GameObject BulletPrefab;
    public float damage, speed;
    private AudioSource blast;

    private float ammo = 5;
    private float FireRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        blast = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }



    public override void Shoot(Vector3 firePointPosition)
    {
        //Shooting Logic
        Instantiate(BulletPrefab, firePointPosition + new Vector3(0, 1.1f, 0), Quaternion.identity);
        blast.Play();
        new WaitForSeconds(FireRate);

    }

    public void StopShoot()
    {


    }



}
