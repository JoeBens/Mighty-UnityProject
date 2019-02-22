using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (Health <= 0)
        {
            anim.SetTrigger("Death");
            Destroy(this.gameObject, 0.5f);

        }

    }


	// Update is called once per frame
	void Update () {
        Debug.Log("Gems: " + this.howManyGems);
        Debug.Log("Health: " + this.Health);

        if (Health > health)
            Health = health;
        if (Health <= 0)
            Health = 0;
    }
}
