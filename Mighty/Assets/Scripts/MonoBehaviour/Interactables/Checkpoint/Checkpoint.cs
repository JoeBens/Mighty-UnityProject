using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private GameManager gm;
    private bool activated = false;
    private Animator anim;


    public GameObject effectActivation;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        anim = this.GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && activated == false)
        {
            gm.lastCheckpointPos = this.transform.position;
            activated = true;
            FindObjectOfType<AudioManager>().Play("Checkpoint");
            GameObject effect = Instantiate(effectActivation, transform.position, transform.rotation);
            Destroy(effect, 0.8f);
            anim.SetTrigger("Activated");
        }
    }
}