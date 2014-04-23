using UnityEngine;
using System;
using System.Collections;
using System.Xml.Linq;
using RoundedDefence;

public class LoadLevelSelectGUI : MonoBehaviour {
	public Sprite lockedLevelNormal;
	public Sprite unlockedLevelNormal;
	public Vector3 scaleLevelNormal;
	public Sprite lockedLevelSpecial;
	public Sprite unlockedLevelSpecial;
	public Vector3 scaleLevelSpecial;
	// Use this for initialization
	void Start () {
		int i = 1;
		foreach(XElement level in Lib.data.Element(XName.Get("levels")).Elements(XName.Get("level")))
		{
			Debug.Log (level);
			String id = level.Attribute(XName.Get("id")).Value;
			GameObject gameObject = new GameObject("Level"+id);
			gameObject.AddComponent<SpriteRenderer>();
			CircleCollider2D col2d=gameObject.AddComponent<CircleCollider2D>();
			LvlSelect behavior = gameObject.AddComponent<LvlSelect>();
			behavior.LevelId=id;
			if(id.Substring(0,1) == "S"){
				col2d.radius = 1.5f;
				behavior.radius = 0.5f;
				behavior.speed = 0.01f;
				behavior.Image1 = unlockedLevelSpecial;
				behavior.Image2 = lockedLevelSpecial;
				behavior.centroid = "LevelN"+id.Substring(1);
				gameObject.transform.localScale = scaleLevelSpecial;
			}else{
				col2d.radius = 2;	
				behavior.radius = i;
				behavior.speed = 0.01f/i;			
				behavior.Image1 = unlockedLevelNormal;
				behavior.Image2 = lockedLevelNormal;
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
