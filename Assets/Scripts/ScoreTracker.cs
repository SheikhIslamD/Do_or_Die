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
    [SerializeField] GameObject mindDicePrefab;
    public bool mazeCompleted = false;

    [Header("Dice Collected")]
    public bool bodyDice = false;
    public bool mindDice = false;
    public bool soulDice = false;

    //public bool cutScenePlayed = false;

    [Header("UI Related")]
    [SerializeField] PauseScript pauseScript;

    [Header("Hub cutscene")]
    [SerializeField] HubCutscene hubCutscene;
    public bool openingDone;
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

        //cutScenePlayed = false;
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

            //cutScenePlayed = true;
            hubCutscene = GameObject.Find("Opening Cutscene Anchor").GetComponent<HubCutscene>(); Debug.Log("Found hubCutscene");
            
            if (hubCutscene.cutScenePlayed)
            {
                openingDone = true;
            }

            if (openingDone)
            {
                hubCutscene.selfDestruct();
                Debug.Log("Self destructing");
            }

            if (mazeCompleted && !mindDice)
            {
                Object.Instantiate(mindDicePrefab, new Vector3(0, -8, -32), Quaternion.identity);
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
            //Color bodyColor = new Vector4(255, 127, 161, 255);
            bodyDice = true;
            pauseScript.diceNameText.text = "Body Dice";
            //pauseScript.diceNameText.color = bodyColor;
            //red glow
        }

        //check if the level is HUB instead of maze cause that broke
        if (SceneManager.GetActiveScene().name == "Hub")
        {
            //Color mindColor = new Vector4(127, 161, 255, 255);
            mindDice = true;
            pauseScript.diceNameText.text = "Mind Dice";
            //pauseScript.diceNameText.color = mindColor;
            //blue glow
        }

        //check if the level is boss
        if (SceneManager.GetActiveScene().name == "BossPrototype")
        {
            //Color soulColor = new Vector4(127, 255, 161, 255);
            soulDice = true;
            pauseScript.diceNameText.text = "Soul Dice";
            //pauseScript.diceNameText.color = soulColor;
            //green glow
        }

        if (bodyDice && mindDice && soulDice)
        {
            //Color ALLColor = new Vector4(255, 125, 255, 255);
            pauseScript.Victory();
            pauseScript.endText.text = "VICTORY!!";
            pauseScript.diceNameText.text = "ALL Dice";
            //pauseScript.diceNameText.color = ALLColor;
            //diceNameText.color = soulColor;
        }

        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            pauseScript.diceNameText.text = "No Dice";
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
