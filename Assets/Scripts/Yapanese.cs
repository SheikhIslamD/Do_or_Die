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
    public GameObject WallText;
    public GameObject AwakeText;

    public void Start()
    {
        Tutorial.SetActive(true);
        AwakeText.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Make sure the player can't launch the dice to activate the other yap sessions
        if (!other.CompareTag("Head"))
        {
            // Check which yap session was triggered, so we can reuse this script
            if (gameObject.CompareTag("EndTutorialText"))   //keep this first, it is used most often (optimization)
            {
                WallText.SetActive(false);
                CardText.SetActive(false);
                JumpText.SetActive(false);
                Tutorial.SetActive(false);
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("HowToJump"))
            {
                Tutorial.SetActive(true);
                WallText.SetActive(false);
                CardText.SetActive(false);
                JumpText.SetActive(true);
                AwakeText.SetActive(false);
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("HowToCard"))
            {
                JumpText.SetActive(false);
                CardText.SetActive(true);
                WallText.SetActive(false);
                Tutorial.SetActive(true);
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("HowToWall"))
            {
                JumpText.SetActive(false);
                CardText.SetActive(false);
                WallText.SetActive(true);
                Tutorial.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
