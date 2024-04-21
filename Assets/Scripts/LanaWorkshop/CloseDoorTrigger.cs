using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorTrigger : MonoBehaviour
{
    public Animator doorAnimator;
    public GameObject doorObject;

    private void Start()
    {
        // Get the Animator component from the door GameObject
        doorAnimator = doorObject.GetComponent<Animator>();
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player exited the trigger, open the door (if needed)
            doorAnimator.SetTrigger("Lock");
        }
    }
}
