using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public Vector3 lastCheckpointPos;

    public GameObject gameOverMenu;

    public GameObject completeLevelUI;

    public bool cannotPause = false;

    private GameObject player;

    /*[SerializeField]
    private GameObject playerPrefab;*/

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }


    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        
    }

    public void PlayerIsDead()
    {
        
        Destroy(player);
        FindObjectOfType<AudioManager>().PauseEverything();
        FindObjectOfType<AudioManager>().Play("GameOver");
        cannotPause = true;
        Invoke("TimeFreeze", 0.7f);
        

    }
    public void TimeFreeze()
    {
       Time.timeScale = 0f;
    }
    public void CompleteLevel()
    {
        FindObjectOfType<AudioManager>().PauseEverything();
        FindObjectOfType<AudioManager>().Play("LevelCompleted");
        completeLevelUI.SetActive(true);
        //Invoke("TimeFreeze", 1.5f);
    }



}
