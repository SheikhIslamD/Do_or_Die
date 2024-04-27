using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StacheHealth : MonoBehaviour
{
	public GameObject stache;
	public int health = 2;
	public TextMeshProUGUI healthCounter;
	AudioManager audioManager;
    PauseScript pauseScript;
	public bool isDead;

    void Awake()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        pauseScript = GameObject.Find("UICanvas (working)").GetComponent<PauseScript>();
    }
	
	public void DamageHealth()
    {
		health--;
        healthCounter.text = "Stache HP: " + health;
        audioManager.playSFX(audioManager.damage);
		
		if (health <= 0)
		{
            //pauseScript.GameOver();

			isDead = true;

            //audioManager.playSFX(audioManager.win);
        }
	}
}
