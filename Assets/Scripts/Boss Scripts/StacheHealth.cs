using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StacheHealth : MonoBehaviour
{
	public GameObject stache;
	public int health = 2;
	//public TextMeshProUGUI healthCounter;
	AudioManager audioManager;
    //PauseScript pauseScript;
	public bool isDead;

    [Header("UI Stuff")]
    public Sprite[] healthHearts;
    public Image healthBar;

    void Awake()
	{
        health = 2;
        healthBar = healthBar.GetComponent<Image>();
        healthBar.sprite = healthHearts[health];
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        //pauseScript = GameObject.Find("UICanvas (working)").GetComponent<PauseScript>();
    }
	
	public void DamageHealth()
    {
		health--;
        //healthCounter.text = "Stache HP: " + health;
        audioManager.playSFX(audioManager.damage);
        healthBar.sprite = healthHearts[health];

        if (health <= 0)
		{
            //pauseScript.GameOver();

			isDead = true;

            //audioManager.playSFX(audioManager.win);
        }
	}
}
