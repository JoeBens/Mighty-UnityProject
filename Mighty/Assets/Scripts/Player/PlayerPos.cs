using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour {

    private GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        this.transform.position = gm.lastCheckpointPos;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
