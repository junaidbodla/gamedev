using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public Slider healthBar;

    private Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHealth(int value)
    {
        // decrease health
        if(health > 0)
        {
            health -= value;
            healthBar.value = health;
            animator.SetTrigger("playerTookDamage"); //updates parameter of animator, notifying it that player took damage
 
        }
        
        if(health <= 0) // kill the player if health is depleted
        {
            Die();
        }
    }

    public void IncreaseHealth(int value)
    {
        if(health + value >= maxHealth) // don't allow player's health to exceed max
        {
            health = maxHealth;
        }
        else
        {
            health += value;
        }
        healthBar.value = health;
    }
    
    void Die()
    {
        animator.SetTrigger("playerDies"); //updates parameter of animator, notifying it that player is dead

        //disables player movement, rotation, prevents player from being influenced by physics, and stops player from moving
        GetComponent<PlayerAim>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void OnDeathAnimFinished()
    {
        // reload scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //TODO: go to game over scene
	SceneManager.LoadScene("GameOver");
    }
}
