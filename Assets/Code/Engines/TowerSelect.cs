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
	
	GameObject star;
	GameObject point;
	GameObject starText;
	GameObject pointText;
	GameObject title;
	GameObject subtitle;
	GameObject basic;
	GameObject improved;
	GameObject advanced;
	
	GameObject back;
	GameObject play;
	
	GameObject[,] tower;
	public Sprite sprite;
	Camera cam ;
	float height;
	float width ;
	int pointtxt=0;
	int titletxt=10;
	int subtitletxt=38;
	
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
		
		star = GameObject.Find ("star");
		point = GameObject.Find ("point");
		starText = GameObject.Find ("starText");
		pointText = GameObject.Find ("pointText");
		title = GameObject.Find ("title");
		subtitle = GameObject.Find ("subtitle");
		basic= GameObject.Find ("basic");
		advanced = GameObject.Find ("advanced");
		improved = GameObject.Find ("improved");

		play = GameObject.Find ("play");
		back = GameObject.Find ("back");
		tower = new GameObject[6,3];
		for (int i=0; i<6; i++)
			for (int e=0; e<3; e++) {
			
			tower[i,e] = new GameObject("tower"+i+"level"+e);
			tower[i,e].AddComponent<SpriteRenderer>();
			SpriteRenderer sprRenderer= (SpriteRenderer)tower[i,e].renderer; 
			sprRenderer.sprite=sprite;
			sprRenderer.sortingLayerName = "Others";
			sprRenderer.sortingOrder = 5;
			tower[i,e].transform.position = new Vector3(i*width/18f,e*height/18f,0);
			tower[i,e].transform.localScale = new Vector3(.5f,.5f,1f);
			tower[i,e].transform.rotation = transform.rotation;
			}
		starText.renderer.sortingLayerName="Shots";
		pointText.renderer.sortingLayerName="Shots";  
		title.renderer.sortingLayerName="Shots";  
		subtitle.renderer.sortingLayerName="Shots";  
		basic.renderer.sortingLayerName="Shots";  
		advanced.renderer.sortingLayerName="Shots";  
		improved.renderer.sortingLayerName="Shots";  
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
			height = 2f * cam.orthographicSize;
			width = height * cam.aspect;
			backgroundbox();
			back.transform.position=new Vector3(-width/2.2f +.8f,-height/2.2f+.5f,0f);
			play.transform.position=new Vector3(width/2.2f -.8f ,-height/2.2f +.5f,0f);
			star.transform.position=new Vector3(-width/2.2f + .1f,height/2.2f -.25f,0f);
			point.transform.position=new Vector3(width/2.2f -.1f ,height/2.2f -.30f,0f);
			starText.transform.position=new Vector3(-width/2.2f + .35f,height/2.2f -.15f,0f);
			pointText.transform.position=new Vector3(width/2.2f -.4f-(pointtxt*.114f),height/2.2f -.15f,0f);
			title.transform.position=new Vector3(-(titletxt*.11f),height/2.2f -.1f,0f);
			subtitle.transform.position=new Vector3(-(subtitletxt*.057f),height/2.2f -.45f,0f);

			
			basic.transform.position=new Vector3(-width/2.2f +.1f,height/20f *3f +.15f ,0f);
			advanced.transform.position=new Vector3(-width/2.2f +.1f,0.15f,0f);
			improved.transform.position=new Vector3(-width/2.2f +.1f,height/20f*-3f +.15f,0f);
			
			for (int i=0; i<6; i++)
			for (int e=0; e<3; e++) {
				tower[i,e].transform.position = new Vector3(i*width/7.6f - (width/3.8f),e*height/6.4f-(height/6),0);
			}
		} else {
			faderr ();
		}
	}
	void backgroundbox(){
		bleft.transform.position = new Vector3 (-width/2.2f -.2f,0, 0);
		bright.transform.position = new Vector3 (width/2.2f +.2f,0, 0);
		bbottom.transform.position = new Vector3 (0,-height/2.2f, 0);
		bupper.transform.position = new Vector3 (0,height/2.2f, 0);
		bcenter.transform.position = new Vector3 (0,0, 0);
		bll.transform.position = new Vector3 (-width/2.2f,-height/2.2f, 0);
		blr.transform.position = new Vector3 (width/2.2f,-height/2.2f, 0);
		bul.transform.position = new Vector3 (-width/2.2f,height/2.2f, 0);
		bur.transform.position = new Vector3 (width/2.2f,height/2.2f, 0);
		
		bcenter.transform.localScale= new Vector3 (width*4.55f,height*4f, 0);
		bbottom.transform.localScale= new Vector3 (width*4.55f,-1f, 0);
		bupper.transform.localScale= new Vector3 (width*4.55f,1f, 0);
		bleft.transform.localScale= new Vector3 (height*4.1f,1f, 0);
		bright.transform.localScale= new Vector3 (height*4.1f ,-1f, 0);
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
