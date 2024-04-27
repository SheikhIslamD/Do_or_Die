using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LockIn : MonoBehaviour
{

    //Placeholder copy of Lock-On that I will adjust to the new setup yesyes

    public PlayerControls playerInput;

    [Header("Objects")]
    public Camera mainCamera; // main camera object.
    public CinemachineTargetGroup targetGroup;
    public CinemachineVirtualCamera lockOnCamera;
    //[SerializeField] private CinemachineFreeLook cinemachineFreeLook; //cinemachine free lock camera object.

    [Header("UI")]
    public GameObject lockOnIcon;  // ui image of aim icon 

    [Header("Settings")]
/*    [SerializeField] private string TargetTag; //Assign the target tag
    [SerializeField] private KeyCode _Input; //Assign the lock on input
    [SerializeField] private Vector2 targetLockOffset; //Tilts the camera when locked on so the player can see themselves and the target
    [SerializeField] private float minDistance; // minimum distance to stop rotation if you get close to target */
    [SerializeField] private float maxDistance = 25;

    public bool isTargeting = false;
    private float maxAngle = 135f; // always 90 to target enemies in front of camera.
    private Transform currentTarget;
/*    private float mouseX;
    private float mouseY;*/

    void Start()
    {
        playerInput = new PlayerControls();
        playerInput.Enable();

        maxDistance = 50;
        lockOnIcon = GameObject.Find("LockOn Icon");
        lockOnIcon.gameObject.SetActive(false);
        isTargeting = false;

        //targetGroup = targetGroup.GetComponent<CinemachineTargetGroup>();

        /*        maxAngle = 90f; 
                cinemachineFreeLook.m_XAxis.m_InputAxisName = "";
                cinemachineFreeLook.m_YAxis.m_InputAxisName = "";*/
    }

    void Update()
    {
        playerInput.Player.LockOn.performed += ctx => AssignTarget();

/*        if (!isTargeting)
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
        }
        else
        {
            NewInputTarget(currentTarget);
        }*/

        //if (lockOnIcon)
        if (isTargeting)
        {
        lockOnIcon.gameObject.SetActive(true);
        lockOnIcon.transform.position = mainCamera.WorldToScreenPoint(currentTarget.position);
        }

        /*        cinemachineFreeLook.m_XAxis.m_InputAxisValue = mouseX;
                cinemachineFreeLook.m_YAxis.m_InputAxisValue = mouseY;

                if (Input.GetKeyDown(_Input))
                {
                    AssignTarget();
                }*/
    }

    private void AssignTarget()
    {
        if (isTargeting)
        {
            lockOnCamera.Priority -= 10;
            targetGroup.RemoveMember(currentTarget);
            currentTarget = null;
            isTargeting = false;
            lockOnIcon.gameObject.SetActive(false);
            //Debug.Log("lock off");
            return;
        }

        if (!isTargeting && ClosestTarget())
        {
            lockOnCamera.Priority += 10;
            currentTarget = ClosestTarget().transform;
            targetGroup.AddMember(currentTarget, 2, 5);
            isTargeting = true;
            //Debug.Log("lock on");
        }

        //Debug.Log("lock on pressed");
    }

/*    private void NewInputTarget(Transform target) // sets new input value.
    {
        if (!currentTarget) return;

        Vector3 viewPos = mainCamera.WorldToViewportPoint(target.position);

        if (lockOnIcon)
            lockOnIcon.transform.position = mainCamera.WorldToScreenPoint(target.position);

        if ((target.position - transform.position).magnitude < minDistance) return;
        mouseX = (viewPos.x - 0.5f + targetLockOffset.x) * 3f;              // you can change the last value to make it faster or slower
        mouseY = (viewPos.y - 0.5f + targetLockOffset.y) * 3f;              // don't use delta time here.
    }*/


    private GameObject ClosestTarget() // Gets Closest Object with target tag 
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Target");
        GameObject closest = null;
        float distance = maxDistance;
        float currAngle = maxAngle;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.magnitude;
            if (curDistance < distance)
            {
                Vector3 viewPos = mainCamera.WorldToViewportPoint(go.transform.position);
                Vector2 newPos = new Vector3(viewPos.x - 0.5f, viewPos.y - 0.5f);
                if (Vector3.Angle(diff.normalized, mainCamera.transform.forward) < maxAngle)
                {
                    closest = go;
                    currAngle = Vector3.Angle(diff.normalized, mainCamera.transform.forward.normalized);
                    distance = curDistance;
                }
            }
        }
        return closest;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
