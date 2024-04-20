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
    // This function is called when the collider on this GameObject collides with another collider
    private void OnTriggerEnter(Collider other)
    {
        // Get the tag of the trigger collider
        string triggerTag = gameObject.tag;

        // Check if the trigger collider has a specific tag
        if (triggerTag == "HowToJump")
        {
            // Do something when the trigger collider's tag matches the specified tag
            Debug.Log("How to jump");
            Tutorial_Dialogue.SetActive(true);
        }

        if (triggerTag == "HowToDice")
        {
            // Do something when the trigger collider's tag matches the specified tag
            Debug.Log("How to dice");
            //Stache_Text_Vent.SetActive(false);
            //Stache_Text_Jump.SetActive(true);

        }

        if (triggerTag == "HowToWall")
        {
            // Do something when the trigger collider's tag matches the specified tag
            Debug.Log("Is this a dead end...?");
        }
    }
}
