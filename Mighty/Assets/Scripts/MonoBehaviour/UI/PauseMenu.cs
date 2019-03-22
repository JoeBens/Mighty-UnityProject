using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    

    public CharacterController2D characterController;
    public PlayerMovement pm;
    public PlayerAttack pa;
    public PlayerCast pc;

    private float originalVolume;


    private void Start()
    {
        originalVolume = AudioListener.volume;
        FindObjectOfType<GameManager>().cannotPause = false;

    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && CanPause() == true)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        characterController.enabled = true;
        pa.enabled = true;
        pm.enabled = true;
        pc.enabled = true;
        AudioListener.volume = originalVolume;

    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        pc.enabled = true;
        pa.enabled = false;
        pm.enabled = false;
        characterController.enabled = false;
        AudioListener.volume *= 0.3f;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        AudioListener.volume = originalVolume;
        FindObjectOfType<AudioManager>().Pause("Theme");
        SceneManager.LoadScene("Start Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool CanPause()
    {
        if(FindObjectOfType<GameManager>().cannotPause == false)
        {
            return true;
        }
        else
            return false;
    }
}
