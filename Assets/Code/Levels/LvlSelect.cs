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
	//TODO: Fix lvlNumb.
	int lvlNumb = 0;
	public XElement level;
	// Use this for initialization
	void Start () {
		level = Lib.currentLevel;
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
		Vector3 move = new Vector3 (Mathf.Cos(Mathf.PI/180*(225+(lvl*30)))*0.6f, 
		                            Mathf.Sin(Mathf.PI/180*(225+(lvl*30)))*0.6f, 0);
		gameObject.transform.Translate (move, Space.World); 
	}
	// Update is called once per frame
	void Update () {
	
	} 
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0)) {
			LevelSelect.lvlSelected=lvlNumb;
			//LevelSelect.level=level;
			GameObject gm=GameObject.Find("_GM");
			gm.audio.clip=Lib.clickClip;
			if(Lib.sound)
			gm.audio.Play ();
		}
	}
	void setTexture(){
		SpriteRenderer sprRenderer= (SpriteRenderer)renderer;
		int minStars = Int32.Parse(Lib.currentLevel.Attribute(XName.Get("required-stars")).Value);
		enabledd=PlayerPrefs.GetInt("LvlUnlocked",1)>=lvlNumb&&PlayerPrefs.GetInt("TotalStars",0)>=minStars;
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
