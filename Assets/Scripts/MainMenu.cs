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
		if (pause.activeInHierarchy == true && (credits.activeInHierarchy == false || controls.activeInHierarchy == false))
		{
			Time.timeScale = 1;
			pause.SetActive(false);
		}
	}
	
	public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void quitToHub()
    {
        SceneManager.LoadScene("Hub");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
