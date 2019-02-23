using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour {



    public bool activated = false;
    private SpriteRenderer sp;
    [SerializeField]
    private Sprite activatedState, deactivatedState;
    // Use this for initialization
    void Start () {
        sp = this.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pushable" || collision.gameObject.tag == "Player")
        {
            Debug.Log("gotem");
            sp.sprite = activatedState;
            activated = true;
        }    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pushable" || collision.gameObject.tag == "Player")
        {
            sp.sprite = deactivatedState;
            activated = false;
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
