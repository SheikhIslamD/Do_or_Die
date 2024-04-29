using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WinDoor : MonoBehaviour
{
    AudioManager audioManager;
    PauseScript pauseScript;
    ScoreTracker scoreTracker;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        pauseScript = GameObject.Find("UICanvas (working)").GetComponent<PauseScript>();
        scoreTracker = GameObject.Find("ScoreTracker").GetComponent<ScoreTracker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            

            audioManager.playSFX(audioManager.win);

            scoreTracker.DiceCollected();
            
            pauseScript.GameOver();
        }
    }
}
