using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBox : MonoBehaviour {


    private SpriteRenderer sp;
    [SerializeField]
    private Sprite activatedState, deactivatedState;
	// Use this for initialization
	void Start () {
        sp = this.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PressurePadActivator")
            sp.sprite = activatedState;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PressurePadActivator")
            sp.sprite = deactivatedState;
    }

    void Update () {
		
	}
}
