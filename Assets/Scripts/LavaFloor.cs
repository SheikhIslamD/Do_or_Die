using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloor : MonoBehaviour
{
	public GameObject player;
	public PlayerMovement playerScript;
	public Transform respawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

	// This function is called when the collider on this GameObject collides with another collider
	private void OnTriggerEnter(Collider other)
	{
		// Check if the collider we collided with has the Zone tag
		if (other.CompareTag("Player"))
		{
			player.SetActive(false);
			other.transform.position = respawn.position;
			player.SetActive(true);
			Debug.Log("PLayer stepped in lava");
			playerScript.DamageHealth();
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
