using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWarrior : Enemy, IDamageable
{
    public int Health { get; set; }
    [SerializeField]
    private GameObject bloodEffectPrefab;


    [SerializeField]
    private GameObject deathEffectPrefab;


    //Prendre des dégats
    public void TakeDamage(int damageAmount)
    {
        //Debug.Log("Damage Taken");
        GameObject effect = Instantiate(bloodEffectPrefab, transform.position, transform.rotation);
        Destroy(effect, 0.5f);
        Health = Health - damageAmount;
        isHit = true;
        //Debug.Log("is Hit is true now");
        anim.SetTrigger("HURT");
        anim.SetBool("Done", false);
        

        if (Health <= 0)
        {
            camRipple.RippleEffect();
            anim.SetTrigger("Death");
            GameObject effectD = Instantiate(deathEffectPrefab, transform.position, transform.rotation);
            Destroy(effectD, 2.5f);
            
            SpawnGems();
            Destroy(this.gameObject, 0.5f);

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
