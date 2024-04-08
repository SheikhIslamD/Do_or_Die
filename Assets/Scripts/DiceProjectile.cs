using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceProjectile : MonoBehaviour
{
    [Header("Necessary components")]
    private PlayerMovement playerController;
    private Rigidbody rigidb;
    private BoxCollider boxcollider;
    public GameObject dice;
    public float throwForce;
    public bool diceHeld;
    public Transform headPoint, playerDiceyboye;
    public ParticleSystem magicPoofHead;

    [Header("Dice buffs/debuffs")]
    public bool jumpUpStart = false;
    public bool jumpDownStart = false;
    public bool speedUpStart = false;
    public bool speedDownStart = false;

    [Header("Roll #s and materials")]
    public Material[] material;
    public int rollNumber;
    public TextMeshProUGUI rollText;
    Renderer rend;

    [Header("Renders for dice on/off head")]
    public Renderer diceRenderer; //the dice gameobject
    public Renderer diceHeadRenderer; //the player model's dice head
    public Renderer hatRenderer; //the player model's top hat
    public Animator animator;

    [Header("Aim location")] //(Mask: Default, Ground, Walls, Objects, Target)
    [SerializeField] private Transform aimLocator;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    private Vector3 targetPoint;

    AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        //find dicehead and get playerController
        GameObject diceHead = GameObject.Find("Dicehead Player");
        playerController = diceHead.GetComponent<PlayerMovement>();

        //cleaning up inspector a bit
        rigidb = GetComponent<Rigidbody>();
        boxcollider = GetComponent<BoxCollider>();

        //dice position attached to player
        diceHeld = true;
        rigidb.isKinematic = true;
        boxcollider.isTrigger = true;

        //rolling number material default assignments
        rollNumber = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[rollNumber];

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if dice is held, lmb throws it - if not held, lmb retrieves it
        if (diceHeld && Input.GetKeyDown(KeyCode.Mouse0)) Throw();
        if (!diceHeld && Input.GetKeyDown(KeyCode.Mouse1)) Recall();
        
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

        //raycast and render to hit/show target respectively
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            targetPoint = raycastHit.point;
            aimLocator.position = targetPoint;
            
        }
        else
        {
            targetPoint = ray.GetPoint(100);
            aimLocator.position = targetPoint;
        }
    }

    public void Throw()
    {
        
        animator.SetTrigger("throw");
        //dice is no longer on head and is considered thrown, detach from headPoint parent and play poof
        diceHeld = false;
        transform.SetParent(null);
        rigidb.isKinematic = false;
        boxcollider.isTrigger = false;
        magicPoofHead.Play();
        
        //headpoint to target point direction calculation
        Vector3 direction = targetPoint - headPoint.position;
        
        //use player movement + add rotation and throwing force
        float random = Random.Range(-1f, 1f);
        rigidb.AddTorque(new Vector3(random, random, random) * 100);
        dice.GetComponent<Rigidbody>().AddForce(direction.normalized * throwForce, ForceMode.Impulse);
        
        diceRoll();

        audioManager.playSFX(audioManager.dicethrow);
        audioManager.playSFX(audioManager.poof);
    }

    public void Recall()
    {
        diceHeld = true;
        //move dice back to head, play poof
        rigidb.isKinematic = true;
        boxcollider.isTrigger = true;
        transform.SetParent(headPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
        magicPoofHead.Play();
        diceReset();

        audioManager.playSFX(audioManager.poof);
    }

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
    }

    public void diceReset()
    {
        rollNumber = 0;
        rend.sharedMaterial = material[rollNumber];
        rollText.text = "Roll: ";
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
