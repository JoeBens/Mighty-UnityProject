using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {

    private GameObject player;
    [Range(0.0f, 50.0f)] // Slide Bar.
    public float jumpHeight = 30f; // The amount of bounce.
    //public AudioClip bounceSfx; // the bounce sound effect audio clip.
    [Range(0.0f, 5.0f)] // Slide Bar.
    public float bounceSfxVolume = 1f; // the bounce sound effect volume amount.
    private Animator myAnim; // The animator component used for create the mushroom move effect.
    


    // Use this for initialization
    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        myAnim = GetComponent<Animator>();

    }
    // When the mushroom contacts with an object tagged with the name "player" the mushroom functions are activated.
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, jumpHeight); // The formula used to generate the mushroom jump is the same as we used to get the jump and double jump of our character.
            //AudioSource.PlayClipAtPoint(bounceSfx, Camera.main.transform.position, bounceSfxVolume); // We instantiate a sound every time the player touches the top of the mushroom.
            myAnim.SetTrigger("Boing"); // Sets the mushroom's bounce animation.
           

        }
    }

}
