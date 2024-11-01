using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
	//Static instance of Gamemanager
	public static GameManager instance = null;
	public int currentLevel;
	public int highestLevel;

	void Awake() {
		if (instance == null) {
			instance = this;
		}

		else if (instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	public void SetCurrentLevel(int x)
	{
		currentLevel = x;
	}

}
