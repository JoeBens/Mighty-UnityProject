using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

    [SerializeField]
    private int value;

    [SerializeField]
    private GameObject gemEffectPrefab, gemEffectPrefabT;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject effect = Instantiate(gemEffectPrefab, transform.position, transform.rotation);
            GameObject effectT = Instantiate(gemEffectPrefabT, transform.position, transform.rotation);
            Destroy(effect, 0.5f);
            Destroy(effectT, 0.5f);
            if (other.gameObject.GetComponent<PlayerStat>() != null)
            {
                FindObjectOfType<AudioManager>().Play("CoinPickUp");
                other.gameObject.GetComponent<PlayerStat>().howManyGems += this.value;
                Destroy(this.gameObject);
            }
            
        }
        if (other.gameObject.tag == "Danger")
        {
           
            Destroy(this.gameObject);

        }
    }
}

