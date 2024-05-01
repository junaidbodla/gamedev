using UnityEngine;
using UnityEngine.UI;

public class AiZ : MonoBehaviour
{
    public Transform target;        // Set target from inspector instead of looking in Update
    public float speed = 3f;
    public int maxHealth = 100;     // Maximum health of the enemy
    public int currentHealth;       // Current health of the enemy
    public Slider healthBar;        // Reference to the health bar UI element

    void Start()
    {
        currentHealth = maxHealth;  // Set current health to max health at the start
        healthBar.maxValue = maxHealth;    // Set the maximum value of the health bar
        healthBar.value = maxHealth;       // Set the initial value of the health bar
    }

    void Update()
    {
        // Rotate to look at the player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self); // Correcting the original rotation

        // Move towards the player
        if (Vector3.Distance(transform.position, target.position) > 0.01f)
        {   // Move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
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
}
