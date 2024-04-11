using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public DoorScript doorScript;
    public Text messageText; // Reference to the UI Text component

    private bool isCollided = false; // This line declares the isCollided variable

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isCollided)
        {
            isCollided = true; // This line sets isCollided to true
            doorScript.CheckButtons();
            DisplayMessage("Button pressed!");
        }
    }

    private void DisplayMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
        }
        else
        {
            Debug.LogWarning("UI Text component not assigned in ButtonScript.");
        }
    }

}