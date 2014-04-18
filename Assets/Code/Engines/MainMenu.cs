using UnityEngine;
using System.Collections;
using RoundedDefence;

public class MainMenu : MonoBehaviour {

	GameObject campaign;
	GameObject options;
	GameObject credits;
	GameObject reset;
	GameObject back;
	
	GameObject creditos;
	GameObject title;
	GameObject portadaBL;
	GameObject portadaTL;
	GameObject portadaBR;
	GameObject portadaTR;
	
	GameObject fade;
	GameObject musica;
	GameObject sound;
	
	Camera cam ;
	float height;
	float width ;
	float div ;
	float fader=0;
	float fading=0;
	byte menu=0;
	void Start () {
		Lib.mute ();
		campaign = GameObject.Find ("campaign");
		options = GameObject.Find ("options");
		credits = GameObject.Find ("credits");
		reset = GameObject.Find ("resetall");
		back = GameObject.Find ("back");
		
		creditos = GameObject.Find ("creditos");
		title = GameObject.Find ("title");
		portadaBL = GameObject.Find ("portadaBL");
		portadaTL = GameObject.Find ("portadaTL");
		portadaBR = GameObject.Find ("portadaBR");
		portadaTR = GameObject.Find ("portadaTR");
		
		fade = GameObject.Find ("fade");
		musica = GameObject.Find ("musica");
		sound = GameObject.Find ("sound");
		
		cam=Camera.main;
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		div = height /40;
		Update ();
		fading = -.04f;
		fader = 1f;
	}
	void Update(){
		if (fading == 0) {
			height = 2f * cam.orthographicSize;
			width = height * cam.aspect;
			div = height / 40;
			switch (menu) {
			case 0:
				mainMenu ();
				break;
			case 1:
				optionsMenu ();
				break;
			case 2:
				creditsMenu ();
				break;
			}

			portadaTL.transform.position = new Vector3 (-width / 5f, height / 5f, 0);
			portadaBL.transform.position = new Vector3 (-width / 5f, -height / 5f, 0);
			portadaTR.transform.position = new Vector3 (width / 5, height / 5f, 0);
			portadaBR.transform.position = new Vector3 (width / 5, -height / 5f, 0);

			
			musica.transform.position=new Vector3(width/5f -.08f ,height/5f,10f);
			sound.transform.position=new Vector3(width/5f - .6f,height/5f -.05f,10f);
			musica.transform.Translate(cam.transform.position);
			sound.transform.Translate(cam.transform.position);
		} else {
			faderr ();
		}
	}
	void mainMenu(){
		
		//GUI.Label (new Rect (Screen.width / 2 - 80, 50, 160, 50), "Rounded Defence");
		if (campaign.transform.position.z == 1) {
			fader=0f;
			fading=.04f;
		}
		if(fader+.04f>1)
			Application.LoadLevel ("levelSelect");
		if(options.transform.position.z==1)
			menu=1;
		if(credits.transform.position.z==1)
			menu=2;
		Vector3 move = new Vector3 (0,-0f*div, 0);
		campaign.transform.position = move;
		move = new Vector3 (0,-3f * div, 0);
		options.transform.position = move;
		move = new Vector3 (0,-6f * div, 0);
		credits.transform.position = move;
		move = new Vector3 (0,4f * div, 0);
		title.transform.position = move;
		move = new Vector3 (7,0, 0);
		reset.transform.position = move;
		creditos.transform.position = move;
		back.transform.position = move;
	}
	void optionsMenu(){
		if(reset.transform.position.z==1)
			PlayerPrefs.DeleteAll ();
		if(back.transform.position.z==1)
			menu=0;
		
		Vector3 move = new Vector3 (0,-3f * div, 0);
		reset.transform.position = move;
		move = new Vector3 (0,-6f * div, 0);
		back.transform.position = move;
		move = new Vector3 (7,0, 0);
		campaign.transform.position = move;
		credits.transform.position = move;
		title.transform.position = move;
		options.transform.position = move;
		
		//Lib.muteMusic(true);
		//Lib.muteSound();
		
	}
	void creditsMenu(){
		if(back.transform.position.z==1)
			menu=0;
		
		Vector3 move = new Vector3 (0,.6f, 0);
		creditos.transform.position = move;
		move = new Vector3 (0,-6f * div, 0);
		back.transform.position = move;
		move = new Vector3 (7,0, 0);
		campaign.transform.position = move;
		title.transform.position = move;
		options.transform.position = move;
		credits.transform.position = move;;
		reset.transform.position = move;
	}
	void faderr(){
		fader += fading ;
		if (fader > 0f && fader < 1f) {
			Color c = fade.renderer.material.color;
			c.a = fader;
			fade.renderer.material.color = c;
			cam.audio.volume=1f-fader;
		} else {
			fading=0f;
			
		}
	}
}
