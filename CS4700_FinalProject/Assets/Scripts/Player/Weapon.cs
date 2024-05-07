using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    public float fireRate;          // expressed in bullets per second
    public int maxAmmo;             // max # of bullets
    public Transform firePoint;
    public GameObject ammoLabelObj;
    private TextMeshProUGUI ammoLabel;
    public GameObject bulletPrefab; 

    private float nextFireTime;
    private int currentAmmo;      // current # of bullets

    
    private Animator animator;

    public AudioSource audioSource; //**audio
    public AudioClip bulletAudioClip; //**audio

    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentAmmo = maxAmmo;
        if(ammoLabelObj)
        {
            ammoLabel = ammoLabelObj.GetComponent<TextMeshProUGUI>();
            //print(ammoLabel.text);
            if(ammoLabel)
                ammoLabel.text = currentAmmo.ToString();
        }
    }


    // Update is called once per frame
    void Update()
    {
        // shoot only at a certain firerate and when left click pressed
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        // don't fire if ammo is empty
        if(currentAmmo > 0)
        {
            audioSource.PlayOneShot(bulletAudioClip); //**audio
            animator.SetTrigger("playerShooting");
            // Instantiate a new bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            removeAmmo(1);
        }
        else
        {
            // todo: bullet click sound?
        }
    }

    public void removeAmmo(int value)
    {
        if (currentAmmo - value < 0)
            currentAmmo = 0;
        else
            currentAmmo -= value;
        if(ammoLabel)
            ammoLabel.text = currentAmmo.ToString();
    }


    public void addAmmo(int value)
    {
        if (currentAmmo + value >= maxAmmo)
            currentAmmo = maxAmmo;
        else
            currentAmmo += value;
        if(ammoLabel)
            ammoLabel.text = currentAmmo.ToString();
    }
}
