using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Should be Assigned")]
	public CharacterController controller;
	public Transform cam;
	public Animator animator;
    public PlayerControls playerInput;
	public GameObject diceProjectile;

    [Header("Numbers Stuff")]
    public int health = 6;
	public float speed = 7f;
	public float turnSmooth = 0.1f;
	public float jump = 2f;
	public float gravity = -9.81f;
	//for turning player to face cam
	public float rotationSpeed = 0f;


	float turnVelocity;
	float velocity;

	AudioManager audioManager;
    PauseScript pauseScript;

    [Header("UI Stuff")]
    public TextMeshProUGUI healthText;
    public Sprite[] healthHearts;
	public Image healthHud;

    private void Awake()
    {
		health = 6;
		healthHud = healthHud.GetComponent<Image>();
		healthHud.sprite = healthHearts[health];
		healthText.text = "Health: 6";
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        pauseScript = GameObject.Find("UICanvas (working)").GetComponent<PauseScript>();

        playerInput = new PlayerControls();
		playerInput.Enable();
		playerInput.Player.Jump.performed += ctx => Jump();
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
            diceProjectile.SetActive(false);

			pauseScript.GameOver();

            audioManager.playSFX(audioManager.lose);

			speed = 0f;
			jump = 0f;
        }
        else
        {
			healthText.text = "Health: " + health;
			audioManager.playSFX(audioManager.damage);
            healthHud.sprite = healthHearts[health];
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
