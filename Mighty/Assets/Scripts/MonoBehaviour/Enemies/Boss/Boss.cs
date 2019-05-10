using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Boss : MonoBehaviour {


    public Transform[] waypoints;
    private float waitTime;
    public float startWaitTime;
    int i = 0;
    public float speed;
    public float dynamicSpeed;
    private Animator anim;

    public GameObject particleEffect;

    public int state = 0;

    public SpriteRenderer sp;
    private bool killed = false;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        dynamicSpeed = speed;
        


    }
   
    // Update is called once per frame
    void Update () {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("IDLE"))
        {
            return;
        }
        if(killed == false)
        {
            switch (state)
            {
                case 0:
                    State(dynamicSpeed, 1.5f, 0.4f, 0.4f);
                    break;
                case 1:

                    State(dynamicSpeed, 2.5f, 0.8f, 0.8f);
                    particleEffect.SetActive(true);
                    break;
                case 2:

                    State(dynamicSpeed, 4f, 1.2f, 1.2f);
                    sp.color = Color.grey;
                    break;
                case 3:
                    State(dynamicSpeed, 8f, 1.6f, 1.6f);
                    sp.color = Color.red;
                    break;
            }
        }
        
    }

    private void State(float bossSpeed, float multiplier, float shake1, float shake2)
    {
        Debug.Log("I'm HERE!!!!!!!!!!!!!");

        if (i % 2 == 1)
        {
            bossSpeed = speed * multiplier;
        }
        else
        {
            bossSpeed = speed;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[i].position, bossSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoints[i].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                i++;
                if (i > waypoints.Length - 1)
                {
                    i = 0;
                }
                waitTime = startWaitTime;
            }
            else
            {
                if (i % 2 == 1)
                {

                    CameraShaker.GetInstance("BossFightCam").ShakeOnce(shake1, shake2, 0.1f, 1f);
                }
                waitTime -= Time.deltaTime;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Impact")
        {
            FindObjectOfType<AudioManager>().Stop("BossImpact");
            FindObjectOfType<AudioManager>().Play("BossImpact");
        }


        if(collision.gameObject.tag == "BossKiller")
         {
             killed = true;
             FindObjectOfType<AudioManager>().StopEverything();
             StartCoroutine(BossDeath());
         }
    }
    
    IEnumerator BossDeath()
     {
         FindObjectOfType<AudioManager>().StopEverything();
         FindObjectOfType<AudioManager>().Play("BossDeathBuildUp");
         anim.SetTrigger("Death");
         yield return new WaitForSeconds(1f);
         FindObjectOfType<AudioManager>().Play("BossDeath");
         Invoke("StopPlay", 1f);

         

     }
     void StopPlay()
     {
         FindObjectOfType<AudioManager>().StopEverything();
         FindObjectOfType<AudioManager>().Play("BossCelebration");
            Destroy(this.gameObject, .5f);

     }
     
}
