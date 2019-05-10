using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class LevelCoordinator : MonoBehaviour {

    [SerializeField]
    private string toPlay;
    // Use this for initialization
    public bool hasStarted = true;


    public bool hideCursor = false;
    
    private void Awake()
    {
        if(hideCursor == true)
            Cursor.visible = false;
        else
            Cursor.visible = true;

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
            FindObjectOfType<AudioManager>().StopEverything();
            FindObjectOfType<AudioManager>().Play(toPlay);
            Time.timeScale = 1f;
            hasStarted = false;
        }
    }
}
