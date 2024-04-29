using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Talking : MonoBehaviour
{
    [Header("Assign Canvas UI")]
    public GameObject Dialogue;
    public GameObject SurpriseText;
    public GameObject ExplanationText;
    public GameObject ContinuedText;

    [Header("Assign Triggers")]
    public GameObject FinalText;
    public GameObject FirstTriggerRight;
    public GameObject SecondTriggerRight;
    public GameObject FirstTriggerLeft;
    public GameObject SecondTriggerLeft;
    /*
    [Header("Assign Colliders")]
    public BoxCollider FirstLeftCollider;
    public BoxCollider SecondLeftCollider;
    public BoxCollider FirstRightCollider;
    public BoxCollider SecondRightCollider;*/
    int textCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(ActivateCanvasForDuration(Dialogue, 2f));
        StartCoroutine(ActivateCanvasForDuration(SurpriseText, 2f));
    }

     void OnTriggerEnter(Collider other)
    {
        //Make sure the player can't launch the dice to activate the other yap sessions
        if (!other.CompareTag("Head"))
         {
            if (other.CompareTag("Player"))
            {
                // Check which yap session was triggered, so we can reuse this script
                if (gameObject.CompareTag("Text"))
                {
                    Debug.Log("Starting if");
                    //BoxCollider bc = GetComponent<BoxCollider>();
                    StartCoroutine(ActivateCanvasForDuration(Dialogue, 2f));
                    textCount++;
                    Debug.Log(textCount);
                    if (textCount == 1)
                    {
                        StartCoroutine(ActivateCanvasForDuration(ExplanationText, 2f));
                    }
                        
                        
                    if (textCount == 2)
                    {
                        StartCoroutine(ActivateCanvasForDuration(ContinuedText, 2f));
                    }
                        
                    if (textCount == 3)
                    {
                        StartCoroutine(ActivateCanvasForDuration(FinalText, 2f));

                    }
                        
                }
            }
        }
    }

    IEnumerator ActivateCanvasForDuration(GameObject name, float duration)
    {
        Debug.Log("Starting Co");
        // Activate the Canvas UI element
        name.SetActive(true);
        Debug.Log("Set active");
        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Deactivate the Canvas UI element after the duration
        name.SetActive(false);
        Debug.Log("Set active");
        //Destroy(bc);
        Debug.Log("Destroyed and ending co");
        
    }
}
