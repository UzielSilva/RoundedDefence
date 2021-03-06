﻿using UnityEngine;
using System.Collections;
using RoundedDefence;

public class IslandSelected : MonoBehaviour {
	GameObject sun;
	public static string centroid="";
	 string oldcentroid="";
	Vector3 center;
	public float radius;
	public float angle;
	public float speed;
	// Use this for initialization
	void Start () {
		center = new Vector3 (0, -6, 0);
		transform.localPosition = new Vector3 (center.x +(radius* Mathf.Cos (angle) ), center.y+(radius* Mathf.Sin (angle)) , 0f);

		if(speed<0)
			
			transform.Rotate (Vector3.forward,180);
	}
	
	// Update is called once per frame
	void Update () {
		if (oldcentroid != centroid) {
			oldcentroid=centroid;
			sun=GameObject.Find(centroid);
		}
		if (sun != null) {
			
			center = sun.transform.position;
			angle += speed;
			angle = ((2 * Mathf.PI) + angle) % (Mathf.PI * 2);
			transform.position = new Vector3 (center.x + (radius * Mathf.Cos (angle)), center.y + (radius * Mathf.Sin (angle)), 0f);
			transform.Rotate (Vector3.forward, speed * 180 / Mathf.PI);
		}
		//Lib.followCamera (GameObject.Find(name));
	}
}
