using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLock : MonoBehaviour {

    public Button levelTwo, levelThree;
    public GameObject level2, level3;
    int levelPassed;


    // Use this for initialization
    void Start () {
        
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        levelTwo.interactable = false;
        level2.SetActive(false);
        levelThree.interactable = false;
        level3.SetActive(false);
        switch (levelPassed)
        {
            case 1:
                levelTwo.interactable = true;
                level2.SetActive(true);
                break;
            case 2:
                levelTwo.interactable = true;
                level2.SetActive(true);
                levelThree.interactable = true;
                level3.SetActive(true);
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
