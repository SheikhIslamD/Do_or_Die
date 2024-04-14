using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //displaying canvases
using UnityEngine.InputSystem; //needed for controller support
using UnityEngine.SceneManagement; //used for loading levels

public class MainMenu : MonoBehaviour
{
	public GameObject credits; //Will hold credits canvas
	public GameObject controls; //Will hold controls canvas
	public GameObject[] hands; //Hands for the menu
	public PlayerControls playerInput; //for controller support
	
	public bool stickMoved; //used to keep cursor slow
	public int i = 1; //keep track of hands with int
	
	/*  public AudioSource musicSource;
    public AudioClip buttonAudio;
    public AudioClip pauseAudio;
    public AudioClip pauseAmbiance;
    public AudioClip Ambience; */

	private void Awake()
	{
		playerInput = new PlayerControls();
		playerInput.Enable();
	}
	
	private void Update()
	{
		playerInput.Menu.Move.performed += ctx => Move();
		playerInput.Menu.Select.performed += ctx => Select();
	}
	
	//Will move cursor around screen based on active objects and player input
	private void Move()
	{
		Vector2 moveInput = playerInput.Menu.Move.ReadValue<Vector2>();
		
		//Stick not moved, resets bool
		if ((-0.2f < moveInput.x) && (moveInput.x < 0.2f))
			stickMoved = false;
		
		//Going to the left
		if (moveInput.x < -0.2f)
		{
			if (!stickMoved)
			{
				stickMoved = true;
				
				//Perform if no hands active
				if (hands[i].activeInHierarchy == false)
					hands[i].SetActive(true);
				else
				{
					//If not all the way left
					if (i > 0)
					{
						hands[i].SetActive(false);
						hands[i-1].SetActive(true);
						i--;
					}
					else
						i = 0;
				}
			}
		}
		
		//Going to the right
		if (moveInput.x > 0.2f)
		{
			if (!stickMoved)
			{
				stickMoved = true;
				
				//Perform if no hands active
				if (hands[i].activeInHierarchy == false)
					hands[i].SetActive(true);
				else
				{
					if (i < 3)
					{
						hands[i].SetActive(false);
						hands[i+1].SetActive(true);
						i++;
					}
					else
						i = 3;
				}
			}
		}
	}
	
	//Will select the option a hand is currently over
	private void Select()
	{
		//If controls menu on, turn it off
		if (controls.activeInHierarchy == true)
			back(controls);
		//If credits menu on, turn it off
		else if (credits.activeInHierarchy == true)
			back(credits);
		else
		{
			//If hand over controls, open controls menu
			if (hands[0].activeInHierarchy == true)
				control();
			//If hand over play, play the game.
			if (hands[1].activeInHierarchy == true)
				play();
			//If hand over credits, open credits menu
			if (hands[2].activeInHierarchy == true)
				credit();
			//If hands over quit, quit game
			if (hands[3].activeInHierarchy == true)
				quitGame();
		}
	}

	//Will load the hub world
    public void play()
    {
        SceneManager.LoadScene("MenuSelect");
    }

	//Will turn on the credits menu
    public void credit()
    {
        credits.SetActive(true);
    }

	//Will turn on the controls menu
    public void control()
    {
        controls.SetActive(true);
    }
	
	//Will turn whatever overlaying UI object is passed in
	public void back(GameObject ui)
	{
		ui.SetActive(false);
	}

    public void quitGame()
    {
        Application.Quit();
    }
}