using UnityEngine;
using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using RoundedDefence.Components.Levels;
using RoundedDefence;

public class LvlSelect : MonoBehaviour {
    public string classlevel;
    public Int16 world;
    public Int16 levelnum;
	private bool enabledd=false;
	public String Image1;
	public String Image2;
	public float radius;
	public float angle;
	public float speed;
	public string centroid;
	public bool rotate;
    GameObject[] stars;
	GameObject sun;
	Vector3 center;
	public XElement level;
	// Use this for initialization
	void Start () {
        stars = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            stars[i] = new GameObject("Star" + classlevel + levelnum + "-" + i);
            stars[i].AddComponent<SpriteRenderer>();
        }
        sun = GameObject.Find(centroid);
        level = Lib.getLevel(classlevel, world, levelnum);
        Int16 requiredStars = Int16.Parse(level.Attribute(XName.Get("required-stars")).Value);
        enabledd = PlayerPrefs.GetInt("WorldUnlocked", 1) >= world
            && PlayerPrefs.GetInt("LvlUnlocked", 1) >= levelnum
            && PlayerPrefs.GetInt("TotalStars", 0) >= requiredStars;
		setTexture ();
	}
	void star(Sprite sprite,int lvl){
        GameObject gameObject = stars[lvl];
		SpriteRenderer sprRenderer= (SpriteRenderer)gameObject.renderer;
		sprRenderer.sprite=sprite;
		sprRenderer.sortingLayerName = "Ships";
		sprRenderer.sortingOrder = lvl;
		gameObject.transform.position = transform.position;
		gameObject.transform.rotation = transform.rotation;
        gameObject.transform.localScale = new Vector3(transform.localScale.x*3, transform.localScale.y*3, transform.localScale.z*3);
        gameObject.transform.Translate(Mathf.Cos(Mathf.PI / 180 * (225 + (lvl * 30))) * this.transform.localScale.magnitude*1.1f,
                                        Mathf.Sin(Mathf.PI / 180 * (225 + (lvl * 30))) * this.transform.localScale.magnitude*1.1f, 0);
	}
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 4; i++)
        {
            SpriteRenderer sprRenderer = (SpriteRenderer)stars[i].renderer;
            sprRenderer.sprite = null;
        }
        if (sun != null) {
			center = sun.transform.position;
			angle += speed;
			angle = ((2 * Mathf.PI) + angle) % (Mathf.PI * 2);
			transform.position = new Vector3 (center.x + (radius * Mathf.Cos (angle)), center.y + (radius * Mathf.Sin (angle)), 0f);
			if (rotate)
                transform.Rotate(Vector3.forward, speed * 180 / Mathf.PI);
            Int16 requiredStars = Int16.Parse(level.Attribute(XName.Get("required-stars")).Value);
            enabledd = PlayerPrefs.GetInt("WorldUnlocked", 1) >= world
                && PlayerPrefs.GetInt("LvlUnlocked", 1) >= levelnum
                && PlayerPrefs.GetInt("TotalStars", 0) >= requiredStars;
            if (enabledd && IslandSelected.centroid == name)
                setStars();

		}
	}
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0)) {
            		Lib.setCurrentLevel(classlevel, world, levelnum);
			IslandSelected.centroid=gameObject.name;
			GameObject gm=GameObject.Find("_GM");
			gm.audio.clip=Lib.clickClip;
			if(Lib.sound)
				gm.audio.Play ();
		}
	}
	void setTexture(){
		SpriteRenderer sprRenderer= (SpriteRenderer)renderer;
		if (enabledd) {
            sprRenderer.sprite = Resources.Load<Sprite>(Image1);
		} else {
            sprRenderer.sprite = Resources.Load<Sprite>(Image2);
		}
	}
	void setStars(){
        int allStar;
        int score;
        if (classlevel == "normal")
        {
            allStar = PlayerPrefs.GetInt(String.Format("AllStarN.{0}.{1}",world,levelnum), 0);
            score = PlayerPrefs.GetInt(String.Format("ScoreN.{0}.{1}", world, levelnum), 0);
        }
        else
        {
            allStar = PlayerPrefs.GetInt(String.Format("AllStarS.{0}.{1}", world, levelnum), 0);
            score = PlayerPrefs.GetInt(String.Format("ScoreS.{0}.{1}", world, levelnum), 0);
        }
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
