using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class Button1Script : MonoBehaviour
{
    public TextMeshProUGUI button1Text;
    public DoorScript doorScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            button1Text.text = "Button Activated";
            doorScript.Button1Activated();

            StartCoroutine(HideButtonText(button1Text));
        }
    }

    private IEnumerator HideButtonText(TextMeshProUGUI text)
    {
        yield return new WaitForSeconds(5f);
        text.text = "";
    }
}


