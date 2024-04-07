using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupHolderTeleport : MonoBehaviour
{
    public Transform player, destination;
    public GameObject playerG;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerG.SetActive(false);
            other.transform.position = destination.position;
            playerG.SetActive(true);
            Debug.Log("Transported to the inside of the table");
        }
    }

}
