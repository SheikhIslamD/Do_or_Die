using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorScript : MonoBehaviour
{
    public GameObject platform;
    public GameObject vent;
    public RotateScript scriptB;

    private Vector3 targetRotation = new Vector3(0f, 0f, 90f);

    void Start()
    {
        scriptB = platform.GetComponent<RotateScript>();
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Head"))
        {
            platform.transform.rotation = Quaternion.Euler(0, 0, 90);

            Destroy(gameObject);
        }
     

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            scriptB.ventFlipActivated();

        }
    }


}
