using UnityEngine;
using System.Collections;
using RoundedDefence;

public class MainMenu : MonoBehaviour {
	//txt
	//btn
	GameObject btncampaign;
	GameObject btnoptions;
	GameObject btncredits;
	GameObject btnreset;
	GameObject btnback;
	GameObject btnmusica;
	GameObject btnsound;
	//obj
	GameObject creditos;
	GameObject title;
	GameObject portadaBL;
	GameObject portadaTL;
	GameObject portadaBR;
	GameObject portadaTR;

    GameObject fade;
	
	byte menu=0;
	void Start () {
		Lib.mute ();
		btncampaign = GameObject.Find ("btncampaign");
		btnoptions = GameObject.Find ("btnoptions");
		btncredits = GameObject.Find ("btncredits");
		btnreset = GameObject.Find ("btnresetall");
		btnback = GameObject.Find ("btnback");
		btnmusica = GameObject.Find ("btnmusica");
		btnsound = GameObject.Find ("btnsound");
		
		creditos = GameObject.Find ("creditos");
		title = GameObject.Find ("title");
		portadaBL = GameObject.Find ("portadaBL");
		portadaTL = GameObject.Find ("portadaTL");
		portadaBR = GameObject.Find ("portadaBR");
		portadaTR = GameObject.Find ("portadaTR");
		IslandSelected.centroid = "";
		Lib.newFade ();
        fade = GameObject.Find("fade");
		Lib.unfades ();
	}
	void Update(){
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

		portadaTL.transform.position = new Vector3 (-Lib.width() / 2f, Lib.height() / 2f, 0);
		portadaBL.transform.position = new Vector3 (-Lib.width() / 2f, -Lib.height() / 2f, 0);
		portadaTR.transform.position = new Vector3 (Lib.width() / 2f, Lib.height() / 2f, 0);
		portadaBR.transform.position = new Vector3 (Lib.width() / 2f, -Lib.height() / 2f, 0);

		btnmusica.transform.position = new Vector3(Lib.width() / 2f- .6f, Lib.height() / 2f - .2f, 10f);
		btnsound.transform.position = new Vector3(Lib.width() / 2f - .2f, Lib.height() / 2f - .2f, 10f);


        fade.transform.localScale = new Vector3(Camera.main.aspect, 1, 1);

		if (!Lib.isFading()) {
			Lib.faderr ();
		}
	}
	void mainMenu(){
		if (btncampaign.transform.position.z == 1) {
			Lib.fades();
		}
		if(Lib.isFadeReady())
			Application.LoadLevel ("levelSelect");
		if(btnoptions.transform.position.z==1)
			menu=1;
		if(btncredits.transform.position.z==1)
			menu=2;
		btncampaign.transform.position = new Vector3 (0,-0f*Lib.height()/20f, 0);
		btnoptions.transform.position = new Vector3 (0,-3f*Lib.height() /20f, 0);
		btncredits.transform.position = new Vector3 (0,-6f*Lib.height() /20f, 0);
		title.transform.position = new Vector3 (0,4f*Lib.height() /20f, 0);

		Vector3 move = new Vector3 (0,7, 0);
		btnreset.transform.position = move;
		btnback.transform.position = move;
		creditos.transform.position = move;
	}
	void optionsMenu(){
		if(btnreset.transform.position.z==1)
			PlayerPrefs.DeleteAll ();
		if(btnback.transform.position.z==1)
			menu=0;

		btnreset.transform.position = new Vector3 (0,-3f *Lib.height()/20f, 0);
		btnback.transform.position = new Vector3 (0,-6f *Lib.height()/20f, 0);

		Vector3 move = new Vector3 (0,7, 0);
		btncampaign.transform.position = move;
		btncredits.transform.position = move;
		btnoptions.transform.position = move;
		title.transform.position = move;
	}
	void creditsMenu(){
		if(btnback.transform.position.z==1)
			menu=0;
		
		btnback.transform.position = new Vector3 (0,-6f*Lib.height() /20f, 0);
		creditos.transform.position = new Vector3 (0,.6f, 0);

		Vector3 move = new Vector3 (0,7, 0);
		btncampaign.transform.position = move;
		btnoptions.transform.position = move;
		btncredits.transform.position = move;
		btnreset.transform.position = move;
		title.transform.position = move;
	}
}
