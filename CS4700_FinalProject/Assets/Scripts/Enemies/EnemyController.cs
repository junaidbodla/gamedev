using Pathfinding;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100;     // Maximum health of the enemy
    public int damage;              // Amount of damage that player takes on collision
    public string targetTag;

    private int currentHealth;      // Current health of the enemy
    private Slider healthBar;       // Reference to the healthbar
    private Animator animator;
    private Rigidbody2D rb;


    void Start()
    {
        healthBar = GetComponentInChildren<Slider>(); //Get the healthbar from canvas
        currentHealth = maxHealth;  // Set current health to max health at the start
        healthBar.maxValue = maxHealth;    // Set the maximum value of the health bar
        healthBar.value = maxHealth;       // Set the initial value of the health bar
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //not good practice but fixes a bug, and is okay in cases where zombie is always going after player
        animator.SetBool("isWalking", true);

        //target for the pathfinding is set to the object corresponding to inputted tag
        AIDestinationSetter aiDestSetter = GetComponent<AIDestinationSetter>();
        aiDestSetter.target = GameObject.FindGameObjectWithTag(targetTag).transform;
    }

    void Update()
    {
        healthBar.transform.rotation = Quaternion.identity; // Rotates healthbar to original position, so it stays fixed and doesn't rotate with zombie
    }



    // Method to decrease enemy health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;            // Decrease current health by the amount of damage

        healthBar.value = currentHealth;    // Update the health bar


        if (currentHealth <= 0)
        {
            Die();  // Call Die method if health is less than or equal to 0
        }

    }

    // Method to handle enemy's death
    void Die()
    {
        Destroy(gameObject);    // Destroy the enemy object
    }


    //If there is a collision (not in cases where IsTrigger is used on at least one of objects),
    //then decrease health of player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
        if (collision.gameObject.tag == "Player")
        {
            player.DecreaseHealth(damage);

        }
    }
}