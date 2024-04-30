using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PearlyGates : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] ScoreTracker scoreTracker;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        scoreTracker = GameObject.Find("ScoreTracker").GetComponent<ScoreTracker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            audioManager.playSFX(audioManager.teleport);
            //update tell scoremanager to spawn the mind dicey in the hub
            scoreTracker.mazeCompleted = true;
            //let my boy outta here
            SceneManager.LoadScene("Hub");
        }
    }
}
