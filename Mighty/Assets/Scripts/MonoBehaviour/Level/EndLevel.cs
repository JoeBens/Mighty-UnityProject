using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {


    public GameManager gameManager;
    public GameObject completeLevelUI;

    public int levelUnlocked;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cursor.visible = true;
            other.gameObject.GetComponent<Animator>().SetTrigger("LevelFinished");
            other.gameObject.GetComponent<PlayerAttack>().enabled = false;
            other.gameObject.GetComponent<CharacterController2D>().enabled = false;
            other.gameObject.GetComponent<PlayerMovement>().enabled = false;
            other.gameObject.GetComponent<PlayerCast>().enabled = false;
            PlayerPrefs.SetInt("LevelPassed", levelUnlocked);
            CompleteLevel();
        }
    }
    public void CompleteLevel()
    {
        FindObjectOfType<AudioManager>().PauseEverything();
        FindObjectOfType<AudioManager>().Play("LevelCompleted");
        completeLevelUI.SetActive(true);
        //Invoke("TimeFreeze", 1.5f);
    }
}
