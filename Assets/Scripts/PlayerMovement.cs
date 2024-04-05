using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{

	public int health = 3;
	public CharacterController controller;
	public Transform cam;
	public Animator animator; 

	public float speed = 7f;
	public float turnSmooth = 0.1f;
	float turnVelocity;
	public float jump = 2f;
	public float gravity = -9.81f;
	float velocity;

	//for turning player to face cam
	public float rotationSpeed = 0f;
	public bool isAiming;
    //set up input system for future (we may need to rebind controls for gamepad support (assignment requirement)
    [SerializeField]
    private PlayerInput playerInput;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

		if (Input.GetButtonDown("Jump") && controller.isGrounded)
		{
			velocity = Mathf.Sqrt(jump * -2f * gravity);
			animator.SetBool("is_running", false);
			animator.SetBool("is_idle", false);
			animator.SetTrigger("jump");
		}

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
			// TODO: In the appropriate script, call:   animator.SetTrigger("throw");  when the player throws the die. 

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

	// This function is called when the collider on this GameObject collides with another collider
	private void OnTriggerEnter(Collider other)
	{
		// Check if the collider we collided with has the Zone tag
		if (other.CompareTag("Zone"))
		{
			DamageHealth();
		}
	}

	public void DamageHealth()
    {
		health--;
		if (health == 0)
		{
			Debug.Log("Game Over");
			SceneManager.LoadScene("LoseScreen");
		}
        else
        {
			Debug.Log("Your health is now: " + health);
		}
	}
}
