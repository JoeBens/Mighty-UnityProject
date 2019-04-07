using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

    [SerializeField]
    private int value;
    private bool taken = false;
    [SerializeField]
    private GameObject gemEffectPrefab, gemEffectPrefabT;

    private AudioSource aS;
    private Collider2D _collider;
    private SpriteRenderer sp;


    private void Start()
    {
        aS = this.GetComponent<AudioSource>();
        _collider = this.GetComponent<Collider2D>();
        sp = this.GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject effect = Instantiate(gemEffectPrefab, transform.position, transform.rotation);
            GameObject effectT = Instantiate(gemEffectPrefabT, transform.position, transform.rotation);
            Destroy(effect, 0.5f);
            Destroy(effectT, 0.5f);
            if (other.gameObject.GetComponent<PlayerStat>() != null && taken == false)
            {
                //FindObjectOfType<AudioManager>().Play("CoinPickUp");
                aS.Play();
                other.gameObject.GetComponent<PlayerStat>().howManyGems += this.value;
                _collider.enabled = false;
                sp.enabled = false;
                taken = true;
                Destroy(this.gameObject,1f);
            }
            
        }
        if (other.gameObject.tag == "Danger")
        {
           
            Destroy(this.gameObject);

        }
    }
}

