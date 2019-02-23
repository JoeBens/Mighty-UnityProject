using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spitter : MeleeEnemy, IDamageable
{
    public int Health { get; set; }

    private float maxDistance = 15f;


    public void TakeDamage(int damageAmount)
    {
        Health = Health - damageAmount;

        if (Health <= 0)
        {
            anim.SetTrigger("Death");
            SpawnGems();
            Destroy(this.gameObject, 0.5f);

        }

    }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Update()
    {
        PlayerFar();
        PlayerClose();
        CalculateDistance();
        //Debug.Log(distance);
        if (isHit == true)
        {
            checkDirection();
        }
    }

    private void checkDirection()
    {
        direction = player.transform.position - transform.position;
        if (direction.x > 0 && isFacingRight == false)
        {
            isFacingRight = true;
            transform.Rotate(0f, 180f, 0f);
        }
        else if (direction.x < 0 && isFacingRight == true)
        {
            isFacingRight = false;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public override void PlayerClose()
    {
        if (distance < maxDistance)
        {
            isHit = true;
            anim.SetBool("Done", false);
            anim.SetTrigger("IDLE");
        }
    }
    public void PlayerFar()
    {
        if (distance > maxDistance)
        {
            isHit = false;
            anim.SetBool("Done", true);
            
        }
    }
    public void CalculateDistance()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
    }
}

