using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform player, destination;
    public GameObject playerG;

    AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerG.SetActive(false);
            other.transform.position = destination.position;
            playerG.SetActive(true);
            Debug.Log("Transported to Cheat Room");

            audioManager.playSFX(audioManager.teleport);
        }
    }

}