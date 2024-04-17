using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class AimCamSwitching : MonoBehaviour
{
	//This will be the aim cam's position
    [SerializeField]
    private CinemachineVirtualCamera aimCamera;
    
    public PlayerControls playerInput;
    private InputAction aimAction;
    private PlayerMovement playerMovement; //Used to change rotation speed

    private void Awake()
    {
        playerInput = new PlayerControls();
		playerInput.Enable();
        aimAction = playerInput.Player.Aim;
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }

    private void StartAim()
    {
        aimCamera.Priority += 10;
        playerMovement.rotationSpeed = 50f;
    }

    private void CancelAim()
    {
        aimCamera.Priority -= 10;
        playerMovement.rotationSpeed = 0f;
    }
}
