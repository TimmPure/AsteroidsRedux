using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour {

    public float initialVelocity = 100f;
    private Transform parent;

    private Vector2 randomVector;
    private Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        randomVector = new Vector2(Random.Range(-1f,1f), Random.Range(-1f, 1f)).normalized;
        rb.AddForce(randomVector * initialVelocity);
        parent = GameObject.Find("Asteroids").transform;
        if (!parent) { Debug.LogError("No Asteroid parent object found on " + name); }

        transform.parent = parent;
	}
}
