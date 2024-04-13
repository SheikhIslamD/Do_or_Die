using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class WinLose : MonoBehaviour
{
    public GameObject hud;
	public TextMeshProUGUI text;
	public GameObject[] hands;
    public PlayerControls playerInput;
	public GameObject player;

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
		
		if (player.GetComponent<PlayerMovement>().health > 0)
			text.text = "You Win!";
		else
			text.text = "You Lose!";
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
		//If hand over replay, replay level
		if (hands[0].activeInHierarchy == true)
			replay();
		//If hand over main menu, go to title
		if (hands[1].activeInHierarchy == true)
			mainMenu();
		//If hand over quit, quit game.
		if (hands[2].activeInHierarchy == true)
			quitGame();
	}

	public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
	
	public void quitGame()
    {
        Application.Quit();
    }
}