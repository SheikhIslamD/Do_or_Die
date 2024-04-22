using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button1Script : MonoBehaviour
{
    public TextMeshProUGUI button1Text;
    public DoorScript doorScript;
    AudioManager audioManager;

private void Start()
    {
       
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            button1Text.text = "Button Activated";
            doorScript.Button1Activated();

            audioManager.playSFX(audioManager.buttonPressed);

            StartCoroutine(HideButtonText(button1Text));



        }
    }

    private IEnumerator HideButtonText(TextMeshProUGUI text)
    {
        yield return new WaitForSeconds(5f);
        text.text = "";
    }
}


