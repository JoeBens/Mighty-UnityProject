using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {


    private bool canShoot;
    private float shootTimer = 0f;
    [SerializeField]
    private float shootCd = 0.3f;

    [SerializeField]
    private Transform origin, controlPoint;

    [SerializeField]
    private GameObject ballPrefab;

    // Use this for initialization
    void Start () {
        //GameObject obj = Instantiate(ballPrefab, origin.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
        SpawnProjectile();
    }

    private void SpawnProjectile()
    {
        
        //shoot
        if (!canShoot)
        {
            canShoot = true;
            GameObject obj = Instantiate(ballPrefab, origin.position, Quaternion.identity);
            obj.GetComponent<AcidProjectile>().origin = this.origin;
            obj.GetComponent<AcidProjectile>().controlPoint = this.controlPoint;

            shootTimer = shootCd;
        }
        //pour s'assurer que l'ennemi ne spamme pas l'attaque
        if (canShoot)
        {
            if (shootTimer > 0)
            {
                shootTimer -= Time.deltaTime;
            }
            else
            {
                canShoot = false;
            }
        }



    }

}
