using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoEnemy : MeleeEnemy, IDamageable
{
    public int Health { get; set; }

    // Use this for initialization
    bool notAtEdge;

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    // Update is called once per frame
    public override void Update () {
        Patrol();
	}
    public override void Patrol()
    {
        //Voir si l'ennemi est près d'un bord
        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, groundCheckRadius, whatIsGround);
        //si l'ennemi atteint un bord, il changera sa direction
        if (!notAtEdge)
            isFacingRight = !isFacingRight;

        if (isFacingRight)
        {
            //transform.Rotate(0f, 180f, 0f); // when the enemy  reaches an edge we change its move direction.
            transform.localScale = new Vector3(1f, 1f, 1f);

            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);

        }
    }

    public void TakeDamage(int damageAmount)
    {
        //Debug.Log("Damage Taken");

        Health = Health - damageAmount;
        isHit = true;
        //Debug.Log("is Hit is true now");

        if (Health <= 0)
        {
            Destroy(this.gameObject);

        }
    }

}
