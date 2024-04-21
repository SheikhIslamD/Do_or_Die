using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallActivator : MonoBehaviour
{
    public WallBehaviorScript wallBehaviorScript;

    //AudioManager audioManager;


void start()
{
    //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
}
 void OnCollisionEnter(Collision collision)
 {
    if (collision.gameObject.CompareTag("Head"))
    {
        //audioManager.playSFX(audioManager.wallDestroyed);

        wallBehaviorScript.DestroyGameObject();

        Destroy(gameObject);
    }
 }
}
