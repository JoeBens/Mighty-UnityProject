using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightManager : MonoBehaviour {

    public Boss boss;
    public Switch switch1, switch2, switch3, switch4;
    public GameObject pp1, pp2;
    public GameObject activateBoss, bossImpact, bossFightCam, BossKillerOne, BossKillerTwo;

    bool sOneF = false, sTwoF = false;


    private float waitTimeForNextScene = 6f;

    
    // Use this for initialization
    void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            activateBoss.SetActive(true);
            bossFightCam.SetActive(true);
            switch1.gameObject.SetActive(true);
            switch2.gameObject.SetActive(true);
            FindObjectOfType<AudioManager>().Play("BossFight");
            this.GetComponent<Collider2D>().enabled = false;
            bossImpact.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update () {
        checkSwitches();

        if(activateBoss == null)
        {
            if (waitTimeForNextScene > 0)
                waitTimeForNextScene -= Time.deltaTime;
            else
                FindObjectOfType<LevelLoader>().RestartLevel(6);
        }
		
	}

    public void checkSwitches()
    {
        
        if (switch1.activated == true)
        {
            boss.state = 1;
            if(sTwoF == false)
                sOneF = true;
        }

        if (switch2.activated == true)
        {
            boss.state = 1;
            if (sOneF == false)
                sTwoF = true;
        }

        if (switch1.activated == true && switch2.activated == true)
        {
            boss.state = 2;
            if(sOneF == true)
                switch3.gameObject.SetActive(true);
            if (sTwoF == true)
                switch4.gameObject.SetActive(true);
        }

        if (switch3.activated == true)
        {
            pp1.gameObject.SetActive(true);
            boss.state = 3;
        }

        if (switch4.activated == true)
        {
            pp2.gameObject.SetActive(true);
            boss.state = 3;
        }

        if(pp1.GetComponentInChildren<PressurePad>().activated == true || pp2.GetComponentInChildren<PressurePad>().activated == true)
        {
            BossKillerOne.SetActive(true);
            BossKillerTwo.SetActive(true);
        }
    }
}
