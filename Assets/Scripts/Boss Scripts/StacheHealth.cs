using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StacheHealth : MonoBehaviour
{
	public GameObject stache;
	public int health = 2;
    
	AudioManager audioManager;
	
	void Awake()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}
	
	public void DamageHealth()
    {
		health--;
		audioManager.playSFX(audioManager.damage);
		
		if (health <= 0)
		{
            Destroy(stache);
        }
	}
}
