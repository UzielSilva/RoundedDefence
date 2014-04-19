using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {
	float alpha;
	float dir;
	Vector3 origin;
	float size;
	// Use this for initialization
	void Start () {
		dir = -.01f;
		alpha = .1f;
		origin = Input.mousePosition;
	}	
	
	// Update is called once per frame
	void Update () {
		
		Vector3 pos = Camera.main.ScreenToViewportPoint (Input.mousePosition - origin);
		origin = Input.mousePosition;
		transform.Translate( new Vector3 (pos.x * size * 30.0f,pos.y * size * 30.0f ,0));
		alpha += dir;
		if (alpha + dir > .9f)
			dir = -dir;
		if (alpha + dir < .1f) {
			dir = Random.Range(.001f, .008f);
			 size=Random.Range(.009f, .02f);
			Color cc = renderer.material.color;
			cc.r=Random.Range(.7f, 1f);
			cc.g=Random.Range(.7f, 1f);
			cc.b=Random.Range(.7f, 1f);
			renderer.material.color = cc;
			transform.localScale=new Vector3(size,size,1f);
			Camera cam=Camera.main;
			float height = 2f * cam.orthographicSize;
			float width = height * cam.aspect;
			transform.position=
				new Vector3(Random.Range(-width/5f, width/5f),Random.Range(-height/5f, height/5f),0f);
		}
		Color c = renderer.material.color;
		c.a =alpha + Random.Range(-.1f, .1f);
		renderer.material.color = c;
	}
}
