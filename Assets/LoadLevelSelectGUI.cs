using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using RoundedDefence;

public class LoadLevelSelectGUI : MonoBehaviour {

	public float radiusCollider;
	public Vector3 scaleLevelNormal;
	public Vector3 scaleLevelSpecial;
    public String selector;
    private IslandSelected behaviorSelector1;
    private IslandSelected behaviorSelector2;

	// Use this for initialization
	void Start () {
		int i = 1;
        var levels = from level in Lib.data.Element(XName.Get("levels")).Elements(XName.Get("level"))
                     orderby Int16.Parse(level.Attribute(XName.Get("levelnum")).Value) ascending
                     orderby Int16.Parse(level.Attribute(XName.Get("world")).Value) ascending
                     select level;
        
		foreach(XElement level in levels)
		{
            String classlevel = level.Attribute(XName.Get("class")).Value;
            Int16 world = Int16.Parse(level.Attribute(XName.Get("world")).Value);
            Int16 levelnum = Int16.Parse(level.Attribute(XName.Get("levelnum")).Value);
            String unlockedSprite = level.Attribute(XName.Get("unlocked-sprite")).Value;
            String lockedSprite = level.Attribute(XName.Get("locked-sprite")).Value;
            String id;
            if (classlevel == "special")
                id = String.Format("S.{0}.{1}", world, levelnum);
            else
                id = String.Format("N.{0}.{1}", world, levelnum);
			GameObject gameObject = new GameObject("Level"+id);
			gameObject.AddComponent<SpriteRenderer>();
			CircleCollider2D col2d=gameObject.AddComponent<CircleCollider2D>();
			LvlSelect behavior = gameObject.AddComponent<LvlSelect>();
            behavior.classlevel = classlevel;
            behavior.world = world;
            behavior.levelnum = levelnum;
            behavior.Image1 = "Sprites/Islands/" + unlockedSprite;
            behavior.Image2 = "Sprites/Islands/" + lockedSprite;
            col2d.radius = radiusCollider;
			if(classlevel == "special"){
				behavior.radius = 0.5f;
                behavior.speed = 0.01f;
				behavior.centroid = "LevelN"+id.Substring(1);
				gameObject.transform.localScale = scaleLevelSpecial;
			}else{	
				behavior.radius = i*1.2f;
				behavior.speed = 0.01f/i;
				behavior.centroid="sun";
                gameObject.transform.localScale = scaleLevelNormal;
                i++;
			}
		}
        GameObject selector1 = new GameObject("Selector1");
        selector1.AddComponent<SpriteRenderer>();
        Lib.setSprite(selector1, selector);
        selector1.transform.localScale = scaleLevelNormal;
        behaviorSelector1 = selector1.AddComponent<IslandSelected>();
        behaviorSelector1.radius = 1;
        behaviorSelector1.speed = 0.02f;
        GameObject selector2 = new GameObject("Selector2");
        selector2.AddComponent<SpriteRenderer>();
        Lib.setSprite(selector2, selector);
        selector2.transform.localScale = scaleLevelNormal;
        behaviorSelector2 = selector2.AddComponent<IslandSelected>();
        behaviorSelector2.radius = 1;
        behaviorSelector2.speed = -0.02f;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject target = GameObject.Find(IslandSelected.centroid);
        if(target != null)
            if (target.name.Substring(0, 6) == ("LevelS"))
            {
                GameObject selector1 = GameObject.Find("Selector1");
                GameObject selector2 = GameObject.Find("Selector2");
                selector1.transform.localScale = scaleLevelSpecial;
                selector2.transform.localScale = scaleLevelSpecial;
                behaviorSelector1.radius = radiusCollider * scaleLevelSpecial.magnitude;
                behaviorSelector2.radius = (radiusCollider - 0.5f) * scaleLevelSpecial.magnitude;
            }
            else
            {
                GameObject selector1 = GameObject.Find("Selector1");
                GameObject selector2 = GameObject.Find("Selector2");
                selector1.transform.localScale = scaleLevelNormal;
                selector2.transform.localScale = scaleLevelNormal;
                behaviorSelector1.radius = radiusCollider * scaleLevelNormal.magnitude;
                behaviorSelector2.radius = (radiusCollider - 0.5f) * scaleLevelNormal.magnitude;
            }
	}
}
