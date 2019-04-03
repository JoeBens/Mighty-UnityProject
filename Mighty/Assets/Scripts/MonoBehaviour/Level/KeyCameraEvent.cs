using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCameraEvent : MonoBehaviour {

    private bool activatedCam = false;

    public PressurePad pressurePad;

    public GameObject EventCam;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckPad();
	}

    public void CheckPad()
    {
        if(pressurePad.activated == true && activatedCam == false)
        {
            activatedCam = true;
            StartCoroutine(ActivateCam());
        }
    }

    IEnumerator ActivateCam()
    {
        EventCam.SetActive(true);
        yield return new WaitForSeconds(4f);
        EventCam.SetActive(false);
    }
}
