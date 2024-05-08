using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
	public void Next() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		GameManager.instance.SetCurrentLevel(GameManager.instance.currentLevel + 1);
	}

	public void ExitGame() {
		SceneManager.LoadScene("MainMenu");
	}
}
