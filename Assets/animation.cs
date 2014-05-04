using UnityEngine;
using System.Collections;
using RoundedDefence;

public class animation : MonoBehaviour {
	int animate=0;
	int del=0;
	public int delay = 0;
	public int total=0;
	public string resource="";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (del-- < 0) {
						Lib.setSprite (this.gameObject, resource + (animate+1));
			del=delay;
			animate=(animate+1) %total; 
		}
	}
}
