using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : MeleeEnemy,IDamageable {

    public int Health { get; set; }


    //Prendre des dégats
    public void TakeDamage(int damageAmount)
    {
        //Debug.Log("Damage Taken");
        
        Health=Health-damageAmount;
        isHit = true;
        //Debug.Log("is Hit is true now");
        anim.SetTrigger("HURT");
        
        anim.SetBool("Done", false);

        if (Health <= 0)
        {
            anim.SetTrigger("Death");
            FindObjectOfType<AudioManager>().Play("ChomperDeath");
            SpawnGems();
            Destroy(this.gameObject, 1f);

        }
    }
    public override void Movement()
    {
        base.Movement();
    }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Update()
    {
        base.Update();
    }

    
}
