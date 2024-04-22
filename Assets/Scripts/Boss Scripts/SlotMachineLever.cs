using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineLever : MonoBehaviour
{
    private Animation anim;
	public GameObject coin; //spawn coins
	public Transform dropPoint; //drop point above Stache's head

    private void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Head"))
        {
			InstantiateCoin();
            anim.Play("SlotMachineLeverHit");
            Destroy(this);
        }
    }
	
	void InstantiateCoin()
    {
		GameObject dropper = Instantiate(coin, dropPoint.position, Quaternion.identity);
		Rigidbody rb = dropper.GetComponent<Rigidbody>();
    }
}
