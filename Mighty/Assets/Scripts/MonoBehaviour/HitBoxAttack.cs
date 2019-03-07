using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxAttack : MonoBehaviour {



    [SerializeField]
    private GameObject attackEffectPrefab;
    [SerializeField]
    private Transform attackEffectPos;

    private bool canDamage = true;
    [SerializeField]
    private int damageAmount;
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hit" + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if(canDamage == true)
            {
                hit.TakeDamage(damageAmount);
                canDamage = false;
                if(this.gameObject.name== "SimpleAttackHitBox" || this.gameObject.name == "StrikeAttackHitBox")
                {
                    GameObject effect = Instantiate(attackEffectPrefab, attackEffectPos.position, transform.rotation);
                    Destroy(attackEffectPrefab, 0.5f);
                }
                
                
                StartCoroutine(ResetCanDamage());
                
            }

        }

    }
    IEnumerator ResetCanDamage()
    {
        yield return new WaitForSeconds(0.5f);
        canDamage = true;
    }

}
