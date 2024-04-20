using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallActivator : MonoBehaviour
{
    public WallBehaviorScript wallBehaviorScript;


 void OnCollisionEnter(Collision collision)
 {
    if (collision.gameObject.CompareTag("Head"))
    {
        wallBehaviorScript.DestroyGameObject();

        Destroy(gameObject);
    }
 }
}
