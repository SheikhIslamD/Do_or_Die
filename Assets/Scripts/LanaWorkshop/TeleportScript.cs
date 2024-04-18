using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Vector3 teleportDestination; // Assign the destination coordinates in the Unity editor

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has the "Player" tag
        {
            TeleportPlayer(other.transform); // Pass the Transform component
        }
    }

    private void TeleportPlayer(Transform playerTransform)
    {
        Debug.Log("Teleporting player to destination: " + teleportDestination);
        playerTransform.position = teleportDestination; // Set player's position to teleportDestination
        // You can optionally add some visual effects or animations here
        Debug.Log("Player teleported successfully!");
    }
}
