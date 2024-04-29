using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubCutscene : MonoBehaviour
{
    public GameObject cutsceneCam;
    [SerializeField] ScoreTracker scoreTracker;
    [SerializeField] GameObject timeLine;

    // Start is called before the first frame update
    void Start()
    {
        scoreTracker = GameObject.Find("ScoreTracker").GetComponent<ScoreTracker>();
        /*scoreTracker = GetComponent<ScoreTracker>();
        if (scoreTracker.soulDice | scoreTracker.mindDice)
        {
            cutsceneCam.SetActive(false);
        }*/
        if (!scoreTracker.cutScenePlayed)
        {
            cutsceneCam.SetActive(true);
            Destroy(cutsceneCam, 15);
        }
        else
        {
            Destroy(timeLine);
            Destroy(this.gameObject);
        }

    }

}
