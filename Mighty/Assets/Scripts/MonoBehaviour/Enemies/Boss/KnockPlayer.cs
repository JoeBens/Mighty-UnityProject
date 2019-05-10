using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class KnockPlayer : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private int damageAmount;

    private bool canKnockBack = true;

    private bool canDamage = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        

        if (collision.gameObject.tag == "Player")
        {
            if (canKnockBack == true)
            {
                Debug.Log("Player Hit");
                Vector3 direction = (transform.position - collision.transform.position).normalized;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * -speed);
                canKnockBack = false;
                collision.gameObject.GetComponent<Animator>().SetTrigger("Dizzy");
                StartCoroutine(ResetKnockBack());
                FindObjectOfType<AudioManager>().Play("PlayerKnocked");
                
                IDamageable hit = collision.gameObject.GetComponent<IDamageable>();

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
