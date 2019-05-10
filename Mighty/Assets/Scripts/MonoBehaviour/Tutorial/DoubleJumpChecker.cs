using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpChecker : MonoBehaviour {

    public bool playerHit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHit = true;
        }
    }
}
