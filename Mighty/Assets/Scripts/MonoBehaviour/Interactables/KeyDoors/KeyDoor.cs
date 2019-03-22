using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour {

    [SerializeField]
    private Sprite[] states;
    private SpriteRenderer sp;

    private Animator anim;

    public bool openable = true;

    [SerializeField]
    private int keysNeeded;

    public int keysActivated = 0;

    private int currentState = 0;

    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
        sp = this.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        CheckKeys();

    }

    public void CheckKeys()
    {
        int c = 0;
        for (int i = 0; i < keysActivated; i++)
        {
            c++;
        }
        currentState = c;
        sp.sprite = states[currentState];


        if (keysNeeded == keysActivated && openable == true)
        {
            anim.SetTrigger("Open");
            FindObjectOfType<AudioManager>().Play("HubDoorOpen");
            openable = false;
        }
    }
}
