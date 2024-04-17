using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{
    public GameObject followTransform;
    public Vector2 look;
    public float rotationPower = 0.5f;

    public PlayerControls playerInput;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
		
		playerInput = new PlayerControls();
    }
	
	private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 lookInput = playerInput.Player.Look.ReadValue<Vector2>();
		
        //rotate follow target based on mouse input
        followTransform.transform.rotation *= Quaternion.AngleAxis(lookInput.x * rotationPower, Vector3.up);
        followTransform.transform.rotation *= Quaternion.AngleAxis(lookInput.y * rotationPower, Vector3.right);
        var angles = followTransform.transform.localEulerAngles;
        angles.z = 0;
        var angle = followTransform.transform.localEulerAngles.x;

        //up down rotation clamps
        if (angle > 180 && angle <340)
        {
            angles.x = 340;
        }
        else if(angle < 180 && angle > 40)
        {
            angles.x = 40;
        }
        followTransform.transform.localEulerAngles = angles;

        //change player to rotate with mouse input too
        transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);
        //reset y rotation of look transform
        followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
    }
}
