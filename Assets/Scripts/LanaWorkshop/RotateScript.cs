using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public GameObject activator;
    public ActivatorScript script;
    public Animator ventAnimator;

    private bool ventFlipped = false;

   public string triggeredAnimationState = "Flip";
   public string revertAnimationState = "Closed";
   public float resetTime = 7f;
   private float timer = 3f;


void Update()
{
    if (ventFlipped)
    {
        timer += Time.deltaTime;

        if (timer >= resetTime)
        {
            ResetAnimation();
        }
    }
}

void start()

{
    script = activator.GetComponent<ActivatorScript>();
    ventAnimator = GetComponent<Animator>();

}

public void ventFlipActivated()
{
    ventFlipped = true;
    CheckVentActivation();
    Invoke("ResetAnimation" , 3f);
}

private void CheckVentActivation()
{
    if (ventFlipped)
    {
        ventAnimator.SetTrigger("Flip");
        
    }
}

private void ResetAnimation()
{
    ventAnimator.SetTrigger("Closed"); // Play the triggered animation state from the beginning
    ventFlipped = false;
}



 
}
