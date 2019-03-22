using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {


    public GameObject fc;
    public GameObject forest;

    private bool once = true;
	// Use this for initialization
	void Start () {
        fc = GameObject.FindGameObjectWithTag("FollowBG");
	}
	
	// Update is called once per frame
	void Update () {
		if(once == false)
        {
            Destroy(this, 60f);
        }
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(once == true)
            {
                Instantiate(forest, fc.transform.position, Quaternion.identity);
                once = false;
            }
            
            
            
        }
    }
   



}
