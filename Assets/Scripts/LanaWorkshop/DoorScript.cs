using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorScript : MonoBehaviour
{
    private Animator doorAnimator;
    public TextMeshProUGUI doorText;
    private bool button1Activated = false;
    private bool button2Activated = false;

    private void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    public void Button1Activated()
    {
        button1Activated = true;
        CheckButtonsActivation();
    }

    public void Button2Activated()
    {
        button2Activated = true;
        CheckButtonsActivation();
    }

    private void CheckButtonsActivation()
    {
        if (button1Activated && button2Activated)
        {
            doorAnimator.SetTrigger("Open");
            doorText.text = "Door Opened!";
            StartCoroutine(ClearTextAfterDelay(5f));

        }
    }
     private IEnumerator ClearTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        doorText.text = "";
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the "Close" animation
            doorAnimator.SetTrigger("Close");
        }
    }
}

 
