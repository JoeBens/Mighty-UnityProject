using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 2.0f;
    Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", 0.5f);
            //StartCoroutine(FallAfterDelay());
            Destroy(this, 2f);
        }
    }

    /*IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(fallDelay);
        GetComponent<Rigidbody>().isKinematic = false;
    }*/
    void Fall()
    {
        rb.isKinematic = false;
    }
}
