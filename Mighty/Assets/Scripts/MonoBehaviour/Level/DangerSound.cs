using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerSound : MonoBehaviour {


    private bool playerHit = false;
    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && playerHit == false)
        {
            FindObjectOfType<AudioManager>().Play("Danger");
            playerHit = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHit = false;
        }
    }
}
