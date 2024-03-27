using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockLevel : MonoBehaviour
{
    //Attach this script to whatever object brings you to the next level, it will bring you to the next level and unlock it in the level select screen

    public int nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        //When called in SceneManager.LoadScene(), goes to next level
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter(Collider other)
    {
        //Moves to the level after the one you are currently in in build settings
        SceneManager.LoadScene(nextLevel);

        //Sets int for index
        if(nextLevel > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
