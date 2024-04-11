using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private int buttonCollisions = 0;

    public void CheckButtons()
    {
        buttonCollisions++;

        if (buttonCollisions >= 2)
        {
            OpenDoor(); // Call method to open the door
        }
    }

    private void OpenDoor()
    {
        GetComponent<Animator>().SetTrigger("Open");
    }
}

 
