using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardsScript : MonoBehaviour
{
    public PlayerMovement playerMovement;


void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            {
                playerMovement.DamageHealth();
            }
    
    }


}
