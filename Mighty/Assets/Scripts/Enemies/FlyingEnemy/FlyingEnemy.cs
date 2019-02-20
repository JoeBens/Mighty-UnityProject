using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MeleeEnemy,IDamageable{


    public int Health { get; set; }

    public Transform[] waypoints;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;

    [SerializeField]
    private float maxDistance;

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Start()
    {
        base.Start();
        randomSpot = Random.Range(0, waypoints.Length);
        waitTime = startWaitTime;
    }
    //Prendre des dégats
    public void TakeDamage(int damageAmount)
    {
        //Debug.Log("Damage Taken");
         Health = Health - damageAmount;
    
         //Debug.Log("is Hit is true now");
         anim.SetTrigger("HURT");

        if (Health <= 0)
        {
            Destroy(this.gameObject);

        }
    }

    public override void Update()
    {
      distance = Vector3.Distance(transform.position, player.transform.position);
      if(distance > maxDistance)
      {
            Movement();
      }
      else{
            Chase();
      }
    }
    public override void Movement()
    {
        anim.SetBool("Done", true);
        transform.position = Vector2.MoveTowards(transform.position, waypoints[randomSpot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoints[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, waypoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    public override void Chase()
    {
        anim.SetBool("Done", false);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}