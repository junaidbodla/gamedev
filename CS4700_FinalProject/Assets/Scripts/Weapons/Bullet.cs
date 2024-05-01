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
        // Get the object the bullet collided with
        GameObject hitObject = hitInfo.gameObject;

        // If the bullet collided with an enemy, decrease its health
        AiZ enemy = hitObject.GetComponent<AiZ>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
