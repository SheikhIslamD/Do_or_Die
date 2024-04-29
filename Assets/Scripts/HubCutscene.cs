using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubCutscene : MonoBehaviour
{
    public GameObject cutsceneCam;
    [SerializeField] ScoreTracker scoreTracker;
    [SerializeField] GameObject timeLine;

    public bool cutScenePlayed;

    // Start is called before the first frame update
    void Start()
    {
        /*if (scoreTracker.soulDice | scoreTracker.mindDice)
        {
            cutsceneCam.SetActive(false);
        }*/
        if (!cutScenePlayed)
        {
            cutsceneCam.SetActive(true);
            Destroy(cutsceneCam, 15);
            cutScenePlayed = true;           
        }
        else
        {
            selfDestruct();
        }
    }


    public void selfDestruct()
    {
        Destroy(cutsceneCam);
        Destroy(timeLine);
        Destroy(this.gameObject);
        Debug.Log("Self destruct");

    }
}
