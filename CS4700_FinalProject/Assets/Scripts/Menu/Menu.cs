using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void onPlayButton() {
	SceneManager.LoadScene("Level1");
    }

    public void onQuitButton() {
	Application.Quit();
    }
}
