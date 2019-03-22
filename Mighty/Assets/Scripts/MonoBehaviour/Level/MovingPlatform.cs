using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    private Vector3 posA;
    private Vector3 posB;

    private float waitTime;
    public float startWaitTime;

    private Vector3 nextPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransformA;

    [SerializeField]
    private Transform childTransformB;

    //public AudioClip clip;

    // Use this for initialization
    void Start () {
        posA = childTransformA.localPosition;
        posB = childTransformB.localPosition;
        nextPos = posB;
        //FindObjectOfType<AudioManager>().Play("MovingPlatform");
        //AudioSource.PlayClipAtPoint(clip, this.transform.position, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}


    private void Move()
    {
        childTransformA.localPosition = Vector3.MoveTowards(childTransformA.localPosition, nextPos, speed * Time.deltaTime);

        if (Vector3.Distance(childTransformA.localPosition, nextPos) <= 0.2)
        {

            if (waitTime <= 0)
            {
                MoveBack();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            
        }
        
    }

    private void MoveBack()
    {
        nextPos = nextPos != posA ? posA : posB;
    }
}
