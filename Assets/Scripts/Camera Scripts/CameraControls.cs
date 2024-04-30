using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{
    public CinemachineBrain cinemachineBrain; // Reference to the Cinemachine Brain
	Gamepad gamepad = Gamepad.current;
	Mouse mouse = Mouse.current;
	[SerializeField] PauseScript pauseScript;

    private Vector2 lookInput;

    private void Awake()
    {
        pauseScript = GameObject.Find("UICanvas (working)").GetComponent<PauseScript>();
    }
    void Update()
    {
		ICinemachineCamera active = cinemachineBrain.ActiveVirtualCamera;
		GameObject camera = active.VirtualCameraGameObject;
		CinemachineVirtualCamera vcam = camera.GetComponent<CinemachineVirtualCamera>();
		CinemachinePOV pov = vcam.GetCinemachineComponent<CinemachinePOV>();
		
		if (!pauseScript.GameIsPaused)
		{
        // Check if the active input device is a controller
        if (gamepad != null)
        {
			if (mouse != null)
				mouse = null;
			
			if (vcam.Name == "Normal Camera")
			{
				pov.m_HorizontalAxis.m_MaxSpeed = 5f;
				pov.m_VerticalAxis.m_MaxSpeed = 5f;
			}
			else
			{
				pov.m_HorizontalAxis.m_MaxSpeed = 2.5f;
				pov.m_VerticalAxis.m_MaxSpeed = 2.5f;
			}
		}
		
		if (mouse != null)
		{
			if (gamepad != null)
				gamepad = null;
			
			if (vcam.Name == "Normal Camera")
			{
				pov.m_HorizontalAxis.m_MaxSpeed = 0.25f;
				pov.m_VerticalAxis.m_MaxSpeed = 0.25f;
			}
			else
			{
				pov.m_HorizontalAxis.m_MaxSpeed = 0.15f;
				pov.m_VerticalAxis.m_MaxSpeed = 0.15f;
			}
		}
		}
		else
		{
            // Check if the active input device is a controller
            if (gamepad != null)
            {
                if (mouse != null)
                    mouse = null;

                if (vcam.Name == "Normal Camera")
                {
                    pov.m_HorizontalAxis.m_MaxSpeed = 0f;
                    pov.m_VerticalAxis.m_MaxSpeed = 0f;
                }
                else
                {
                    pov.m_HorizontalAxis.m_MaxSpeed = 0f;
                    pov.m_VerticalAxis.m_MaxSpeed = 0f;
                }
            }

            if (mouse != null)
            {
                if (gamepad != null)
                    gamepad = null;

                if (vcam.Name == "Normal Camera")
                {
                    pov.m_HorizontalAxis.m_MaxSpeed = 0f;
                    pov.m_VerticalAxis.m_MaxSpeed = 0f;
                }
                else
                {
                    pov.m_HorizontalAxis.m_MaxSpeed = 0f;
                    pov.m_VerticalAxis.m_MaxSpeed = 0f;
                }
            }
        }

	}
}
