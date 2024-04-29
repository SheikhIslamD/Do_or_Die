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
    public GameObject FinalText;

    [Header("Assign Triggers")]
    public GameObject FirstTriggerRight;
    public GameObject SecondTriggerRight;
    public GameObject FirstTriggerLeft;
    public GameObject SecondTriggerLeft;
    [Header("I can't believe it's come to this")]
    public Count CountReference;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivateCanvasForDuration(Dialogue, 8f));
        StartCoroutine(ActivateCanvasForDuration(SurpriseText, 8f));
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
                    BoxCollider bc = GetComponent<BoxCollider>();
                    StartCoroutine(ActivateCanvasForDuration(Dialogue, 8f, bc));
                    CountReference.textCount++;
                    Debug.Log(CountReference.textCount);
                    if (CountReference.textCount == 1)
                        StartCoroutine(ActivateCanvasForDuration(ExplanationText, 8f, bc));
                    if (CountReference.textCount == 2)
                        StartCoroutine(ActivateCanvasForDuration(ContinuedText, 8f, bc));
                    if (CountReference.textCount == 3)
                        StartCoroutine(ActivateCanvasForDuration(FinalText, 8f, bc));
                }
            }
        }
    }

    IEnumerator ActivateCanvasForDuration(GameObject name, float duration)
    {
        // Activate the Canvas UI element
        name.SetActive(true);
        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Deactivate the Canvas UI element after the duration
        name.SetActive(false);

    }

    IEnumerator ActivateCanvasForDuration(GameObject name, float duration, Component bc)
    {
        Destroy(bc);
        Debug.Log("Starting Co");
        // Activate the Canvas UI element
        name.SetActive(true);
        Debug.Log("Set active");
        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Deactivate the Canvas UI element after the duration
        name.SetActive(false);
        Debug.Log("Set active");
        
        Debug.Log("Destroyed and ending co");
        
    }
}
