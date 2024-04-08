using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void play()
    {
        SceneManager.LoadScene(1);
    }

    public void credits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void control()
    {
        SceneManager.LoadScene(2);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
