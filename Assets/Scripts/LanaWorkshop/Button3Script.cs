using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3Script : MonoBehaviour
{
    public Door2Script doorScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorScript.NewButton1Activated();
        }
    }
}
