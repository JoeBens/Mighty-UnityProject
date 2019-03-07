using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

    [SerializeField]
    private int healthGiven;


    [SerializeField]
    private GameObject heartEffectPrefab, heartEffectPrefabT;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerStat>() != null)
            {
                FindObjectOfType<AudioManager>().Play("HealthPickUp");
                other.gameObject.GetComponent<PlayerStat>().Health += healthGiven;
                GameObject effect = Instantiate(heartEffectPrefab, transform.position, transform.rotation);
                GameObject effectT = Instantiate(heartEffectPrefabT, transform.position, transform.rotation);
                Destroy(effect, 0.5f);
                Destroy(effectT, 0.5f);
                Destroy(this.gameObject);
            }
        }
    }
}
