using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenwrap : MonoBehaviour {
    private Camera cam;
    private Asteroid asteroid;

    private float camHeight, camWidth;
    private Vector2 objPos;

    void Start()
    {
        cam = Camera.main;

        camHeight = cam.orthographicSize;
        camWidth = cam.aspect * camHeight;

        asteroid = GetComponent<Asteroid>();
    }

    private void LateUpdate()
    {
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
            objPos.x *= -.95f;
        }
        if (Mathf.Abs(objPos.y) >= camHeight)
        {
            objPos.y *= -.95f;
        }

        transform.position = objPos;
    }

}
