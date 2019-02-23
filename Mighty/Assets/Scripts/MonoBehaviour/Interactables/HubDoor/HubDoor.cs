using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubDoor : MonoBehaviour {

    [SerializeField]
    private Sprite[] states;

    private SpriteRenderer sp;
    private int currentState = 0;

    private Animator anim;


    public bool openable = true;

    public PressurePad[] pressurePads;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        sp = this.GetComponent<SpriteRenderer>();
        sp.sprite = states[currentState];
        
    }
	
	// Update is called once per frame
	void Update () {
        checkPads();
	}

    private void checkPads()
    {
        int c = 0;

        for(int i = 0; i <pressurePads.Length; i++)
        {
            if(pressurePads[i].activated == true)
            {
                c++;
                
            }
        }
        currentState = c;
        sp.sprite = states[currentState];

        if (c == pressurePads.Length && openable == true)
        {
            anim.SetTrigger("Open");
            openable = false;
        }
    }
}
