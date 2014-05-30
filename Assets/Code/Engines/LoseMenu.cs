using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using RoundedDefence.Components.Fishes;
using RoundedDefence;

public class LoseMenu : MonoBehaviour {
	//txt
	//btn
	GameObject btnback;
	GameObject btnnext;
	GameObject btnretry;
	//obj
	
	GameObject fade;
	
	int titletxt=7;
	int scoretxt=5;
	
	int action=0;
	// Use this for initialization
	void Start () {
		Lib.mute ();
		//btn
		btnretry = GameObject.Find ("btnretry");
		btnback = GameObject.Find ("btnback");
		btnnext = GameObject.Find ("btnnext");
		//obj
		
		
		Lib.newFade ();
		fade = GameObject.Find("fade");
		Lib.unfades();
	}
	
	void buttonsActions(){
		if (btnback.transform.position.z == 1) {
			action=0;
			Lib.fades ();
		}
		if (btnretry.transform.position.z == 1)
		{
			action = 1;
			Lib.fades();
		}
		if (btnnext.transform.position.z == 1)
		{
			action = 2;
			Lib.fades();
		}
		if(Lib.isFadeReady()){
			if(action==0)
				Application.LoadLevel ("levelSelect");
			if(action==1)
				Application.LoadLevel("genericLevel");
			if(action==2){
				Lib.setCurrentLevel("normal", Lib.currentworld, Lib.currentlvl+1);
				Application.LoadLevel("genericLevel");
			}
		}
	}
	// Update is called once per frame
	void Update () {
		buttonsActions ();
		//txt
		//btn
		btnback.transform.position=new Vector3(-Lib.width()/2f,-Lib.height()/2f,0f);
		btnretry.transform.position=new Vector3(0 ,-Lib.height()/2f,0f);
		btnnext.transform.position=new Vector3(Lib.width()/2f,-Lib.height()/2f ,0f);
		
		//obj
		
		fade.transform.localScale = new Vector3(Camera.main.aspect, 1, 1);
		
		if (!Lib.isFading()) {
			Lib.faderr ();
		}
	}
}
