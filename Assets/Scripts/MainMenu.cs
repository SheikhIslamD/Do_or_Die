using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject credits;
	public GameObject controls;
	public GameObject pause;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pause)
        {
			pauseGame();
        }
		else if (Input.GetKeyDown(KeyCode.Escape) && !pause)
        {
			resume();
        }
    }

    public void play()
    {
        SceneManager.LoadScene("MenuSelect");
    }

    public void credit()
    {
        credits.SetActive(true);
    }

    public void control()
    {
        controls.SetActive(true);
    }
	
	public void back()
	{
		if (controls.activeInHierarchy == true)
			controls.SetActive(false);
		if (credits.activeInHierarchy == true)
			credits.SetActive(false);
	}
	
	public void resume()
	{
		Time.timeScale = 1;
		pause.SetActive(false);
	}

	private void pauseGame()
	{
		Time.timeScale = 0;
		pause.SetActive(true);
		Cursor.lockState = CursorLockMode.None;

	}

	public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
