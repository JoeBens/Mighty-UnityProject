using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeEnemy : MonoBehaviour {

    [SerializeField]
    protected int health, coins;
    [SerializeField]
    protected float speed;

    protected Animator anim;
    protected SpriteRenderer enemySR;
    [SerializeField]
    protected bool isFacingRight;


    [SerializeField]
    protected bool isHit = false;

    protected PlayerMovement player;
    protected float distance; //distance entre l'ennemi et le joueur
    private Vector3 smoothVelocity = Vector3.zero;
    private float moveVelocity;
    //public bool moveRight;// will use this variable to tell the enemy that must change its move direction.
    [Range(0.0f, 1.0f)]           // Wall Check radius Slide Bar.
    public float groundCheckRadius = 0.1f;// This determines the space between the enemy Collider and the walls.
    public LayerMask whatIsGround;// We use this layer mask to tell the enemy what is a wall and what is not.
    private bool notAtEdge; // this determines if the enemy has reached an edge.
    public Transform edgeCheck;// This object is placed in front of the enemy and is used to know when its reaching an edge.

    protected Vector3 direction;

    protected bool wereGoingRight;


    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    public virtual void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        //Si l'animation IDLE est en cours, arretez l'ennemi
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("IDLE") && anim.GetBool("InCombat") == false)
        {
            return;
        }
        Movement();
        PlayerClose();
    }

    public virtual void Movement()
    {
        //distance entre le joueur et l'ennemi
        distance = Vector3.Distance(transform.position, player.transform.position);
        
        //si l'ennemi
        if (isHit == false)
        {
            Patrol();
        }
        else if (isHit == true )
        {

            if (distance < 3.0f)
            {
                anim.SetBool("InCombat", true);
                anim.SetBool("Chasing", false);

            }
            else if (distance > 3.0f && distance < 10.0f)
            {
                anim.SetBool("Chasing", true);
                anim.SetBool("InCombat", false);
                Chase();
            }
        }

        //Debug.Log("Distance is = " + distance);
        if (distance > 10.0f)
        {
            isHit = false;
            //Debug.Log("is Hit is False now");
            anim.SetBool("InCombat", false);
            anim.SetBool("Done", true);
            anim.SetBool("Chasing", false);
        }

        direction = player.transform.position - transform.position;
    }
    public virtual void Patrol()
    {
        //Voir si l'ennemi est près d'un bord
        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, groundCheckRadius, whatIsGround);
        //si l'ennemi atteint un bord, il changera sa direction
        if (!notAtEdge)
            isFacingRight = !isFacingRight;

        if (isFacingRight)
        {
            //transform.Rotate(0f, 180f, 0f); 
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            wereGoingRight = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
            wereGoingRight = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);

        }
    }
    public virtual void PlayerClose()
    {
        if (distance < 10.0f)
        {
            isHit = true;
            anim.SetBool("Done", false);
            anim.SetBool("InCombat", true);
            anim.SetTrigger("IDLE");
        }
    }

    public virtual void Chase()
    {
        //Chasser le joueur
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), 2 * speed * Time.deltaTime);
       if (direction.x > 0 && isFacingRight == false)
        {
            isFacingRight = true;
            transform.Rotate(0f, 180f, 0f);
        }
        else if (direction.x < 0 && isFacingRight == true)
        {
            isFacingRight = false;
            transform.Rotate(0f, 180f, 0f);
        }
    }



}
