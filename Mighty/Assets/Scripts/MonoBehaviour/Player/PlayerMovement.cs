using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ce script est responsable de l'input du joueur

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private CharacterController2D characterController;

    [SerializeField]
    private Animator anim;

    public float playerSpeed = 40f; // la vitesse du joueur

    private float moveInput = 0f; // l'input du joueur

    bool canJump = false; // la variable responsable du saut du joueur
    


    private PlayerAnimator playerAnim;




    // Use this for initialization
    void Start () {
        playerAnim = GetComponent<PlayerAnimator>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dizzy"))
        {
            return;
        }
           

        // MoveIput = 1 si l'input est la flèche droite, -1 si l'input est la flèche gauche
        moveInput = Input.GetAxisRaw("Horizontal") * playerSpeed;


      

        //Run animation
        playerAnim.Move(moveInput);

        //si "espace" est appuyé alors le joueur saute
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
            //l'animation "jump"
            playerAnim.Jump(canJump);
            FindObjectOfType<AudioManager>().Play("PlayerJump");
        }

    }

    public void OnLanding()
    {
        //Cet evenement va arréter l'animation "Jump"
        playerAnim.Jump(false);
        
    }



    private void FixedUpdate() // on déplace le personnage sur FixedUpdate au lieu de Update parce que FixedUpdate va s'executer dans chaque frame fixe, càd elle est meilleure pour controler les RigidBody
    {
        // Déplacer le personnage
        characterController.Move(moveInput * Time.fixedDeltaTime, canJump);
        canJump = false;

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Moving_Platform")
            this.transform.parent = col.transform;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Moving_Platform")
            this.transform.parent = null;
    }

    

}
