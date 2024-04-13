using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yapanese : MonoBehaviour
{
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
        }

        if (triggerTag == "HowToDice")
        {
            // Do something when the trigger collider's tag matches the specified tag
            Debug.Log("How to dice");
        }

        if (triggerTag == "HowToWall")
        {
            // Do something when the trigger collider's tag matches the specified tag
            Debug.Log("Is this a dead end...?");
        }
    }
}
