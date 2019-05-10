using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class PlayerStat : MonoBehaviour, IDamageable {



    [SerializeField]
    private GameObject bloodEffectPrefab;

    public GameObject gameOverMenu;


    public int health;

    private Animator anim;

    public int howManyGems;

    public int howManyKeys;

    public bool isDead = false;

    public int Health{ get; set; }
    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animator>();
        Health = health;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("OutOfScreen"))
        {
            Health = -1;
            
        }
        if (other.gameObject.CompareTag("DoorKey"))
        {
            if(other.gameObject.GetComponent<KeyDoor>() != null)
            {
                other.gameObject.GetComponent<KeyDoor>().keysActivated += howManyKeys;
                FindObjectOfType<AudioManager>().Play("KeyActivated");
                howManyKeys = 0;
            }

        }
    }

    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Player Damaged");
        Health -= damageAmount;
        anim.SetTrigger("Hurt");
        FindObjectOfType<AudioManager>().Play("PlayerHurt");
        

        GameObject effect = Instantiate(bloodEffectPrefab, transform.position, transform.rotation);
        Destroy(effect, 0.5f);
    }


	// Update is called once per frame
	void Update () {
        //Debug.Log("Gems: " + this.howManyGems);
        //Debug.Log("Health: " + this.Health);

        if (Health > health)
            Health = health;
        if (Health <= 0)
        {

            Health = 0;
            anim.SetTrigger("Death");
            Cursor.visible = true;
            //FindObjectOfType<AudioManager>().Play("PlayerDeath");
            gameOverMenu.SetActive(true);
            FindObjectOfType<GameManager>().PlayerIsDead();
        }

    }

}
