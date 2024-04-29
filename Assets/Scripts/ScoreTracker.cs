using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public static ScoreTracker instance;
    
    [Header("Hub only")]
    [SerializeField] Menu menuScript;

    [Header("Dice Collected")]
    public bool bodyDice = false;
    public bool mindDice = false;
    public bool soulDice = false;

    [Header("UI Related")]
    [SerializeField] PauseScript pauseScript;
    //[SerializeField] TextMeshProUGUI diceNameText;

    //[SerializeField] GameObject prefabUI;
    //[SerializeField] GameObject menuScript;
    //public int scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        //SceneManager.activeSceneChanged += ChangedActiveScene;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //prefabUI = GameObject.Find("UICanvas (working)");
        pauseScript = GameObject.Find("UICanvas (working)").GetComponent<PauseScript>();
        //diceNameText = prefabUI.transform.Find("EndPanel/Dice Name").GetComponent<TextMeshProUGUI>();

        if (scene.name == "Hub")
        {
            menuScript = GameObject.Find("UICanvas (working)").GetComponent<Menu>();
            
            if (bodyDice && mindDice)
            {
                menuScript.UnlockBoss();
            }

        }
    }

    public void ResetCollected()
    {
        bodyDice = false;
        mindDice = false;
        soulDice = false;
    }

    public void DiceCollected()
    {
        //check if the level is platformer
        if (SceneManager.GetActiveScene().name == "PlatformerPrototype")
        {
            Color bodyColor = new Vector4(255, 127, 161, 255);
            bodyDice = true;
            pauseScript.diceNameText.text = "Body Dice";
            pauseScript.diceNameText.color = bodyColor;
            //red glow
        }

        //check if the level is maze
        if (SceneManager.GetActiveScene().name == "MazePrototype")
        {
            Color mindColor = new Vector4(127, 161, 255, 255);
            mindDice = true;
            pauseScript.diceNameText.text = "Mind Dice";
            pauseScript.diceNameText.color = mindColor;
            //blue glow
        }

        //check if the level is boss
        if (SceneManager.GetActiveScene().name == "BossPrototype")
        {
            Color soulColor = new Vector4(127, 255, 161, 255);
            soulDice = true;
            pauseScript.diceNameText.text = "Soul Dice";
            pauseScript.diceNameText.color = soulColor;
            //green glow
        }

        if (bodyDice && mindDice && soulDice)
        {
            Color ALLColor = new Vector4(255, 125, 255, 255);
            pauseScript.Victory();
            pauseScript.endText.text = "VICTORY!!";
            pauseScript.diceNameText.text = "ALL Dice";
            pauseScript.diceNameText.color = ALLColor;
            //diceNameText.color = soulColor;
        }


    }


/*    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;
        string nextName = next.name;

        if (nextName == "Hub")
        {
            // Scene1 has been removed
            currentName = "Replaced";
        }

        Debug.Log("Scenes: " + currentName + ", " + next.name);
    }*/

    /*    public void scoreUp()
        {
            scoreCount++;
            if (scoreCount == 4)
            {
                pauseScript = GameObject.Find("UICanvas (working)").GetComponent<PauseScript>();
                pauseScript.Victory();
            }
        }*/
}
