using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StacheAnimations : MonoBehaviour
{
    Animator animator;
    StacheAttacks stacheAttacks;
    StacheHealth stacheHealth;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        stacheAttacks = GetComponent<StacheAttacks>();
        stacheHealth = GetComponent<StacheHealth>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (stacheAttacks.isCoinShooting == true)
        {
            Debug.Log("Stache is animating");
            animator.SetBool("coinShot", true);
        }
        else
        {
            animator.SetBool("coinShot", false);
        }

        if (stacheAttacks.isCardShooting == true)
        {
            Debug.Log("Stache is animating");
            animator.SetBool("cardShot", true);
        }
        else
        {
            animator.SetBool("cardShot", false);
        }
    }
}
