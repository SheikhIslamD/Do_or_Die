using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class Button2Script : MonoBehaviour
{
    public TextMeshProUGUI button2Text;
    public DoorScript doorScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            button2Text.text = "Button Activated";
            doorScript.Button2Activated();

            StartCoroutine(HideButtonText(button2Text));
        }
    }

     private IEnumerator HideButtonText(TextMeshProUGUI text)
    {
        yield return new WaitForSeconds(5f);
        text.text = "";
    }
}

