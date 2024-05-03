using UnityEngine;
using UnityEngine.UI;

public class AiZ : MonoBehaviour
{
    public string targetTag;
    public float speed = 3f;
    public int maxHealth = 100;     // Maximum health of the enemy
    public int damage;              // Amount of damage that player takes on collision

    private GameObject target;      // Reference to game object of current target
    private Transform targetLocation;        // Set target from inspector instead of looking in Update
    private int currentHealth;      // Current health of the enemy
    private Slider healthBar;       // Reference to the healthbar
    private Animator animator;
    private Rigidbody2D rb;

    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag); //Finds the target gameObject given only its tag
        healthBar = GetComponentInChildren<Slider>(); //Get the healthbar from canvas
        targetLocation = target.GetComponent<Transform>();
        currentHealth = maxHealth;  // Set current health to max health at the start
        healthBar.maxValue = maxHealth;    // Set the maximum value of the health bar
        healthBar.value = maxHealth;       // Set the initial value of the health bar
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        target = GameObject.FindGameObjectWithTag(targetTag);  //gets the target the zombie is following depending on the tag

        // Rotate to look at the player
        if (target != null) 
        {

            targetLocation = target.transform; 

            transform.LookAt(targetLocation.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self); // Correcting the original rotation

            // Move towards the player
            if (Vector3.Distance(transform.position, targetLocation.position) > 0.01f)
            {   // Move if distance from target is greater than 1
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                animator.SetBool("isWalking", true); //update animator's parameter to tell that the Enemy should be walking
            }
            else
            {
                animator.SetBool("isWalking", false); ////update animator's parameter to tell that the Enemy shouldn't be walking
            }
        }

    }
    
    private void FixedUpdate()
    {
        //TODO: convert zombie movement to physics based instead of transform based in Update()
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
