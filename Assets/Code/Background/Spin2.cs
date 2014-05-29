using UnityEngine;
using System.Collections;
using RoundedDefence;

public class Spin2 : MonoBehaviour {
	public Vector3 center;
	public float radius;
	public float angle;
	public float speed;
	bool trans = false;
	float inten=0f;
	// Use this for initialization
	void Start () {
		transform.localPosition = new Vector3 (center.x +(radius* Mathf.Cos (angle) ), center.y+(radius* Mathf.Sin (angle)) , 0f);
		
		if(speed<0)
			
			transform.Rotate (Vector3.forward,180);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (angle <(Mathf.PI*2) -(Mathf.PI/180*10) && angle > Mathf.PI)
			trans = false;
		else 
			trans = true;
		if (trans != true && inten < 1f)
			inten += .05f;
		if (trans != false && inten > 0f)
			inten -= .05f;
		angle += speed;
		angle = ((2 * Mathf.PI) + angle) % (Mathf.PI * 2);
		if (center.x == 0) {
			
			Color c = renderer.material.color;
			c.a = inten;
			renderer.material.color = c;
			transform.position = new Vector3 (center.x + (radius * Mathf.Cos (angle)), center.y + (radius * Mathf.Sin (angle)), 0f);
		}else if(center.y<0)
			transform.position = new Vector3 (center.x + (radius * Mathf.Cos (angle))+(Lib.width()/2f), center.y + (radius * Mathf.Sin (angle))-(Lib.height()/2f), 0f);
		else
			transform.position = new Vector3 (center.x + (radius * Mathf.Cos (angle))-(Lib.width()/2f), center.y + (radius * Mathf.Sin (angle))+(Lib.height()/2f), 0f);
		transform.Rotate (Vector3.forward, speed * 180 / Mathf.PI);
	}
	//Lib.followCamera (GameObject.Find(name));
}

