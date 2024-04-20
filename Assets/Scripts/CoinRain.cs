using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRain : MonoBehaviour
{
    public GameObject coin;
    PlayerMovement playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InstantiateCoin();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.DamageHealth();
        }
    }

    void InstantiateCoin()
    {
        Instantiate(coin);
    }
}
