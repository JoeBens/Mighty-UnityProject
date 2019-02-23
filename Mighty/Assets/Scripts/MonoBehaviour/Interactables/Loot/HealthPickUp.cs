using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

    [SerializeField]
    private int healthGiven;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerStat>() != null)
            {
                other.gameObject.GetComponent<PlayerStat>().Health += healthGiven;
                Destroy(this.gameObject);
            }
        }
    }
}
