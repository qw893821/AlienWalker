using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    GameObject player;
    Vector3 camPos;
    private Vector3 offset;
	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
        offset.x = 0f;
        offset.z = 0f;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
		
	}
}
