using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    private float maxForce = 500f;
    private float maxSpeed = 7f;                                                        //Speed in world units per second
    private float rotationSpeed = 180f;                                                 //Rotation in Euler degrees per second
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        //Move
        Vector2 yDelta = Vector2.up * Input.GetAxisRaw("Vertical") * maxForce * Time.deltaTime;    //Vector2.up is shorthand for (0,1). Using that to prevent having to create new Vector2 in update

        //Rotate
        Quaternion rotation = transform.rotation;
        float rotationZ = rotation.eulerAngles.z;                                       //grab the Euler angle representation of the (quaternion) rotation on (Euler) z axis
        rotationZ -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;      //Change Z angle based on input
        rotation = Quaternion.Euler(0, 0, rotationZ);                                   //Recreate the quaternion

        //Update transform based on rotation and movement
        transform.rotation = rotation;

        rb.AddForce(rotation * yDelta);
        
	}

    private void FixedUpdate() {
        rb.velocity = rb.velocity.normalized* Mathf.Min(rb.velocity.magnitude, maxSpeed);
        
    }

}
