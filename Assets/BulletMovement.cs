using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    private float maxSpeed = 10f;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 yDelta = Vector2.up * maxSpeed * Time.deltaTime;
        transform.position += transform.rotation * yDelta;
    }
}
