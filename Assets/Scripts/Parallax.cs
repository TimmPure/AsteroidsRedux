using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Parallax : MonoBehaviour {

    private MeshRenderer background;
    private GameObject player;

    private float parallax = 10f;

	void Start () {
        background = GetComponent<MeshRenderer>();

        player = GameObject.Find("Player");
        if (!player) { Debug.LogError("No Player found for parallax"); }
    }
	
	void Update () {
        background.material.mainTextureOffset = Vector2.Lerp(background.material.mainTextureOffset, player.transform.position / parallax, 0.8f);
	}
}
