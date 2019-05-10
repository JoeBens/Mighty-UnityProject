using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//ce script est responsable de l'attaque 03 ( boule de feu )

public class PlayerCast : MonoBehaviour {


    private bool canShoot = false; // si le joueur peut lancer une boule de feu ou pas

    private float shootTimer = 0f;
    [SerializeField]
    private float shootCd = 1f;


    public Transform firePoint;


    public GameObject fireBallPrefab;


    private PlayerAnimator playerAnim;

    private void Awake()
    {
        playerAnim = GetComponent<PlayerAnimator>();
    }

	
	// Update is called once per frame
	void Update () {

        //si le joueur appuie sur la molette et canShoot == false alors il lance une boule de feu
        if (Input.GetMouseButtonDown(2) && !canShoot)
        {
            canShoot = true;

            //là on dit à l'animateur de lancer l'animation "Cast"
            playerAnim.Cast();

            //fonction qui instancie une boule de feu
            Fire();

            shootTimer = shootCd;
        }

        //le joueur peut lancer une boule de feu que chaque 1s
        if (canShoot)
        {
            if (shootTimer > 0)
            {
                shootTimer -= Time.deltaTime;
            }
            else
            {
                canShoot = false;
            }
        }
    }

    void Fire()
    {
        FindObjectOfType<AudioManager>().Play("PlayerFireBall");
        Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);
        

    }
}
