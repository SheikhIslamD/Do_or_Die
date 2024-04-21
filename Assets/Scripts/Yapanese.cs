using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Yapanese : MonoBehaviour
{
    public GameObject Tutorial;
    public GameObject JumpText;
    public GameObject CardText;

    private void OnTriggerEnter(Collider other)
    {
        //Make sure the player can't launch the dice to activate the other yap sessions
        if (!other.CompareTag("Head"))
        {
            // Check which yap session was triggered, so we can reuse this script
            if (gameObject.CompareTag("EndTutorialText"))   //keep this first, it is used most often (optimization)
            {
                CardText.SetActive(false);
                JumpText.SetActive(false);
                Tutorial.SetActive(false);
            }
            else if (gameObject.CompareTag("HowToJump"))
            {
                Tutorial.SetActive(true);
                CardText.SetActive(false);
                JumpText.SetActive(true);
            }
            else if (gameObject.CompareTag("HowToCard"))
            {
                JumpText.SetActive(false);
                CardText.SetActive(true);
                Tutorial.SetActive(true);
                
            }
        }
    }
}
