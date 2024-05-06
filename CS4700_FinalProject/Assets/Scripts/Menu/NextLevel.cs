using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
	public void Next() {
		SceneManager.LoadScene("Level" + (GameManager.instance.currentLevel + 1));
	}

	public void ExitGame() {
		SceneManager.LoadScene("MainMenu");
	}
}
