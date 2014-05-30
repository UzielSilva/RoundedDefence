using UnityEngine;
using System.Collections;
using RoundedDefence;

public class animation : MonoBehaviour {
	int animate=0;
	int del=0;
	public int delay = 0;
	public string resource="";
	Sprite[] img;
	// Use this for initialization
	void Start () {
		img=Resources.LoadAll<Sprite>(resource) ;
	}
	
	// Update is called once per frame
	void Update () {
		if (del-- < 0) {
			if(animate<img.Length)
			Lib.setSprite (this.gameObject, img[animate]);
			del=delay;
			if(img.Length!=0)
			animate=(animate+1) %img.Length; 
		}
	}
}
