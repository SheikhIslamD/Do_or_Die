using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinDoor : MonoBehaviour
{
    public GameObject WinUI;
    public GameObject UIHud;
    public bool mouseLookEnabled;
    public bool GameIsPaused;
    public Button[] levelButtons;

    void Start()
    {
        WinUI.SetActive(false);
        UIHud.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WinUI.SetActive(true);
            //Time.timeScale = 0f;
            GameIsPaused = true;
            UIHud.SetActive(false);
            Debug.Log("You Win!");
        }
    }

    public void WinScreen()
    {
        WinUI.SetActive(true);
        GameIsPaused = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
