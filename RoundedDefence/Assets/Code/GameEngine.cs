using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour {
	//public AudioClip shoot;
	//public AudioSource backmusic;
	byte menu=0;
	// Use this for initialization
	void Start () {
		//backmusic = (AudioSource)gameObject.AddComponent ("AudioSource");

		//shoot=(AudioClip)Resources.Load("Origin");
		//backmusic.clip = shoot;
		//backmusic.loop = true;
	}
	void OnGUI () {
		switch (menu) {
		case 0: mainMenu ();break;
		case 1: optionsMenu ();break;
		case 2: creditsMenu ();break;
		}
	}
	// Update is called once per frame
	void Update () {
		//backmusic.Play ();
	}
	void mainMenu(){
		
		GUI.Label (new Rect (Screen.width / 2 - 80, 50, 160, 50), "Rounded Defence");
		if(GUI.Button(new Rect(Screen.width/2-80,Screen.height/2-60,160,50), "Play")) {
			//
		}
		
		if(GUI.Button(new Rect(Screen.width/2-80,Screen.height/2,160,50), "Options")) {
			menu=1;
		}
		if(GUI.Button(new Rect(Screen.width/2-80,Screen.height/2+60,160,50), "Credits")) {
			menu=2;
		}
	}
	void optionsMenu(){

		if(GUI.Button(new Rect(Screen.width/2-80,Screen.height/2-50,160,50), "Sound")) {
			//Application.LoadLevel(1);
		}
		
		if(GUI.Button(new Rect(Screen.width/2-80,Screen.height/2+50,160,50), "Back")) {
			menu=0;
		}
	}
	void creditsMenu(){

		GUI.Label (new Rect (Screen.width / 2 - 100, 50, 160, 50), "Programed By:");
		
		GUI.Label (new Rect (Screen.width / 2 - 80, 65, 160, 50), "Juan German González");
		GUI.Label (new Rect (Screen.width / 2 - 80, 80, 160, 50), "Uziel Alejandro Silva");

		GUI.Label (new Rect (Screen.width / 2 - 100, 110, 160, 50), "Graphics By:");
		GUI.Label (new Rect (Screen.width / 2 - 80, 125, 160, 50), "Tatiana Hernández");

		if(GUI.Button(new Rect(Screen.width/2-80,Screen.height/2+60,160,50), "Back")) {
			menu=0;
		}
	}
}
