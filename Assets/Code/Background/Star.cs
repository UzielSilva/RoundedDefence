using UnityEngine;
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
    public Camera cam1;
    public Camera cam2;
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
        transform.position = new Vector3((old.x) * cam1.orthographicSize + cam1.transform.position.x, (old.y) * cam1.orthographicSize + cam1.transform.position.y, old.z);

        Vector3 pos = cam2.ScreenToViewportPoint(Input.mousePosition - origin);
        origin = Input.mousePosition;
		transform.Translate( new Vector3 (pos.x * size * 30.0f,pos.y * size * 30.0f ,0));
		transform.Translate( new Vector3 (vel*Mathf.Cos(angle),vel*Mathf.Sin(angle) ,0));
		
		if (Input.GetMouseButton(0)) {
			Vector3 mousePos = Lib.mouseCord(cam1);
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
			 size=Random.Range(.006f, .012f);
			Color cc = renderer.material.color;
			cc.r=Random.Range(.8f, 1f);
			cc.g=Random.Range(.8f, 1f);
			cc.b=Random.Range(.7f, .8f);
			renderer.material.color = cc;
            transform.localScale = new Vector3(size, size, 1f);
			float height = cam1.orthographicSize;
			float width = height * cam1.aspect;
			transform.position=
				new Vector3(Random.Range(-width, width),Random.Range(-height, height),10f);
			transform.Translate(Camera.main.transform.position);
		}
		Color c = renderer.material.color;
		c.a =alpha + Random.Range(-.1f, .1f);
		renderer.material.color = c;
        transform.localScale = new Vector3(size*cam1.orthographicSize, size*cam1.orthographicSize, 1f);
        old = new Vector3((transform.position.x - cam1.transform.position.x) / cam1.orthographicSize, (transform.position.y - cam1.transform.position.y) / cam1.orthographicSize, transform.position.z);
	}
}
