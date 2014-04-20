using UnityEngine;
using System;
using System.Collections;
using RoundedDefence;
using System.Xml.Linq;

public class LevelSelect : MonoBehaviour {
	public static int lvlSelected=0;
	public XElement level {get;set;}
	//text
	GameObject txtmsg;
	GameObject txtscore;
	GameObject txtstar;
	//butons
	GameObject btnmusica;
	GameObject btnsound;
	GameObject btnback;
	GameObject btnplay;
	//ohters
	GameObject objstarStar;
	GameObject objstarScore;
	GameObject objhudbar;

	int action=0;
	// Use this for initialization
	void Start () {
		Lib.mute ();
		//text
		txtstar =Lib.newText("txtstars");
		txtmsg = Lib.newText("txtmsg");
		txtscore = Lib.newText("txtscore");
		//buttons
		btnmusica = GameObject.Find ("btnmusica");
		btnsound = GameObject.Find ("btnsound");
		btnplay = GameObject.Find ("btnplay");
		btnback = GameObject.Find ("btnback");
		//others
		objhudbar = GameObject.Find ("hudbar");
		objstarStar = GameObject.Find ("starStars");
		objstarScore = GameObject.Find ("starScore");
		Lib.newFade();
		Lib.setString (txtstar, PlayerPrefs.GetInt ("TotalStars", 0) + "");
		lvlSelected = 0;
		Lib.unfades ();
	}
	void buttonsActions(){
		if (btnback.transform.position.z == 1) {
			action=0;
			Lib.fades();
		}
		if (btnplay.transform.position.z == 1) {
			action=1;
			Lib.fades();
		}
		}
	void buttonsFade(){
		if(Lib.isFadeReady()){
			if(action==0)
				Application.LoadLevel ("mainMenu");
			if(action==1)
				Application.LoadLevel ("towerSelect");
		}
	}
	void Update(){
			buttonsActions ();
			buttonsFade ();
			Vector3 move=new Vector3(0,0,0);
			btnplay.transform.position=move;
			txtscore.transform.position=move;
			objstarScore.transform.position=move;
			
			drawDescription ();
			//txt
			txtstar.transform.position=new Vector3(-Lib.width()/2f +.4f,Lib.height()/2f-.04f,10f);
			txtmsg.transform.position=new Vector3(Lib.getStringLength(txtmsg)*-.06f,-Lib.height()/2f+.7f,10f);
			txtscore.transform.Translate(new Vector3((Lib.getStringLength(txtscore)*-.06f)+.2f,-Lib.height()/2f+.35f,0f));
			//btn
			btnmusica.transform.position=new Vector3(Lib.width()/2f ,Lib.height()/2f,10f);
			btnsound.transform.position=new Vector3(Lib.width()/2f - .5f,Lib.height()/2f -.05f,10f);
			btnplay.transform.Translate(new Vector3(Lib.width()/2f -.7f,-Lib.height()/2f+.35f,0f));
			btnback.transform.position=new Vector3(-Lib.width()/2f +.7f,-Lib.height()/2f+.35f,10f);
			//obj
			objstarStar.transform.position=new Vector3(-Lib.width()/2f+.2f,Lib.height()/2f-.17f,10f);
			objhudbar.transform.position=new Vector3(0,-Lib.height()/2f ,10f);
			objstarScore.transform.Translate(new Vector3((Lib.getStringLength(txtscore)*-.06f),-Lib.height()/2f+.20f,0f));

			//txt
			Lib.followCamera(txtstar);
			Lib.followCamera(txtscore);
			Lib.followCamera(txtmsg);
			//btn
			Lib.followCamera(btnmusica);
			Lib.followCamera(btnsound);
			Lib.followCamera(btnback);
			Lib.followCamera(btnplay);
			//obj
			Lib.followCamera(objstarScore);
			Lib.followCamera(objstarStar);
			Lib.followCamera(objhudbar);
		if (!Lib.isFading()) {
			Lib.faderr ();
		}
	}
	void drawDescription(){
		int requiredStars = Int32.Parse(level.Attribute(XName.Get ("required-stars")).Value);
		if (lvlSelected != 0 && level!=null) {
			//TODO: Implement field for levelNum.
			int levelNum = 0;
			bool enabledd=PlayerPrefs.GetInt("LvlUnlocked",1)>=levelNum;
			if(enabledd){
				enabledd=PlayerPrefs.GetInt("TotalStars",0)>= requiredStars;
				if(enabledd){
					drawStats ();
				}else{
					Lib.setString(txtmsg,"YOU NEED "+requiredStars+" STARS TO PLAY");
					}
			}else{
				Lib.setString(txtmsg,"PASS LEVEL "+(lvlSelected-1)+" TO PLAY");
			}
		} else {
			Lib.setString(txtmsg,"SELECT A LEVEL");
		}
	}
	void drawStats(){
		//TODO: Assign score storage.
		int score = 0;
		int oneStar = Int32.Parse(level.Element(XName.Get("scores")).Attribute("one-star").Value);
		int twoStar = Int32.Parse(level.Element(XName.Get("scores")).Attribute("two-star").Value);
		int threeStar = Int32.Parse(level.Element(XName.Get("scores")).Attribute("three-star").Value);
		Lib.setString(txtmsg, "SCORE : " );
		if(score<oneStar){
			Lib.setSprite(objstarScore,"Sprites/Misc/star1");
			Lib.setString(txtscore,"at "+oneStar);
		}else if(score<twoStar){
			Lib.setSprite(objstarScore,"Sprites/Misc/star2");
			Lib.setString(txtscore,"at "+twoStar);
		}else if(score<threeStar){
			Lib.setSprite(objstarScore,"Sprites/Misc/star3");
			Lib.setString(txtscore,"at "+threeStar);
		}else{
		}
		Vector3 move=new Vector3(0,0,10);
		txtscore.transform.position=move;
		btnplay.transform.position=move;
		objstarScore.transform.position=move;
	}


}
