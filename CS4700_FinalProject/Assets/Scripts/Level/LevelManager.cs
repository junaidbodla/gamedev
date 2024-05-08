using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float spawnDuration;      // number of seconds after the start of the level that enemies continually spawn for
    private float spawnTimer;        // actual timer variable that counts down
    private int remainingEnemies;    // number of enemies left on the stage
    public int maxEnemies;          // maximum amount of enemies allowed to spawn on a stage (not sure if we'll use this)
    public Slider timer;            // UI slider component

    // Start is called before the first frame update
    void Start()
    {
        timer.maxValue = spawnDuration;
        timer.value = spawnDuration;
        spawnTimer = spawnDuration;
    }

    // Update is called once per frame
    void Update()
    {
        // clear the level if the player has cleared the entire wave of enemies
        if (remainingEnemies == 0 && spawnTimer <= 0)
        {
            // Activate the next level screen
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        spawnTimer -= Time.deltaTime;

        // update timer slider
        if(timer != null) {
		    timer.value = spawnTimer;
	    }
    }

    public float getSpawnTimer()
    {
        return spawnTimer;
    }

    public float getRemainingEnemies()
    {
        return remainingEnemies;
    }

    public void addEnemy(int value)
    {
        remainingEnemies += value;
    }

    public void removeEnemy(int value)
    {
        if (remainingEnemies - value > 0)
            remainingEnemies -= value;
        else
            remainingEnemies = 0;
        Debug.Log("enemies left: " + remainingEnemies);
    }
}
