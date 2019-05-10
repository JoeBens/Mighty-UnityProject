using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ce script est attaché à la boule de feu

public class BossKiller : MonoBehaviour
{

    public float fireBallSpeed = 25f; //la vitesse de la boule de feu

    

    public Rigidbody2D rb; // le corps de la boule de feu

    

    public GameObject impactExplosion;

    public int fireballType;
    


    // Use this for initialization
    void Start()
    {
        if(fireballType == 0)
            rb.velocity = transform.right * fireBallSpeed;
        if(fireballType == 1)
            rb.velocity = transform.right * -fireBallSpeed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "Boss")
        {
            // si une collision occure, on instancie une explosion 
            GameObject explosion = Instantiate(impactExplosion, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("FireBallImpact");
            Destroy(explosion, 0.5f);
            Destroy(this.gameObject);
        }

        
    }

}
