﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;

    public Text progressText;

    public bool checkGameManager = true;


    public void LoadLevel(int sceneIndex)
    {
        if(checkGameManager == true)
        {
            FindObjectOfType<GameManager>().lastCheckpointPos = new Vector3(0, 0, 0);
        }
        
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
	
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/ .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            Debug.Log(progress);
            yield return null;
        }
    }
}
