using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ce script est attaché à la boule de feu

public class FireBallEffect : MonoBehaviour {

    public float fireBallSpeed = 20f; //la vitesse de la boule de feu

    public int bulletDamage = 30; //le dégat que peut faire la boule de feu

    public Rigidbody2D rb; // le corps de la boule de feu

    private bool canDamage = true; 

    public GameObject impactExplosion; // l'explosion

    
    // Use this for initialization
	void Start () {
        rb.velocity = transform.right * fireBallSpeed;
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit" + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (canDamage == true)
            {
                hit.TakeDamage(bulletDamage);
                canDamage = false;
                StartCoroutine(ResetCanDamage());
            }

        }
        // si une collision occure, on instancie une explosion 
        GameObject explosion = Instantiate(impactExplosion, transform.position, transform.rotation);
        // après 0.5s on détruit l'explosion pour que ça reste pas et prend un peu de la mémoire
        Destroy(explosion, 0.5f);
        Destroy(gameObject);
    }
    IEnumerator ResetCanDamage()
    {
        yield return new WaitForSeconds(0.5f);
        canDamage = true;
    }


}
