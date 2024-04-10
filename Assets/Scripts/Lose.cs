using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public GameObject LoseUI;
    public GameObject UIHud;
    public bool mouseLookEnabled;
    public bool GameIsPaused;
    public Button[] levelButtons;

    public PlayerMovement playerScript;

    // Start is called before the first frame update
    void Start()
    {
        LoseUI.SetActive(false);
    }

    // Update is called once per frame
/*    void Update()
    {
        if (playerScript.health <= 0)
        {
            LoseUI.SetActive(true);
            GameIsPaused = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }*/

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Hub");
    }
}
