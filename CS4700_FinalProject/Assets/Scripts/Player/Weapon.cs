using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate; //expressed in bullets per second
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float nextFireTime;
    private Animator animator;

    public AudioSource audioSource; //**audio
    public AudioClip bulletAudioClip; //**audio

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
        audioSource.PlayOneShot(bulletAudioClip); //**audio
        animator.SetTrigger("playerShooting");
        // Instantiate a new bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
