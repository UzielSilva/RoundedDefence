﻿using UnityEngine;
using System.Collections;
using RoundedDefence;

public class Star : MonoBehaviour {
	float alpha;
	float dir;
	Vector3 origin;
	float size;
	float vel;
	float angle;
    Vector3 old;
    public Camera cam;
	// Use this for initialization
	void Start () {
		dir = -.01f;
		alpha = .1f;
		vel = 0;
        origin = Input.mousePosition;
        old = transform.position;
	}	
	
	// Update is called once per frame
	void Update () {
        transform.position = old;
        transform.position = new Vector3(transform.position.x + Camera.main.transform.position.x, transform.position.y + Camera.main.transform.position.y, transform.position.z);

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - origin);
        origin = Input.mousePosition;
		transform.Translate( new Vector3 (pos.x * size * 30.0f,pos.y * size * 30.0f ,0));
		transform.Translate( new Vector3 (vel*Mathf.Cos(angle),vel*Mathf.Sin(angle) ,0));
		
		if (Input.GetMouseButton(0)) {
			Vector3 mousePos = Lib.mouseCord(cam);
			vel=.001f/(Mathf.Pow(mousePos.x-transform.position.x,2f)+Mathf.Pow(mousePos.y-transform.position.y,2f));
			angle=Mathf.Atan2(-mousePos.y+transform.position.y,-mousePos.x+transform.position.x);
		}
		if (vel > .03f)
			vel = .03f;
		if (vel < 0f)
						vel = 0f;
				else
						vel -= .0001f;
		alpha += dir;
		if (alpha + dir > .9f)
			dir = -dir;
		if (alpha + dir < .1f) {
				vel=0;
			dir = Random.Range(.001f, .008f);
			 size=Random.Range(.011f, .022f);
			Color cc = renderer.material.color;
			cc.r=Random.Range(.8f, 1f);
			cc.g=Random.Range(.8f, 1f);
			cc.b=Random.Range(.7f, .8f);
			renderer.material.color = cc;
			transform.localScale=new Vector3(size,size,1f);
			float height = 2f * Camera.main.orthographicSize;
			float width = height * Camera.main.aspect;
			transform.position=
				new Vector3(Random.Range(-width/2f, width/2f),Random.Range(-height/2f, height/2f),10f);
			transform.Translate(Camera.main.transform.position);
		}
		Color c = renderer.material.color;
		c.a =alpha + Random.Range(-.1f, .1f);
		renderer.material.color = c;
        old = new Vector3(transform.position.x - Camera.main.transform.position.x, transform.position.y - Camera.main.transform.position.y, transform.position.z);
	}
}
