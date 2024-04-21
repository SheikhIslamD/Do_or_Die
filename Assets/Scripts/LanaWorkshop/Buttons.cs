using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Buttons : MonoBehaviour
{
    public TextMeshProUGUI button1Text;
    //public TextMeshProUGUI button2Text;
    public TextMeshProUGUI CounterText;
    public DoorScript doorScript;
    public Door2Script doorScript2;
    
    AudioManager audioManager;
    //public int pressed = 0;

    private void Start()
    {

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Button1"))
            {
                button1Text.text = "Button Activated";
                doorScript2.pressed++;
                //Debug.Log(pressed);
                doorScript.Button1Activated();
                audioManager.playSFX(audioManager.buttonPressed);
                CounterText.text = "Buttons Activated: " + doorScript2.pressed + "/3";
                StartCoroutine(HideButtonText(button1Text));
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Button2"))
            {
                button1Text.text = "Button Activated";
                doorScript2.pressed++;
                //Debug.Log(doorScript2.pressed);
                doorScript.Button2Activated();
                audioManager.playSFX(audioManager.buttonPressed);
                CounterText.text = "Buttons Activated: " + doorScript2.pressed + "/3";
                StartCoroutine(HideButtonText(button1Text));
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Button3"))
            {
                button1Text.text = "Button Activated";
                doorScript2.pressed++;
                //Debug.Log(pressed);
                doorScript2.NewButton1Activated();
                audioManager.playSFX(audioManager.buttonPressed);
                CounterText.text = "Buttons Activated: " + doorScript2.pressed + "/3";
                StartCoroutine(HideButtonText(button1Text));
                Destroy(gameObject);
            }
            

            
        }
    }

    private IEnumerator HideButtonText(TextMeshProUGUI text)
    {
        yield return new WaitForSeconds(5f);
        text.text = "";
    }
}

