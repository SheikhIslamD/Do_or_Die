using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloor : MonoBehaviour
{
	PlayerMovement playerScript;

	// This function is called when the collider on this GameObject collides with another collider
	private void OnCollisionEnter(Collision other)
	{
		// Check if the collider we collided with has the Zone tag
		if (other.gameObject.CompareTag("Player"))
		{
			playerScript.DamageHealth();
			Debug.Log("PLayer stepped in lava");
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
