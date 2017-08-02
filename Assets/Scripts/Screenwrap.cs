using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenwrap : MonoBehaviour {
    private Camera cam;
    private Transform player;

    private float camHeight, camWidth;
    private Vector2 playerPos;

    void Start()
    {
        player = GetComponent<Transform>();
        cam = Camera.main;

        camHeight = cam.orthographicSize;                     //orthoSize = camera height half-size in game units
        camWidth = cam.aspect * camHeight;
    }

    private void LateUpdate()
    {
        ScreenWrap();
    }

    private void ScreenWrap()
    {
        playerPos = player.position;

        if(Mathf.Abs(playerPos.x) >= camWidth)
        {
            playerPos.x *= -.99f;
        }
        if (Mathf.Abs(playerPos.y) >= camHeight)
        {
            playerPos.y *= -.99f;
        }

        player.position = playerPos;
    }

}
