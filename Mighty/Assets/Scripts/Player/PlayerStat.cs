using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour, IDamageable {

    [SerializeField]
    private int health;

    private Animator anim;

    public int Health{ get; set; }
    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animator>();
        Health = health;
    }


    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Player Damaged");
        Health -= damageAmount;
        anim.SetTrigger("Hurt");

        if (Health <= 0)
        {
            anim.SetTrigger("Death");
            Destroy(this.gameObject, 0.5f);

        }

    }


	// Update is called once per frame
	void Update () {
		
	}
}
