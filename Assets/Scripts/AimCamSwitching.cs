using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class AimCamSwitching : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera aimCamera;
    
    private PlayerInput playerInput;
    private InputAction aimAction;

    //trying it this way to see, maybe will change it
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        aimAction = playerInput.actions["Aim"];
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

/*    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
