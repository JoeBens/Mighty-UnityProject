using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//ce script est reponsable des attaques du joueur

public class PlayerAttack : MonoBehaviour {



    // pour que le joueur ne pourra attaquer indéfiniment, les variables Timer et  Cd controleront les attaques du joueur, par exemple le joueur peut faire Attack 01 chaque 0.3s

    //les variables de Attack 01 
    private bool attacking = false;
    private float attackTimer = 0f;
    [SerializeField]
    private float attackCd = 0.3f;

    //les variables de Attack 02
    private bool striking = false;
    private float strikeTimer = 0f;
    [SerializeField]                                    
    private float strikeCd = 0.6f;

    [SerializeField]
    private GameObject attackEffectPrefab;
    [SerializeField]
    private Transform attackEffectPos;

    private Animator anim;

    [SerializeField]
    private CharacterController2D characterController;

  /*  public Transform attackPos;
    public LayerMask whatIsEnemies; // Un masque déterminant les ennemis
    public float attackRange;  // la portée des attaques du personnage */

    public float simpleAttackDamage; // dégats de Attack 01
    public float strikeDamage; // dégats de Attack 02

    private PlayerAnimator playerAnim;

    // Use this for initialization
    void Awake () {
        playerAnim = GetComponent<PlayerAnimator>();
    }
	
	// Update is called once per frame
	void Update () {


        //le joueur peut attaquer seulement s'il est au sol
        
            //attack
            if (Input.GetMouseButtonDown(0) && !attacking)
            {
                attacking = true;
                playerAnim.SimpleAttack();
                FindObjectOfType<AudioManager>().Play("PlayerAttackOne");



            attackTimer = attackCd;
            }
            //pour s'assurer que le joueur ne spamme pas l'attaque
            if (attacking)
            {
                if(attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    attacking = false;
                }
            }
        if (characterController.IsGrounded())
        {
            //strike
            if (Input.GetMouseButtonDown(1) && !striking)
            {
                striking = true;

                playerAnim.Strike();
                FindObjectOfType<AudioManager>().Play("PlayerAttackTwo");
               

                strikeTimer = strikeCd;
            }

            if (striking)
            {
                if (strikeTimer > 0)
                {
                    strikeTimer -= Time.deltaTime;
                }
                else
                {
                    striking = false;
                }
            }
        }
        

    }

}
