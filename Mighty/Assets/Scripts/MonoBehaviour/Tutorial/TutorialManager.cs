using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

    public GameObject[] popups;
    private int popupIndex = 0;
    public float popupCd;
    private float popupTime;



    public GameObject player, platformOne, platformTwo, jumpChecker, doubleJumpChecker, enemy, enemyTwo;

    private void Start()
    {
        player.GetComponent<CharacterController2D>().jumpForce = 0;
        
    }


    private void Update()
    {
     
        for (int i = 0; i < popups.Length; i++)
        {
            if(i == popupIndex)
            {
                if(popupTime > 0)
                {
                    popupTime -= Time.deltaTime;
                }
                else
                {
                    popups[i].SetActive(true);
                }
            }
            else
            {
                popups[i].SetActive(false);
            }
        } 

        if (popupIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.Q)|| Input.GetKeyDown(KeyCode.D))
            {
                popupTime = popupCd;
                popupIndex++;
            }
        }
        else if (popupIndex == 1)
        {
            player.GetComponent<CharacterController2D>().jumpForce = 1300;
            platformOne.SetActive(true);
            jumpChecker.SetActive(true);
            bool check = jumpChecker.GetComponent<DoubleJumpChecker>().playerHit;
            if (check == true)
            {
                popupTime = popupCd;
                popupIndex++;
            }
        }
        else if (popupIndex == 2)
        {
            
            platformTwo.SetActive(true);
            doubleJumpChecker.SetActive(true);
            bool check = doubleJumpChecker.GetComponent<DoubleJumpChecker>().playerHit;
            if (check == true)
            {
                popupTime = popupCd;
                popupIndex++;
            }
        }
        else if(popupIndex == 3)
        {
            Destroy(platformOne, 1f);
            Destroy(platformTwo, 1f);
            if (Input.GetMouseButtonDown(0))
            {
                popupTime = popupCd;
                popupIndex++;
            }
        }
        else if(popupIndex == 4)
        {
            
            if (Input.GetMouseButtonDown(1))
            {
                popupTime = popupCd;
                popupIndex++;
            }
        }
        else if(popupIndex == 5)
        {
           
            if (Input.GetMouseButtonDown(2))
            {
                popupTime = popupCd;
                popupIndex++;
            }
        }
        else if (popupIndex == 6)
        {
            
            if (enemy != null)
            {
                enemy.SetActive(true);
            }
            else
            {
                popupTime = popupCd;
                popupIndex++;
            }
        }
        else if (popupIndex == 7)
        {
            
            if (enemyTwo != null)
            {
                enemyTwo.SetActive(true);
            }
            else
            {

                popupTime = popupCd;
                popupIndex++;
            }
        }
        else if(popupIndex == 8)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                FindObjectOfType<LevelLoader>().LoadLevel(1);
                this.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                FindObjectOfType<LevelLoader>().LoadLevel(2);
                this.gameObject.SetActive(false);
            }
        }
    }

}
