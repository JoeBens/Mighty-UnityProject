using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

    [SerializeField]
    private int value;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            if (other.gameObject.GetComponent<PlayerStat>() != null)
            {
                other.gameObject.GetComponent<PlayerStat>().howManyGems += this.value;
                Destroy(this.gameObject);
            }
            
        }
    }
}
