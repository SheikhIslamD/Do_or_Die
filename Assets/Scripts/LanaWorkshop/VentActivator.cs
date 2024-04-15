using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentActivator : MonoBehaviour
{
 
    public GameObject vent;
    public RotateScript scriptB;


    void Start()
    {
        scriptB = vent.GetComponent<RotateScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            scriptB.ventFlipActivated();

            Destroy(gameObject);

        }
    }


}
