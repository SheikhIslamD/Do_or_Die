using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public GameObject activator;
    public ActivatorScript script;

    void start()

{
    script = activator.GetComponent<ActivatorScript>();
}




 
}
