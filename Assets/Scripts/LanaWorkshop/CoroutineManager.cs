using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager instance;
    public static CoroutineManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject managerObject = new GameObject("CoroutineManager");
                instance = managerObject.AddComponent<CoroutineManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartHideButtonTextCoroutine(TextMeshProUGUI text)
    {
        StartCoroutine(HideButtonText(text));
    }

    private IEnumerator HideButtonText(TextMeshProUGUI text)
    {
        yield return new WaitForSeconds(5f);
        text.text = "";
    }
}
