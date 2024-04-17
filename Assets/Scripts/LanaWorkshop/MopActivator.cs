using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopActivator : MonoBehaviour
{
    public GameObject objectToDestroy;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Head"))
        {
            Destroy(objectToDestroy);
            Destroy(gameObject);
            
        }


    }
}
