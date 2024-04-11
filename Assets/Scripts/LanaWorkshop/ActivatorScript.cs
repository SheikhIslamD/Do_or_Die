using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorScript : MonoBehaviour
{
    public GameObject platform;
    public RotateScript scriptB;

    private Vector3 targetRotation = new Vector3(0f, 0f, 90f);

    // Start is called before the first frame update
    void Start()
    {
        scriptB = platform.GetComponent<RotateScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Head"))
        {
            platform.transform.rotation = Quaternion.Euler(0, 0, 90);

            Destroy(gameObject);

        }

    }

}
