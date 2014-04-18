﻿using UnityEngine;
using System.Collections;

public class CameraDrag : MonoBehaviour {

	public float dragSpeed = 2;
	private Vector3 dragOrigin;
	// Use this for initialization
	void Start () {
	}
	
	void Update(){    
		Camera cam = Camera.main;
		float height = 2f * cam.orthographicSize;
		float width = height * cam.aspect;
		if (Input.GetMouseButtonDown (0)) {
				dragOrigin = Input.mousePosition;
				return;
		}

		if (!Input.GetMouseButton (0))
				return;
		Vector3 pos = Camera.main.ScreenToViewportPoint (Input.mousePosition - dragOrigin);
		if (transform.position.x + (pos.x * dragSpeed * -1.0f) > width/2 -5 && 
		    transform.position.x + (pos.x * dragSpeed * -1.0f) < -width/2 +5) {
				Vector3 move = new Vector3 (pos.x * dragSpeed * -1.0f, 0, 0);
				transform.Translate (move, Space.World); 
		}

		if (transform.position.y + (pos.y * dragSpeed * -1.0f) > height/2 -5&&
		    transform.position.y + (pos.y * dragSpeed * -1.0f) < -height/2 +5) {
				Vector3 move = new Vector3 (0, pos.y * dragSpeed * -1.0f, 0);
				transform.Translate (move, Space.World); 
		}
		dragOrigin = Input.mousePosition;
	}
}