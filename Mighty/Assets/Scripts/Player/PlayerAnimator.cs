using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    private Animator anim;
    
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
    public void Move( float moveInput)
    {
        //Run animation
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
    }
    public void Dizzy()
    {
        anim.SetTrigger("Dizzy");
    }

    public void Jump(bool jump)
    {
        //Jump Animation
        anim.SetBool("isJumping", jump);
    }

    public void SimpleAttack()
    {
        //Simple Attack Animation
        anim.SetTrigger("isAttacking");
    }

    public void Strike ()
    {
        //Strike Animation
        anim.SetTrigger("isStriking");
    }

    public void Cast()
    {
        //Cast Animation
        anim.SetTrigger("isCasting");
    }

}
