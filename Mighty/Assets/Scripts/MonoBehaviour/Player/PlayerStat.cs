using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStat : MonoBehaviour, IDamageable {

    
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


    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Player Damaged");
        Health -= damageAmount;
        anim.SetTrigger("Hurt");
        FindObjectOfType<AudioManager>().Play("PlayerHurt");

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
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<GameManager>().PlayerIsDead();
        Destroy(this.gameObject, 1f);
        
    }
}
