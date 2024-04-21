using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public GameObject activator;
    public ActivatorScript script;
    public Animator ventAnimator;

    private bool ventFlipped = false;

    AudioManager audioManager;

void Start()
{
    if (activator != null)
        script = activator.GetComponent<ActivatorScript>();

    ventAnimator = GetComponent<Animator>();

    GameObject audioObject = GameObject.FindGameObjectWithTag("Audio");
    if (audioObject != null)
    {
        audioManager = audioObject.GetComponent<AudioManager>();
        Debug.Log("AudioManager found and assigned successfully.");
    }
    else
    {
        Debug.LogError("AudioManager not found!");
    }
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

            audioManager.playSFX(audioManager.ventOpen);

        }
    }
}

