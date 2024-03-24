using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiceThrow : MonoBehaviour
{
    public GameObject dice;
    public float throwForce, upwardForce;
    public float cooldown;
    public bool diceHeld, diceLanded;
    public Camera camera;
    public Transform headPoint;
    //for bug fixing?
    public bool allowInvoke = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //currently not working?
        if (diceHeld && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Throw();
        }
    }

    public void Throw()
    {        
        //dice is no longer on head and is considered thrown
        diceHeld = false;
       
        //hit position using raycast
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        
        //raycast hit check
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);
        
        //headpoint to target point direction calculation
        Vector3 direction = targetPoint - headPoint.position;

        //spawn dice off of head
        GameObject diceInThrow = Instantiate(dice,headPoint.position, Quaternion.identity);

        //add forces to the thrown dice to appear as rolling (including upward force if needed)
        diceInThrow.GetComponent<Rigidbody>().AddForce(direction.normalized * throwForce, ForceMode.Impulse);
        diceInThrow.GetComponent<Rigidbody>().AddForce(camera.transform.up * upwardForce, ForceMode.Impulse);

        //start cooldown (currently not working?)
        if (allowInvoke)
        {
            Invoke("Cooldown", cooldown);
            allowInvoke = false;
        }
    }

    private void Cooldown()
    {
        diceHeld = true;
        allowInvoke = true;
    }
}
