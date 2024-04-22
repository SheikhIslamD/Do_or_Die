using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    public int scoreCount;
    PauseScript pauseScript;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        pauseScript = GameObject.Find("UICanvas (working)").GetComponent<PauseScript>();
        scoreCount = 0;
    }

    public void scoreUp()
    {
        scoreCount++;
        if (scoreCount == 3)
        {
            pauseScript = GameObject.Find("UICanvas (working)").GetComponent<PauseScript>();
            pauseScript.Victory();
        }
    }
}
