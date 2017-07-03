using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    // this is the difference between the players position and the cameras position
    private Vector3 offset;

	
	void Start () {
        
        offset = transform.position - player.transform.position;
            	
	}
	
	
	void LateUpdate () {
        // moves the camera with the player object
        transform.position = player.transform.position + offset;
	}
}
