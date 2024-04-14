using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardsScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public ParticleSystem damageEffect;


void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            {
                playerMovement.DamageHealth();
            }
    
    }
void OnParticleCollision (GameObject other)
{
    if (other.CompareTag("Player"))
    {
        playerMovement.DamageHealth();
    }
}

}
