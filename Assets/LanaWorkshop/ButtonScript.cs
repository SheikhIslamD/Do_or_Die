using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public DoorScript doorScript;

    
void OnCollisionEnter(Collision collision)
{
    collision.gameObject.CompareTag("Player") = stringItem;
    pressedButtons.Add();

}
    

 




}
