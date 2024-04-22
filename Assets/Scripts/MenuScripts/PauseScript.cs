using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;
using TMPro;

public class PauseScript : MonoBehaviour
{
    [Header("Should be Assigned")]
    public GameObject endPanel;
    public TextMeshProUGUI endText;
    public GameObject pausePanel;
	public GameObject controlsPanel;
	public GameObject victoryPanel;
	public TextMeshProUGUI scoreDisplay;

    [Header("Visible For Debug")]
    public bool GameIsPaused = false;
	public bool gameOver = false;

    GameObject player;
	AudioManager audioManager;
	[SerializeField] ScoreTracker scoreTracker;

    [Header("Controls Stuff")]
    public GameObject[] hands;
	public PlayerControls playerInput;
	public bool stickMoved; //used to keep cursor slow
	public int i = 1; //keep track of hands with int


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        gameOver = false;
		endPanel.SetActive(false);

        playerInput = new PlayerControls();
		playerInput.Enable();
		Resume();

        scoreTracker = GameObject.Find("ScoreManager").GetComponent<ScoreTracker>();
		scoreDisplay = GameObject.Find("Score Display").GetComponent<TextMeshProUGUI>();
		scoreDisplay.text = "Levels\r\n" + scoreTracker.scoreCount + " of 4";

		victoryPanel.SetActive(false);
		pausePanel.SetActive(false);
		controlsPanel.SetActive(false);
	}

	private void Update()
	{
		playerInput.Menu.Move.performed += ctx => Move();
		playerInput.Menu.Select.performed += ctx => Select();
		playerInput.Menu.Pause.performed += ctx => Pause();
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
						hands[i - 1].SetActive(true);
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
						hands[i + 1].SetActive(true);
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
		if (controlsPanel.activeInHierarchy == true)
			back(controlsPanel);
		else
		{
			//If hand over quit, go to main menu/hub
			if (hands[0].activeInHierarchy == true)
				mainMenu();
			//If hand over Resume, Resume game
			if (hands[1].activeInHierarchy == true)
				Resume();
			//If hand over controlsPanel, pul up controlsPanel
			if (hands[2].activeInHierarchy == true)
				control();
		}
	}

	public void Pause()
	{
		if (!gameOver)
		{
			if (GameIsPaused)
			{
				Resume();
			}
			else
            {
                controlsPanel.SetActive(false);
                audioManager.playSFX(audioManager.pause);
				pausePanel.SetActive(true);
				Time.timeScale = 0f;
				GameIsPaused = true;
				Cursor.lockState = CursorLockMode.None;
			}
		}

	}
	public void Resume()
	{
		if (!gameOver)
        {
            controlsPanel.SetActive(false);
            pausePanel.SetActive(false);
			Time.timeScale = 1f;
			GameIsPaused = false;
			Cursor.lockState = CursorLockMode.Locked;
		}

	}

	public void GameOver()
	{
		Pause();
		gameOver = true;
		pausePanel.SetActive(false);
        if (player.GetComponent<PlayerMovement>().health > 0)
		{
			scoreTracker.scoreUp();
			endText.text = "Level Complete!";
		}
		else
		{
            endText.text = "Level Failed!";
		}
        endPanel.SetActive(true);
    }

    public void Victory()
    {
        Pause();
        gameOver = true;
        pausePanel.SetActive(false);
		endPanel.SetActive(false);
        victoryPanel.SetActive(true);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
	
	//Will turn on the controlsPanel menu
    public void control()
    {
        controlsPanel.SetActive(true);
    }

    public void back(GameObject ui)
	{
		ui.SetActive(false);
	}

	public void quitGame()
	{
		Application.Quit();
	}

	public void hubLevel()
	{
		SceneManager.LoadScene("Hub");
	}
}