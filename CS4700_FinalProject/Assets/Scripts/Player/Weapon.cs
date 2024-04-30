using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //a bullet prefab is spawned at where the fire point is and facing where ever the firepoint is facing
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
