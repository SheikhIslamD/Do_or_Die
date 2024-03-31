using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiceThrow : MonoBehaviour
{
    public GameObject dice;
    public float throwForce, upwardForce;
    public float cooldown;
    public bool diceHeld, diceLanded;
    public Camera camera;
    public Transform headPoint, player;
    //for bug fixing?
    public bool allowInvoke = true;

    public ParticleSystem magicPoofHead;
    public ParticleSystem magicPoofDice;
    //adding stuff for recalling
    public Rigidbody rigidb;
    public BoxCollider collider;
    //rolling a number
    public Material[] material;
    public int rollNumber;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        //dice position attached to player
        diceHeld = true;
        rigidb.isKinematic = true;
        collider.isTrigger = true;

        //rolling number material
        rollNumber = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[rollNumber];
    }

    // Update is called once per frame
    void Update()
    {
        //if dice is held, lmb throws it
        if (diceHeld && Input.GetKeyDown(KeyCode.Mouse0)) Throw();
        if (!diceHeld && Input.GetKeyDown(KeyCode.Mouse1)) Recall();

        //dice rolling stuff
        if (!diceHeld && !diceLanded) diceRoll();

        //for the more advanced dice roll to be added with raycasts and stuff, could isGrounded be useful?
    }

    public void Throw()
    {
        //dice is no longer on head and is considered thrown, detach from headPoint parent
        diceHeld = false;
        transform.SetParent(null);
        rigidb.isKinematic = false;
        collider.isTrigger = false;

        //hit position using raycast
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //raycast hit check
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        //headpoint to target point direction calculation
        Vector3 direction = targetPoint - headPoint.position;

        //spawn dice off of head
        //GameObject diceInThrow = Instantiate(dice,headPoint.position, Quaternion.identity);
        //assign dice to be thrown and play poof
        GameObject diceInThrow = dice;
        magicPoofHead.Play();

        //use player movement + add rotation(not working?) + add forces to the thrown dice to appear as rolling (including upward force if needed)
        rigidb.velocity = player.GetComponent<Rigidbody>().velocity;
        float random = Random.Range(-1000f, 1000f);
        rigidb.AddTorque(new Vector3(random, random, random));
        diceInThrow.GetComponent<Rigidbody>().AddForce(direction.normalized * throwForce, ForceMode.Impulse);
        diceInThrow.GetComponent<Rigidbody>().AddForce(camera.transform.up * upwardForce, ForceMode.Impulse);


        /*        //start cooldown (not needed)
                if (allowInvoke)
                {
                    Invoke("Cooldown", cooldown);
                    allowInvoke = false;
                }*/
    }

    /*    private void Cooldown()
        {
            diceHeld = true;
            allowInvoke = true;
        }*/

    public void Recall()
    {
        diceHeld = true;
        diceLanded = false;
        //move dice back to head, play poof
        rigidb.isKinematic = true;
        collider.isTrigger = true;
        transform.SetParent(headPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
        magicPoofHead.Play();
        magicPoofDice.Play();
        diceReset();
    }

    //dice rolling stuff
    public void diceRoll()
    {
        rollNumber = Random.Range(1, 6);
        rend.sharedMaterial = material[rollNumber];
        magicPoofDice.Play();
        diceLanded = true;
    }

    public void diceReset()
    {
        rollNumber = 0;
        rend.sharedMaterial = material[rollNumber];
    }
}
