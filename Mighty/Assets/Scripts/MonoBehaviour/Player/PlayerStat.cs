using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStat : MonoBehaviour, IDamageable {



    [SerializeField]
    private GameObject bloodEffectPrefab;


    [SerializeField]
    private GameObject deathEffectPrefab;

    public int health;

    private Animator anim;

    public int howManyGems;

    public int Health{ get; set; }
    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animator>();
        Health = health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OutOfScreen"))
        {
            Health = -1;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Player Damaged");
        Health -= damageAmount;
        anim.SetTrigger("Hurt");
        FindObjectOfType<AudioManager>().Play("PlayerHurt");


        GameObject effect = Instantiate(bloodEffectPrefab, transform.position, transform.rotation);
        Destroy(effect, 0.5f);



        if (Health <= 0)
        {
            anim.SetTrigger("Death");
            
            StartCoroutine(WaitBeforePlayerRespawn());
            

        }

    }


	// Update is called once per frame
	void Update () {
        //Debug.Log("Gems: " + this.howManyGems);
        //Debug.Log("Health: " + this.Health);

        if (Health > health)
            Health = health;
        if (Health <= 0)
        {
            Health = 0;
        }
            
    }


    IEnumerator WaitBeforePlayerRespawn()
    {
        Debug.Log("I'm here");
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        GameObject effect = Instantiate(deathEffectPrefab, transform.position, transform.rotation);
        Destroy(effect, 0.5f);
        yield return new WaitForSeconds(1.0f);
        FindObjectOfType<GameManager>().PlayerIsDead();
        Destroy(this.gameObject, 1f);
        
    }
}
