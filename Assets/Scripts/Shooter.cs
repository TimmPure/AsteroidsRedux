using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectilePrefab;
    private GameObject projectile;
    private Transform projectileParent, shotOrigin;

    private float fireRate = 5f;                         //Rate of fire in number of shots per second
    private float timeToFire = 0f;
    private float shotStrength = 45f;

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
            timeToFire = Time.time + 1 / fireRate;
            Fire();
        }
    }

    public void Fire()
    {
        projectile = Instantiate(projectilePrefab, shotOrigin.position, shotOrigin.rotation) as GameObject;
        projectile.transform.parent = projectileParent;
        projectile.GetComponent<Rigidbody2D>().AddForce(shotOrigin.rotation * new Vector2(0,shotStrength));

        Destroy(projectile,2f);
    }
}
