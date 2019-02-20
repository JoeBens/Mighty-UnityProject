using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidProjectile : MonoBehaviour {

    [SerializeField]
    private int projectileDamage;
    private bool canDamage=true;

    public Transform origin, controlPoint;

    private Transform target;

    [SerializeField]
    private float duration;
    private float currentDuration;

    private Vector3 targetPos;


    // Use this for initialization
    void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        targetPos = target.position;
    }
	
	// Update is called once per frame
	void Update () {

        this.transform.position = CalculateBezierPoint(currentDuration / duration, origin.position, targetPos, controlPoint.position);
        currentDuration += Time.deltaTime;
    }

    private Vector3 CalculateBezierPoint(float t, Vector3 startPosition, Vector3 endPosition, Vector3 controlPoint)
    {
        float u = 1 - t;
        float uu = u * u;

        Vector3 point = uu * startPosition;
        point += 2 * u * t * controlPoint;
        point += t * t * endPosition;

        return point;
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit" + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (canDamage == true)
            {
                hit.TakeDamage(projectileDamage);
                canDamage = false;
                StartCoroutine(ResetCanDamage());
            }

        }
        Destroy(gameObject);
    }
    IEnumerator ResetCanDamage()
    {
        yield return new WaitForSeconds(0.5f);
        canDamage = true;
    }

}
