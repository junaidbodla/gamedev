using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletLifetime;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        //once bullet is instantiated, immediately give it a velocity using the direction in which it spawned in
        rb.velocity = gameObject.transform.up * bulletSpeed;



        //destroys the bullet object after a while
        Destroy(gameObject, bulletLifetime);
        
    }



    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        /*
        TODO:
            hitInfo holds info about what the bullet collided with
            If bullet collides with enemy, destroy bullet and use hitInfo to call some public TakeDamage(int) of the enemy gameobject
            If bullet collides with wall, destroy bullet
        */
    }
}
