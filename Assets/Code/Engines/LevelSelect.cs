using UnityEngine;
using System.Collections;
using RoundedDefence;
using RoundedDefence.Components;

public class LevelSelect : MonoBehaviour {
	public static int lvlSelected=0;
	public static Level level;
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
		if (lvlSelected != 0 && level!=null) {
			bool enabledd=PlayerPrefs.GetInt("LvlUnlocked",1)>=level.getLvlNumb();
			if(enabledd){
				enabledd=PlayerPrefs.GetInt("TotalStars",0)>=level.getMinStars();
				if(enabledd){
					drawStats ();
				}else{
					Lib.setString(txtmsg,"YOU NEED "+level.getMinStars()+" STARS TO PLAY");
					}
			}else{
				Lib.setString(txtmsg,"PASS LEVEL "+(lvlSelected-1)+" TO PLAY");
			}
		} else {
			Lib.setString(txtmsg,"SELECT A LEVEL");
		}
	}
	void drawStats(){
		Lib.setString(txtmsg, "SCORE : " + level.getScore ());
		if(level.getScore()<level.getOneStar()){
			Lib.setSprite(objstarScore,"Sprites/Misc/star1");
			Lib.setString(txtscore,"at "+level.getOneStar());
		}else if(level.getScore()<level.getTwoStar()){
			Lib.setSprite(objstarScore,"Sprites/Misc/star2");
			Lib.setString(txtscore,"at "+level.getTwoStar());
		}else if(level.getScore()<level.getThreeStar()){
			Lib.setSprite(objstarScore,"Sprites/Misc/star3");
			Lib.setString(txtscore,"at "+level.getThreeStar());
		}else{
		}
		Vector3 move=new Vector3(0,0,10);
		txtscore.transform.position=move;
		btnplay.transform.position=move;
		objstarScore.transform.position=move;
	}


}
