using UnityEngine;
using UnityEngine.Events;

// ce script est responsable du mouvement du joueur

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float jumpForce = 400f;                            // la force ajoutée lorsque le joueur saute.
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;	// Un variable allant de 0 à 0.3 qui est responsable de la fluidité du mouvement
	[SerializeField] private LayerMask ground;                                  // Un masque déterminant le sol
    [SerializeField] private Transform groundCheck;                             // Un repère positionné aux pieds du personnage que l'on utilise pour vérifier si le joueur est en collision avec le sol.

    const float groundRadius = .2f;     // Rayon du cercle ( le repère ) pour déterminer si le joueur est en collision avec le sol
    private bool isGrounded;            // Si le joueur est en collision avec le sol  isGrounded = true, false sinon.
    [SerializeField] private bool airControl = false;
    private Rigidbody2D rb;  // le corps du personnage
	private bool isFacingRight = true;  // Pour déterminer la direction du joueur


    private Vector3 m_Velocity = Vector3.zero; // une velocité de (0,0,0)
    public bool canDoubleJump; // si le jouer peut sauter deux fois ou non




    [Header("Events")]
	[Space]

	public UnityEvent OnLandEvent; // un événement qui se passe lorsque le joueur finit son saut


    [System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }



	private void Awake() // une fonction prédéfinie qui est appelée immédiatement quand le joueur lance le jeu
	{
		rb = GetComponent<Rigidbody2D>(); // rb va recevoir le rigidbody du gameobject qui est lié à ce script ( dans ce cas c'est le joueur )


        if (OnLandEvent == null)
			OnLandEvent = new UnityEvent(); // initialisation de l'event



    }

    private void FixedUpdate() // une fonction prédéfinie qui est appelée dans chaque frame 
	{
		bool wasGrounded = isGrounded;
		isGrounded = false;

        // Le joueur est au sol s'il y a une collision avec tout ce qui désigné "Ground"

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, ground);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				isGrounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


    public void Move(float move, bool jump) // la fonction responable du mouvement, float move c'est l'input du joueur, -1 veut dire qu'il a appuyé sur la fleche gauche, 1 s'il a appuyé sur la flèche a droite, 0 s'il est pas entrain de se déplacer
       
    {
        //Seulement controler le personnage s'il est au sol ( isGrounded = true )
        if (isGrounded || airControl )
        {

            // Déplacer le personnage en trouvant la vélocité cible
            Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
            
            // et après le déplacement, SmoothDamp va essayer de rendre la vélocité plus fluide
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, movementSmoothing);


            // Si l'input est la flèche droite ou "Q" et si le joueur est tourné vers la gauche...
            if (move > 0 && !isFacingRight)
            {
               //On inverse le joueur
                Flip();
            }
            // Sinon, si l'input est la flèche gauche ou "D" et si le joueur est tourné vers la droite...
            else if (move < 0 && isFacingRight)
            {
                //On inverse le joueur
                Flip();
            }
        }


        // si l'input est "Space" jump = true
        if (jump)
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, jumpForce));
                
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump) // si canDoubleJump = true, le joueur peut sauter encore une fois
                {
                    canDoubleJump = false;
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(new Vector2(0, jumpForce));
                    
                }
            }
        }

       
    }
    // une fonction responsable de l'inversement du joueur
    private void Flip()
	{
		isFacingRight = !isFacingRight;

        // Inverser le joueur
        transform.Rotate(0f, 180f, 0f);
	}


    //un getter de la variable isGrounded
    public bool IsGrounded()
    {
        return isGrounded;
    }
}
