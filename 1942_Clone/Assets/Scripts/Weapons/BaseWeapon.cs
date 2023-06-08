using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public abstract void Shoot(Vector3 firePointPosition);

    public void StopShoot()
    {
        // Implementation for stopping shooting
    }
}
