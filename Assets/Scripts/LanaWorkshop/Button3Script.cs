using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button3Script : MonoBehaviour
{
    public Door2Script doorScript;
    public TextMeshProUGUI button1Text;
    AudioManager audioManager;
    public TextMeshProUGUI CounterText;
    private int pressed = 0;

    private void Start()
    {
        
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            button1Text.text = "Button Activated";
            pressed++;
            doorScript.NewButton1Activated();
            audioManager.playSFX(audioManager.buttonPressed);
            CounterText.text = "Buttons Activated: " + pressed;
            StartCoroutine(HideButtonText(button1Text));
            Destroy(gameObject);
        }
    }



        private IEnumerator HideButtonText(TextMeshProUGUI text)
    {
        yield return new WaitForSeconds(5f);
        text.text = "";
    }
}
