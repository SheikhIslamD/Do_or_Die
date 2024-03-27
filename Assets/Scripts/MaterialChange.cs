using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public Material[] material;
    public int rollNumber;
    Renderer rend;

    [SerializeField] ParticleSystem magicPoof;
    //SAO death effect just for testing lol
    [SerializeField] ParticleSystem deathEffect;


    // Start is called before the first frame update
    void Start()
    {
        rollNumber=0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[rollNumber];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void diceRoll()
    {
        rollNumber = Random.Range(1, 6);
        rend.sharedMaterial = material[rollNumber];
        magicPoof.Play();
    }

    public void diceReset()
    {
        rollNumber = 0;
        rend.sharedMaterial = material[rollNumber];
        deathEffect.Play();
    }

}
