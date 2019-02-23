using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    private Vector3 posA;
    private Vector3 posB;

    private Vector3 nextPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransformA;

    [SerializeField]
    private Transform childTransformB;


    // Use this for initialization
    void Start () {
        posA = childTransformA.localPosition;
        posB = childTransformB.localPosition;
        nextPos = posB;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}


    private void Move()
    {
        childTransformA.localPosition = Vector3.MoveTowards(childTransformA.localPosition, nextPos, speed * Time.deltaTime);

        if (Vector3.Distance(childTransformA.localPosition, nextPos) <= 0.1)
        {
            MoveBack();
        }
        
    }

    private void MoveBack()
    {
        nextPos = nextPos != posA ? posA : posB;
    }
}
