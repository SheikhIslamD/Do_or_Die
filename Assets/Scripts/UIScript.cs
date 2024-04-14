using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;

public class UIScript : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pausePanel;
/*  public AudioSource musicSource;
    public AudioClip buttonAudio;
    public AudioClip pauseAudio;
    public AudioClip pauseAmbiance;
    public AudioClip Ambience;*/
    public PlayerControls playerInput;

    //do these all have to be assigned in inspector? surely there's another way
    public GameObject controlsPanel;

    void Start()
    {
        playerInput = new PlayerControls();
        playerInput.Enable();
        playerInput.Player.Pause.performed += _ => Pause();
        Resume();
        Debug.Log("game is started");
    }

    public void Pause()
    {
        if (!GameIsPaused)
        {
        pausePanel.SetActive(true);
        controlsPanel.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("game is paused");
        }
        else
        {
            Resume();
        }

        //musicSource.clip = Ambience;
        //musicSource.Pause();
    }
    public void Resume()
    {
        if (GameIsPaused)
        {
        pausePanel.SetActive(false);
        controlsPanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("game is resumed");
        }


        //musicSource.clip = Ambience;
        //musicSource.Play();
    }    

    public void LoadControlsMenu()
    {
        //replace this with controls popup
        if (!controlsPanel.activeInHierarchy)
        {
            controlsPanel.SetActive(true);
        }
        else
        {
            controlsPanel.SetActive(false);
        }
        //SceneManager.LoadScene("ControlsScreen");
        Debug.Log("Loading Controls");
        //musicSource.clip = buttonAudio;
        //musicSource.Play();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Loading Menu");
        //musicSource.clip = buttonAudio;
        //musicSource.Play();
    }

    public void QuitButton()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
