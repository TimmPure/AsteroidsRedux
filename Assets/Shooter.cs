using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectilePrefab;
    private GameObject projectile;
    private Transform projectileParent, shotOrigin;

    private float fireRate = 5f;                         //Rate of fire in number of shots per second. Set to zero for single shots.
    private float timeToFire = 0f;

    private void Start()
    {
        shotOrigin = GameObject.Find("ShotOrigin").transform;
        if (!shotOrigin) { Debug.LogError("No Shot Origin found"); }

        projectileParent = GameObject.Find("Projectiles").transform;
        if (!projectileParent) { Debug.LogError("No projectile parent object found"); }
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;                           //and increment timeToFire
            Fire();
        }
    }

    public void Fire()
    {
        projectile = Instantiate(projectilePrefab, shotOrigin.position, shotOrigin.rotation) as GameObject;
        projectile.transform.parent = projectileParent;

        Destroy(projectile,2f);
    }
}
