using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StacheAnimations : MonoBehaviour
{   
    Animator animator;
    public StacheAttacks stacheAttacks;
    public StacheHealth stacheHealth;
    public GameObject attacks;
    public GameObject timeline;

    public GameObject player;
    public GameObject cutsceneCam;


    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stacheHealth.health == 0)
        {
            animator.SetInteger("health", 0);
            Destroy(attacks);
            cutsceneCam.SetActive(true);
            player.SetActive(false);
            StartCoroutine(FinishCut());
        }
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(3);
        player.SetActive(true);
        cutsceneCam.SetActive(false);
        Destroy(this);
        Debug.Log("Couroutine ran");
        Debug.Log("cutsceneCam active: " + cutsceneCam.activeSelf);
    }
}
