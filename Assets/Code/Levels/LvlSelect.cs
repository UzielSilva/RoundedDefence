using UnityEngine;
using System;
using System.Xml.Linq;
using System.Collections;
using RoundedDefence.Components.Levels;
using RoundedDefence;

public class LvlSelect : MonoBehaviour {
	public string LevelId="N.1.1";
	private bool enabledd=false;
	public Sprite Image1;
	public Sprite Image2;
	public float radius;
	public float angle;
	public float speed;
	public string centroid;
	public bool rotate;
	GameObject sun;
	Vector3 center;
	//TODO: Fix lvlNumb.
	int lvlNumb = 0;
	public XElement level;
	// Use this for initialization
	void Start () {
		level = Lib.currentLevel;
		sun = GameObject.Find (centroid);
		setTexture ();
		if(enabledd)
		setStars ();
	}
	void star(Sprite sprite,int lvl){
		GameObject gameObject = new GameObject("Star"+lvlNumb+"-"+lvl);
		gameObject.AddComponent<SpriteRenderer>();
		SpriteRenderer sprRenderer= (SpriteRenderer)gameObject.renderer; 
		sprRenderer.sprite=sprite;
		sprRenderer.sortingLayerName = "Ships";
		sprRenderer.sortingOrder = lvl;
		gameObject.transform.position = transform.position;
		gameObject.transform.rotation = transform.rotation;
		gameObject.transform.localScale = new Vector3 (.8f, .8f, .8f);
		gameObject.transform.Translate (Mathf.Cos(Mathf.PI/180*(225+(lvl*30)))*0.6f, 
		                                Mathf.Sin(Mathf.PI/180*(225+(lvl*30)))*0.6f, 0); 
	}
	// Update is called once per frame
	void Update () {
		if (sun != null) {
				center = sun.transform.position;
				angle += speed;
				angle = ((2 * Mathf.PI) + angle) % (Mathf.PI * 2);
				transform.position = new Vector3 (center.x + (radius * Mathf.Cos (angle)), center.y + (radius * Mathf.Sin (angle)), 0f);
				if (rotate)
						transform.Rotate (Vector3.forward, speed * 180 / Mathf.PI);
		}
	} 
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0)) {
			LevelSelect.lvlSelected=lvlNumb;
			//LevelSelect.level=level;
			IslandSelected.centroid=gameObject.name;
			GameObject gm=GameObject.Find("_GM");
			gm.audio.clip=Lib.clickClip;
			if(Lib.sound)
			gm.audio.Play ();
		}
	}
	void setTexture(){
		SpriteRenderer sprRenderer= (SpriteRenderer)renderer;
//		enabledd=PlayerPrefs.GetInt("LvlUnlocked",1)>=lvlNumb&&PlayerPrefs.GetInt("TotalStars",0)>=level.getMinStars();
		if (enabledd) {
			sprRenderer.sprite = Image1;	
		} else {
			sprRenderer.sprite = Image2;
		}
	}
	void setStars(){
		//TODO: Assign score storage.
		//TODO: Assign all star.
		int allStar = 0;
		int score = 0;
		int oneStar = Int32.Parse(level.Element(XName.Get("scores")).Attribute(XName.Get("one-star")).Value);
		int twoStar = Int32.Parse(level.Element(XName.Get("scores")).Attribute(XName.Get("two-star")).Value);
		int threeStar = Int32.Parse(level.Element(XName.Get("scores")).Attribute(XName.Get("three-star")).Value);
		if(score>=oneStar)
			star (Resources.Load<Sprite>("Sprites/Misc/star1"),0);
		else
			star (Resources.Load<Sprite>("Sprites/Misc/nostar"),0);
		if(score>=twoStar)
			star (Resources.Load<Sprite>("Sprites/Misc/star2"),1);
		else
			star (Resources.Load<Sprite>("Sprites/Misc/nostar"),1);
		if(score>=threeStar)
			star (Resources.Load<Sprite>("Sprites/Misc/star3"),2);
		else
			star (Resources.Load<Sprite>("Sprites/Misc/nostar"),2);
		if(0!=allStar)
			star (Resources.Load<Sprite>("Sprites/Misc/star4"),3);
		else
			star (Resources.Load<Sprite>("Sprites/Misc/nostar"),3);

		}
}
