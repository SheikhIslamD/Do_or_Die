using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Door2Script : MonoBehaviour

{
    public Animator doorAnimator;
    public TextMeshProUGUI doorText;

    AudioManager audioManager;

    private bool Button3Activated = false;

    private void Start()
    {
        doorAnimator = GetComponent<Animator>();
        
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    public void NewButton1Activated()
    {
        Button3Activated = true;
        CheckButtonsActivation();
    }


    private void CheckButtonsActivation()
    {
        if (Button3Activated)
        {
            doorAnimator.SetTrigger("Open");
            doorText.text = "Door Opened!";
            StartCoroutine(ClearTextAfterDelay(5f)); // Clear text after 5 seconds

            audioManager.playSFX(audioManager.doorOpen);

        }
    }

    private IEnumerator ClearTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        doorText.text = "";
    }
}
