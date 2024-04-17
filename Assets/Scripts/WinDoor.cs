using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinDoor : MonoBehaviour
{
    AudioManager audioManager;
    PauseScript pauseScript;
    GameObject endPanel;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        pauseScript = GameObject.Find("UICanvas (working)").GetComponent<PauseScript>();
        endPanel = GameObject.Find("EndPanel");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endPanel.SetActive(true);

            pauseScript.Pause();
            pauseScript.gameOver = true;

            audioManager.playSFX(audioManager.win);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //add + 1 for next level
        }
    }
}
