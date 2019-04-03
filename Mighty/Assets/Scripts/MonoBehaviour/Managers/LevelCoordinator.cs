using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCoordinator : MonoBehaviour {

    [SerializeField]
    private string toPlay;
    // Use this for initialization
    private bool hasStarted = true;
    
    private void Awake()
    {
        Time.timeScale = 1f;
        hasStarted = true;
    }
    void Start () {
        Time.timeScale = 1f;
        
	}
	
	// Update is called once per frame
	void Update () {
		if(hasStarted == true)
        {
            FindObjectOfType<AudioManager>().PauseEverything();
            FindObjectOfType<AudioManager>().Play(toPlay);
            Time.timeScale = 1f;
            hasStarted = false;
        }
	}
}
