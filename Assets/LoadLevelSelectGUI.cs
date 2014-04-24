using UnityEngine;
using System;
using System.Collections;
using System.Xml.Linq;
using RoundedDefence;

public class LoadLevelSelectGUI : MonoBehaviour {
	public float radiusColliderNormal;
	public Vector3 scaleLevelNormal;
	public float radiusColliderSpecial;
	public Vector3 scaleLevelSpecial;
	// Use this for initialization
	void Start () {
		int i = 1;
		foreach(XElement level in Lib.data.Element(XName.Get("levels")).Elements(XName.Get("level")))
		{
			Debug.Log (level);
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
            behavior.LevelId = id;
            behavior.Image1 = Resources.Load("Sprites/Islands/" + lockedSprite) as Sprite;
            var q = Resources.Load("Sprites/Islands/" + lockedSprite) as Texture2D;
            behavior.Image2 = Resources.Load("Sprites/Islands/" + unlockedSprite) as Sprite;
            Debug.Log(behavior.Image1);
            Debug.Log(behavior.Image2);
			if(classlevel == "special"){
				col2d.radius = radiusColliderSpecial;
				behavior.radius = 0.5f;
                behavior.speed = 0.01f;
				behavior.centroid = "Level"+id;
				gameObject.transform.localScale = scaleLevelSpecial;
			}else{
				col2d.radius = radiusColliderNormal;	
				behavior.radius = i;
				behavior.speed = 0.01f/i;
				behavior.centroid="sun";
				gameObject.transform.localScale = scaleLevelNormal;
			}
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
