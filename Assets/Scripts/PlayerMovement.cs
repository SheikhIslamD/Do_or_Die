using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{

	public int health = 3;
	public CharacterController controller;
	public Transform cam;

	public float speed = 7f;
	public float turnSmooth = 0.1f;
	float turnVelocity;
	public float jump = 2f;
	public float gravity = -9.81f;
	float velocity;
    // Update is called once per frame
    void Update()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

		if (Input.GetButtonDown("Jump") && controller.isGrounded)
		{
			velocity = Mathf.Sqrt(jump * -2f * gravity);
		}

		if (direction.magnitude >= 0.1f)
		{
			float orient = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, orient, ref turnVelocity, turnSmooth);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 move = Quaternion.Euler(0f, orient, 0f) * Vector3.forward;
			controller.Move(move.normalized * speed * Time.deltaTime);
		}

		velocity += gravity * Time.deltaTime;
		controller.Move(new Vector3(0, velocity, 0) * Time.deltaTime);
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
