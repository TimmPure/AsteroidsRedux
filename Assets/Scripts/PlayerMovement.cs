using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float maxSpeed = 5f;                                                        //Speed in world units per second
    private float rotationSpeed = 180f;                                                 //Rotation in Euler degrees per second
	
	void Update () {
        //Move
        Vector2 yDelta = Vector2.up * Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;    //Vector2.up is shorthand for (0,1). Using that to prevent having to create new Vector2 in update

        //Rotate
        Quaternion rotation = transform.rotation;
        float rotationZ = rotation.eulerAngles.z;                                       //grab the Euler angle representation of the (quaternion) rotation on (Euler) z axis
        rotationZ -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;      //Change Z angle based on input
        rotation = Quaternion.Euler(0, 0, rotationZ);                                   //Recreate the quaternion

        //Update transform based on rotation and movement
        transform.rotation = rotation;
        transform.position += rotation * yDelta;
	}
}
