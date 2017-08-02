using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class Bullet : MonoBehaviour {

    private float maxSpeed = 10f;

    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Vector2 yDelta = Vector2.up * maxSpeed * Time.deltaTime;
        transform.position += transform.rotation * yDelta;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroids"))
        {
            Destroy(gameObject);
        }
    }
}
