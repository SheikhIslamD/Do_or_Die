using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceThrow : MonoBehaviour
{
    private PlayerMovement playerController;
    public GameObject dice;
    public float throwForce, upwardForce;
    public float cooldown;
    public bool diceHeld, diceLanded;
    public Camera playerCamera;
    public Transform headPoint, player;
    //for bug fixing?
    public bool allowInvoke = true;
	public bool jumpUpStart = false;
	public bool jumpDownStart = false;
	public bool speedUpStart = false;
	public bool speedDownStart = false;
	public TextMeshProUGUI rollText;
    [SerializeField] private Transform debugTransform;

    public ParticleSystem magicPoofHead;
    public ParticleSystem magicPoofDice;
    
	//adding stuff for recalling
    private Rigidbody rigidb;
    private BoxCollider boxcollider;
    
	//rolling a number
    public Material[] material;
    public int rollNumber;
    Renderer rend;
    
	//solution to raycast hitting player?
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    public Renderer diceRenderer; //the dice gameobject
    public Renderer diceHeadRenderer; //the player model's dice head
    public Renderer hatRenderer; //the player model's top hat
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
                    //THERE'S HELLA DEBUG LOG AND COMMENTS IN THIS FUNCTION, FEEL FREE TO REMOVE THEM
        
        //Referencing player controller script
        GameObject diceHead = GameObject.Find("Dicehead Player");
        // Check if we find Dicehead
        if (diceHead != null)
        {
            Debug.Log("We found Dicehead");
            // Access the player controller script component
            playerController = diceHead.GetComponent<PlayerMovement>();
            Debug.Log("Script accessed");

            // Check if the script component is found
            if (playerController != null)
            {
                Debug.Log("And we found the script!");
            }
        }

        //cleaning up inspector a bit
        rigidb = GetComponent<Rigidbody>();
        boxcollider = GetComponent<BoxCollider>();

        //dice position attached to player
        diceHeld = true;
        rigidb.isKinematic = true;
        boxcollider.isTrigger = true;

        //rolling number material
        rollNumber = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[rollNumber];
    }

    // Update is called once per frame
    void Update()
    {
        //if dice is held, lmb throws it - if not held, lmb retrieves it
        if (diceHeld && Input.GetKeyDown(KeyCode.Mouse0)) Throw();
        if (!diceHeld && Input.GetKeyDown(KeyCode.Mouse0)) Recall();

        //dice rolling stuff
        if (!diceHeld && !diceLanded) diceRoll();

        //for the more advanced dice roll to be added with raycasts and stuff, could isGrounded be useful?

        //raycast and render to check aiming
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
        }

        //makes the hat and dice head appear and reappear when thrown
        if (diceHeld == false)
        {
            diceRenderer.enabled = true;
            diceHeadRenderer.enabled = false;
            hatRenderer.enabled = false;
        }
        else
        {
            diceRenderer.enabled = false;
            diceHeadRenderer.enabled = true;
            hatRenderer.enabled = true;
        }
    }

    public void Throw()
    {
        animator.SetTrigger("throw");
        //dice is no longer on head and is considered thrown, detach from headPoint parent
        diceHeld = false;
        transform.SetParent(null);
        rigidb.isKinematic = false;
        boxcollider.isTrigger = false;

        //hit position using raycast
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //raycast hit check
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        debugTransform.position = targetPoint;

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
        diceInThrow.GetComponent<Rigidbody>().AddForce(playerCamera.transform.up * upwardForce, ForceMode.Impulse);
    }

    public void Recall()
    {
        diceHeld = true;
        diceLanded = false;
        //move dice back to head, play poof
        rigidb.isKinematic = true;
        boxcollider.isTrigger = true;
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
        rollNumber = Random.Range(1, 7);
		rollText.text = "Roll: " + rollNumber;
		
		switch (rollNumber)
		{
			case 1:
				playerController.DamageHealth();
				break;
			case 2:
				if (!jumpDownStart)
				{
					jumpDownStart = true;
					playerController.jump /= 2;
					StartCoroutine("JumpDown");
				}
				break;
			case 3:
				if (!speedDownStart)
				{
					speedDownStart = true;
					playerController.speed /= 2;
					StartCoroutine("SpeedDown");
				}
				break;
			case 4:
				if (!speedUpStart)
				{
					speedUpStart = true;
					playerController.speed *= 2;
					StartCoroutine("SpeedUp");
				}
				break;
			case 5:
				if (!jumpUpStart)
				{
					jumpUpStart = true;
					playerController.jump *= 2;
					StartCoroutine("JumpUp");
				}
				break;
			case 6:
				playerController.IncreaseHealth();
				break;
			default:
				break;
		}
		
        rend.sharedMaterial = material[rollNumber];
        magicPoofDice.Play();
        diceLanded = true;
    }

    public void diceReset()
    {
        rollNumber = 0;
        rend.sharedMaterial = material[rollNumber];
		rollText.text = "Roll: ";
    }

    //use oncollision here to snap the dice to reciever spots?
    private void OnCollisionEnter(Collision other)
    {
        
    }
	
	IEnumerator SpeedUp()
	{
		yield return new WaitForSeconds(10f);
		playerController.speed /= 2;
		speedUpStart = false;
	}
	
	IEnumerator SpeedDown()
	{
		yield return new WaitForSeconds(10f);
		playerController.speed *= 2;
		speedDownStart = false;
	}
	
	IEnumerator JumpUp()
	{
		yield return new WaitForSeconds(10f);
		playerController.jump /= 2;
		jumpUpStart = false;
	}
	
	IEnumerator JumpDown()
	{
		yield return new WaitForSeconds(10f);
		playerController.jump *= 2;
		jumpDownStart = false;
	}
}
