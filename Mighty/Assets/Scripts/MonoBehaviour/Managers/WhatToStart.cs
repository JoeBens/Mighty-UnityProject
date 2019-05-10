using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatToStart : MonoBehaviour {

    public GameObject button;


    private void Awake()
    {
        
        if (PlayerPrefs.GetString("FirstTime") == "no")
        {
            button.SetActive(false);
        }
    }
    // Use this for initialization
    void Start () {
        if (PlayerPrefs.GetString("FirstTime") == "no")
        {
            button.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetString("FirstTime") == "no")
        {
            button.SetActive(false);
        }
	}

    public void GameStartedAlready()
    {
        PlayerPrefs.SetString("FirstTime", "no");
    }

}
