using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnockBackPlayer : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private int damageAmount;

    private bool canKnockBack=true;

    private bool canDamage=true;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit" + collision.name);


        if (collision.gameObject.tag == "Player")
        {
            if (canKnockBack == true)
            {
                Debug.Log("Player Hit");
                Vector3 direction = (transform.position - collision.transform.position).normalized;
                collision.GetComponent<Rigidbody2D>().AddForce(direction * -speed);
                canKnockBack = false;
                collision.GetComponent<Animator>().SetTrigger("Dizzy");
                StartCoroutine(ResetKnockBack());
                FindObjectOfType<AudioManager>().Play("PlayerKnocked");
                
                IDamageable hit = collision.GetComponent<IDamageable>();

                if (hit != null)
                {
                    if (canDamage == true)
                    {
                        hit.TakeDamage(damageAmount);
                        canDamage = false;
                        StartCoroutine(ResetCanDamage());
                    }

                }

            }

        }
    }
    IEnumerator ResetKnockBack()
    {
        yield return new WaitForSeconds(1.0f);
        canKnockBack = true;
    }
    IEnumerator ResetCanDamage()
    {
        yield return new WaitForSeconds(0.5f);
        canDamage = true;
    }


}
