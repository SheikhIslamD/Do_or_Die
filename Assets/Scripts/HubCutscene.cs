using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubCutscene : MonoBehaviour
{
    public GameObject cutsceneCam;
    ScoreTracker scoreTracker;

    // Start is called before the first frame update
    void Start()
    {
        /*scoreTracker = GetComponent<ScoreTracker>();
        if (scoreTracker.soulDice | scoreTracker.mindDice)
        {
            cutsceneCam.SetActive(false);
        }*/
        cutsceneCam.SetActive(true);
        Destroy(cutsceneCam, 15);
    }

}
