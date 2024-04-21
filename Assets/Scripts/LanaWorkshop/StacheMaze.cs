using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StacheMaze : MonoBehaviour
{
    public GameObject Talk;
    public GameObject IntroToMaze;
    public GameObject Commit;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //Make sure the player can't launch the dice to activate the other yap sessions
        if (!other.CompareTag("Head"))
        {
            // Check which yap session was triggered, so we can reuse this script
            if (gameObject.CompareTag("EndTutorialText"))   //keep this first, it is used most often (optimization)
            {
                Talk.SetActive(false);
                IntroToMaze.SetActive(false);
                Commit.SetActive(false);
            }
            else if (gameObject.CompareTag("MazeIntro"))
            {
                Commit.SetActive(false);
                Talk.SetActive(true);
                IntroToMaze.SetActive(true);
            }
            else if (gameObject.CompareTag("Commit"))
            {
                Commit.SetActive(true);
                IntroToMaze.SetActive(false);
                Talk.SetActive(true);

            }
        }
    }
}
