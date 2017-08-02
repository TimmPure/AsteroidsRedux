using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour {

    public float initialVelocity = 150f;
    private Transform parent;

    private Vector2 randomVector;
    private Rigidbody2D rb;
    private float startMagnitude;

	void Start () {
        rb = GetComponent<Rigidbody2D>();

        //Give Asteroid an initial velocity in a random direction
        randomVector = new Vector2(Random.Range(-1f,1f), Random.Range(-1f, 1f)).normalized;
        rb.AddForce(randomVector * initialVelocity);

        parent = GameObject.Find("Asteroids").transform;
        if (!parent) { Debug.LogError("No Asteroid parent object found on " + name); }
        transform.parent = parent;
	}

    private void FixedUpdate()
    {
        if (startMagnitude == 0f)
        {
            startMagnitude = rb.velocity.magnitude;
        }

        //Hard-code velocity magnitude staying the same after collisions
        rb.velocity = rb.velocity.normalized * startMagnitude;
    }
}
