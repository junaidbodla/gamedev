using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Animator animator;
    public int maxHealth = 100;
    public int health;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
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
            animator.Play("PlayerHurt");
            health -= value;
            healthBar.value = health;
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
            health += maxHealth;
        }
        healthBar.value = health;
    }
    
    void Die()
    {
        // kill player
        animator.Play("PlayerDeath");
    }

    public void OnDeathAnimFinished()
    {
        // reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
