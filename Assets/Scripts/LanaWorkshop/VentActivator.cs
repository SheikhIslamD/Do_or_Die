using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentActivator : MonoBehaviour
{
    public GameObject platform;
    public GameObject vent;
    public RotateScript scriptB;


    void Start()
    {
        scriptB = platform.GetComponent<RotateScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            scriptB.ventFlipActivated();

        }
    }


}
