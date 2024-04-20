using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Yapanese : MonoBehaviour
{
    public GameObject Tutorial_Dialogue;
    private void Awake()
    {
        //talkText = GameObject.Find("Tutorial_Dialogue").GetComponent<PauseScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Make sure the player can't launch the dice to activate the other yap sessions
        if (!other.CompareTag("Head"))
        {
            // Check which yap session was triggered, so we can reuse this script
            if (gameObject.CompareTag("HowToJump"))
            {
                Debug.Log("How To Jump");
                Tutorial_Dialogue.SetActive(true);
            }
            else if (gameObject.CompareTag("Tag2"))
            {

                Debug.Log("Collision with Tag2");
            }
            else if (gameObject.CompareTag("Tag3"))
            {

                Debug.Log("Collision with Tag3");

            }
        }
    }
}
