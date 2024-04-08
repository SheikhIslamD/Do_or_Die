using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject LevelSelectUI;
    public bool mouseLookEnabled;
    public bool GameIsPaused;
    public Button[] levelButtons;

    // Start is called before the first frame update
    void Start()
    {
        //LevelSelectUI.SetActive(false);
        //the last number is whatever number scene level select is in build settings
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        //buttons after 1 are made uninteractable
        //for (int i = 0; i < levelButtons.Length; i++)
        //{
            //if (i + 2 > levelAt)
                //levelButtons[i].interactable = false;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LevelSelectUI.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            LevelSelectScreen();
        }
    }

    public void LevelSelectScreen()
    {
        LevelSelectUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }    

    public void Level1()
    {
        SceneManager.LoadScene(3);
        Debug.Log("Platform level loaded");
    }

    public void Level2()
    {
        SceneManager.LoadScene("MazePrototype");
    }

    public void BossLevel()
    {
        SceneManager.LoadScene("BossPrototype");
    }

    public void Exit()
    {
        LevelSelectUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
