using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineLever : MonoBehaviour
{
    private Animation anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Head"))
        {
            anim.Play("SlotMachineLeverHit");
            Destroy(this);
        }
    }
}
