using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
	public GameObject player;
	public int health = 3;
	public CharacterController controller;
	public Transform cam;
	public Animator animator; 
	public GameObject pauseMenu;

	public float speed = 7f;
	public float turnSmooth = 0.1f;
	float turnVelocity;
	public float jump = 2f;
	public float gravity = -9.81f;
	float velocity;
	public TextMeshProUGUI healthText;

	//for turning player to face cam
	public float rotationSpeed = 0f;
	public bool isAiming;

    public PlayerControls playerInput;
	public Lose lose;

	AudioManager audioManager;

	public MainMenu mainMenu;

    private void Awake()
    {
		healthText.text = "Health: 3";
        Cursor.lockState = CursorLockMode.Locked;
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
		
		playerInput = new PlayerControls();
		playerInput.Player.Jump.performed += ctx => Jump();
        playerInput.Player.Pause.performed += ctx => Pause();
    }
	
	private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Jump()
    {
        if (controller.isGrounded)
        {
            velocity = Mathf.Sqrt(jump * -2f * gravity);
            animator.SetBool("is_running", false);
            animator.SetBool("is_idle", false);
            animator.SetTrigger("jump");
        }
    }
	
	 private void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
	{
		Vector2 moveInput = playerInput.Player.Move.ReadValue<Vector2>();
		Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

		if (direction.magnitude >= 0.1f)
		{
			float orient = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, orient, ref turnVelocity, turnSmooth);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 move = Quaternion.Euler(0f, orient, 0f) * Vector3.forward;
			controller.Move(move.normalized * speed * Time.deltaTime);

			if (controller.isGrounded)
			{
				animator.SetBool("is_running", true);
				animator.SetBool("is_idle", false);
			}
		}
		else
		{
			if (controller.isGrounded)
			{
				animator.SetBool("is_running", false);
				animator.SetBool("is_idle", true);
			}
			else
			{
				animator.SetBool("is_running", false);
				animator.SetBool("is_idle", false);
			}
		}

		velocity += gravity * Time.deltaTime;
		controller.Move(new Vector3(0, velocity, 0) * Time.deltaTime);

		//makin player face where camera is facing when ADS is active
		Quaternion targetRotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

	public void DamageHealth()
    {
		health--;
		if (health <= 0)
		{
			Destroy(player.gameObject);
			lose.LoseUI.SetActive(true);
			lose.UIHud.SetActive(false);
			Cursor.lockState = CursorLockMode.None;

			audioManager.playSFX(audioManager.lose);
        }
        else
        {
			healthText.text = "Health: " + health;
			audioManager.playSFX(audioManager.damage);
		}
	}
	
	public void IncreaseHealth()
	{
		if (health < 3)
		{
			health++;
			healthText.text = "Health: " + health;
		}
	}
}
