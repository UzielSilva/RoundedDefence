using UnityEngine;
using System.Collections;
using RoundedDefence;

public class TowerSelect : MonoBehaviour {
	
	GameObject bbottom;
	GameObject bleft;
	GameObject bright;
	GameObject bupper;
	GameObject bcenter;
	GameObject bll;
	GameObject blr;
	GameObject bur;
	GameObject bul;

	GameObject fade;
	
	Camera cam ;
	float height;
	float width ;
	
	float fader=0;
	float fading=0;
	// Use this for initialization
	void Start () {
		Lib.mute ();
		bbottom = GameObject.Find ("bbottom");
		bleft = GameObject.Find ("bleft");
		bright = GameObject.Find ("bright");
		bupper = GameObject.Find ("bupper");
		bcenter = GameObject.Find ("bcenter");
		bll = GameObject.Find ("bll");
		blr = GameObject.Find ("blr");
		bur= GameObject.Find ("bur");
		bul = GameObject.Find ("bul");
		fade = GameObject.Find ("fade");
		
		cam=Camera.main;
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		Update ();
		//fading = -.04f;
		//fader = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (fading == 0) {
			bleft.transform.position = new Vector3 (-width/6f -.2f,0, 0);
			bright.transform.position = new Vector3 (width/6f +.2f,0, 0);
			bbottom.transform.position = new Vector3 (0,-height/6f, 0);
			bupper.transform.position = new Vector3 (0,height/6f, 0);
			bcenter.transform.position = new Vector3 (0,0, 0);
			bll.transform.position = new Vector3 (-width/6f,-height/6f, 0);
			blr.transform.position = new Vector3 (width/6f,-height/6f, 0);
			bul.transform.position = new Vector3 (-width/6f,height/6f, 0);
			bur.transform.position = new Vector3 (width/6f,height/6f, 0);
			
			bcenter.transform.localScale= new Vector3 (width*1.7f,height*1.5f, 0);
			bbottom.transform.localScale= new Vector3 (width*1.7f,-1f, 0);
			bupper.transform.localScale= new Vector3 (width*1.7f,1f, 0);
			bleft.transform.localScale= new Vector3 (width*.7f,1f, 0);
			bright.transform.localScale= new Vector3 (width*.7f ,-1f, 0);
		} else {
			faderr ();
		}
	}
	void faderr(){
		fader += fading ;
		if (fader > 0f && fader < 1f) {
			Color c = fade.renderer.material.color;
			c.a = fader;
			fade.renderer.material.color = c;
			cam.audio.volume=1f-fader;
		} else {
			fading=0f;
			
		}
	}
}
