using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(BackToMainMenu());
	}
	IEnumerator BackToMainMenu()
    {
        yield return new WaitForSeconds(10f);
        FindObjectOfType<LevelLoader>().RestartLevel(0);
    }
}
