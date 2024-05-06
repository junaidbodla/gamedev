using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletLifetime;
    public int damage;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Once bullet is instantiated, immediately give it a velocity using the direction in which it spawned in
        rb.velocity = transform.up * bulletSpeed;

        // Destroys the bullet object after a while
        Destroy(gameObject, bulletLifetime);
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // If bullet collides with an Enemy, then call TakeDamage() on that enemy and destroy bullet
        if(hitInfo.tag == "Enemy")
        {
            hitInfo.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject);
        }
        // If bullet collides with an obstacle like a wall, couch, etc, then destroy bullet
        else if(hitInfo.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
