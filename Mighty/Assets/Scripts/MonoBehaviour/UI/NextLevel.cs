using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public string levelName = "Level 2";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadNewLevel()
    {
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().lastCheckpointPos = new Vector3(0,0,0);
        SceneManager.LoadScene(levelName);
    }
}
