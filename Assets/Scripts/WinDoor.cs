using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinDoor : MonoBehaviour
{
    public GameObject WinUI;
    public GameObject UIHud;
    public bool mouseLookEnabled;
    public bool GameIsPaused;
    public Button[] levelButtons;

    AudioManager audioManager;

    void Start()
    {
        //WinUI.SetActive(true);
        //UIHud.SetActive(false);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WinUI.SetActive(true);
            //Time.timeScale = 0;
            GameIsPaused = true;
            UIHud.SetActive(false);
            Debug.Log("You Win!");

            audioManager.playSFX(audioManager.win);
        }
    }

    public void WinScreen()
    {
        WinUI.SetActive(true);
        GameIsPaused = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //add + 1 for next level
    }
        public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Hub");
    }
}
