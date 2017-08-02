using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenwrap : MonoBehaviour {
    private Camera cam;

    private float camHeight, camWidth;
    private Vector2 objPos;

    void Start()
    {
        cam = Camera.main;

        camHeight = cam.orthographicSize;                     //orthoSize = camera height half-size in game units
        camWidth = cam.aspect * camHeight;
    }

    private void LateUpdate()
    {
        Asteroid asteroid = GetComponent<Asteroid>();
        if (asteroid && !asteroid.InPlay) {
            return;
        }

        ScreenWrap();
    }

    private void ScreenWrap()
    {
        objPos = transform.position;

        if(Mathf.Abs(objPos.x) >= camWidth)
        {
            objPos.x *= -.99f;
        }
        if (Mathf.Abs(objPos.y) >= camHeight)
        {
            objPos.y *= -.99f;
        }

        transform.position = objPos;
    }

}
