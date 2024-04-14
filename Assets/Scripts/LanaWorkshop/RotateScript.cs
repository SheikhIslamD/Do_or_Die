using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public GameObject activator;
    public ActivatorScript script;
    private bool ventFlipped = false;
    public Animator ventAnimator;

    void start()

{
    script = activator.GetComponent<ActivatorScript>();
    ventAnimator = GetComponent<Animator>();
}

public void ventFlipActivated()
{
    ventFlipped = true;
    CheckVentActivation();
}

private void CheckVentActivation()
{
    if (ventFlipped)
    {
        ventAnimator.SetTrigger("Flip");
        
    }
}




 
}
