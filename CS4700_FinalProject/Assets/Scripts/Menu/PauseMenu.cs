using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject selectUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
	{
		if(GameIsPaused) 
		{
			Resume();
		} else 
		{
			Pause();
		}
	}
    }

    public void Resume()
    {
		pauseMenuUI.SetActive(false);
        selectUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
    }

    void Pause()
    {
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
    }

    public void Quit()
    {
		GameIsPaused = false;
		Time.timeScale = 1f;
        GameManager.instance.SetCurrentLevel(1);
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel1() 
    {
		GameIsPaused = false;
		Time.timeScale = 1f;
		GameManager.instance.SetCurrentLevel(1);
		SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
		GameIsPaused = false;
		Time.timeScale = 1f;
		GameManager.instance.SetCurrentLevel(2);
		SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3() 
    {
		GameIsPaused = false;
		Time.timeScale = 1f;
        GameManager.instance.SetCurrentLevel(3);
        SceneManager.LoadScene("Level3");
    }
}
