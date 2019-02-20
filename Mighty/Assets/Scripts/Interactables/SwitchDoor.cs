using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour {


    [SerializeField]
    private Switch[] neededSwitches;

    private bool openable = true;
    private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
    }

    private void checkSwitches()
    {
        int c = 0;
        for(int i = 0; i < neededSwitches.Length; i++)
        {
            if(neededSwitches[i].activated == true)
            {
                c++;
            }
        }
        if (c == neededSwitches.Length && openable == true)
        {
            anim.SetTrigger("Open");
            openable = false;
        }
            
    }
	
	// Update is called once per frame
	void Update () {
        checkSwitches();
	}
}
