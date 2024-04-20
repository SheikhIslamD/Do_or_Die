using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button3Script : MonoBehaviour
{
    public Door2Script doorScript;
    public TextMeshProUGUI button1Text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            button1Text.text = "Button Activated";
            doorScript.NewButton1Activated();

            StartCoroutine(HideButtonText(button1Text));
        }
    }



        private IEnumerator HideButtonText(TextMeshProUGUI text)
    {
        yield return new WaitForSeconds(5f);
        text.text = "";
    }
}
