using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Victory : MonoBehaviour
{
	public GameObject[] hands;
	public PlayerControls playerInput;
    public GameObject creditsPanel;

    public bool stickMoved; //used to keep cursor slow
	public int i = 1; //keep track of hands with int

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
					//if not all the way right
					if (i < 2)
					{
						hands[i].SetActive(false);
						hands[i+1].SetActive(true);
						i++;
					}
					else
						i = 2;
				}
			}
		}
	}
	
	//Will select the option a hand is currently over
	private void Select()
	{
		//If controlsPanel menu on, turn it off
		if (creditsPanel.activeInHierarchy == true)
			back(creditsPanel);
		else
		{
			//If hand over quit, go to main menu/hub
			if (hands[0].activeInHierarchy == true)
				quitGame();
			//If hand over Resume, Resume game
			if (hands[1].activeInHierarchy == true)
				mainMenu();
			//If hand over controlsPanel, pul up controlsPanel
			if (hands[2].activeInHierarchy == true)
				credits();
		}
	}

	public void quitGame()
    {
        Application.Quit();
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void credits()
    {
        creditsPanel.SetActive(true);
    }
    public void back(GameObject ui)
    {
        ui.SetActive(false);
    }
}