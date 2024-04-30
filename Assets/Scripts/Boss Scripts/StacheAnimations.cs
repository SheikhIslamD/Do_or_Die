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
    
    public GameObject soulDice;
    public ParticleSystem soulDicePoof;

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
        yield return new WaitForSeconds(4);
        soulDicePoof.Play();
        soulDice.SetActive(true);
        Instantiate(soulDicePoof, new Vector3(0, 35, -8), Quaternion.identity);
        yield return new WaitForSeconds(2);
        player.SetActive(true);
        cutsceneCam.SetActive(false);
        Destroy(this);

        Debug.Log("Couroutine ran");
        Debug.Log("cutsceneCam active: " + cutsceneCam.activeSelf);
    }
}
