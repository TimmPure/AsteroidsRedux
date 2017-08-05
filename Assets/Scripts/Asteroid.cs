using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour {

    public float initialVelocity = 150f;
    private Transform parent;
    public bool InPlay { get; set; }

    public Vector2 randomVector = Vector2.zero;
    private Rigidbody2D rb;
    private float startMagnitude;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        parent = GameObject.Find("Asteroids").transform;
        if (!parent) { Debug.LogError("No Asteroid parent object found on " + name); }

        transform.parent = parent;

        RandomizeScale();
        GiveInitialVelocity();
        GiveInitialSpin();
	}

    private void RandomizeScale() {
        Vector2 asteroidScale = transform.localScale;
        if (Random.value > .5f) { asteroidScale.y *= -1f; }
        if (Random.value > .5f) { asteroidScale.x *= -1f; }
        transform.localScale = asteroidScale;
    }

    private void GiveInitialVelocity() {
        if (randomVector == Vector2.zero) {
            randomVector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }
        rb.AddForce(randomVector * initialVelocity);
    }

    private void GiveInitialSpin() {
        if (rb.angularVelocity == 0) {
            rb.angularVelocity = Random.Range(-240, 240)/rb.mass;
        }
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

    private void Update() {
        Vector2 screenPos = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPos.x > 0 && screenPos.x < 1f && screenPos.y > 0 && screenPos.y < 1f) {
            InPlay = true;
            GetComponent<PolygonCollider2D>().enabled = true;
        }

    }
}
