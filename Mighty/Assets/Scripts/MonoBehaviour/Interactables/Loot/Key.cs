using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {



    private bool taken = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerStat>() != null && taken == false)
            {
                //FindObjectOfType<AudioManager>().Play("CoinPickUp");
                other.gameObject.GetComponent<PlayerStat>().howManyKeys ++;
                taken = true;
                Destroy(this.gameObject);
            }
        }
    }
}
