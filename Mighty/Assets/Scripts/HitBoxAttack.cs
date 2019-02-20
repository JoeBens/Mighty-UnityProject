using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxAttack : MonoBehaviour {

    private bool canDamage = true;
    [SerializeField]
    private int damageAmount;
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit" + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if(canDamage == true)
            {
                hit.TakeDamage(damageAmount);
                canDamage = false;
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
