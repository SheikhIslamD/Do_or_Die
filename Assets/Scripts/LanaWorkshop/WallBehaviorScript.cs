using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WallBehaviorScript : MonoBehaviour
{
    public TextMeshProUGUI secretDoorText;
 
 public void DestroyGameObject()
    {
        Destroy(gameObject);

        CoroutineManager.Instance.StartHideButtonTextCoroutine(secretDoorText);
        secretDoorText.text = "A passage has been revealed";

    }

}
