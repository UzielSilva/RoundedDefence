using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using RoundedDefence.Components.Fishes;
using RoundedDefence;

public class TowerSelect : MonoBehaviour {
	//txt
	GameObject txtstar;
	GameObject txtpoint;
	GameObject txttitle;
	GameObject txtsubtitle;
	GameObject txtbasic;
	GameObject txtimproved;
	GameObject txtadvanced;
	GameObject txttipotorre;
	//btn
	GameObject btnback;
	GameObject btnplay;
	GameObject[,] tower;
	//obj
	GameObject bbottom;
	GameObject bleft;
	GameObject bright;
	GameObject bupper;
	GameObject bcenter;
	GameObject bll;
	GameObject blr;
	GameObject bur;
	GameObject bul;
	
	GameObject star;
	GameObject point;
    List<Int16> avaliableTowersList;
    GameObject fade;

	int pointtxt=0;
	int titletxt=10;
	int subtitletxt=38;
    bool IsAnyFishSelected;

	int action=0;
	// Use this for initialization
	void Start () {
		Lib.mute ();
		//txt
		txtstar =Lib.newText("txtstar");
		txtpoint =Lib.newText("txtpoint");
		txttitle =Lib.newText("txttitle");
		txtsubtitle =Lib.newText("txtsubtitle");
		txtbasic =Lib.newText("txtbasic");
		txtadvanced =Lib.newText("txtadvanced");
		txtimproved =Lib.newText("txtimproved");
		txttipotorre =Lib.newText("txttipotorre");
		//btn
		btnplay = GameObject.Find ("btnplay");
		btnback = GameObject.Find ("btnback");
		//obj
		bbottom = GameObject.Find ("bbottom");
		bleft = GameObject.Find ("bleft");
		bright = GameObject.Find ("bright");
		bupper = GameObject.Find ("bupper");
		bcenter = GameObject.Find ("bcenter");
		bll = GameObject.Find ("bll");
		blr = GameObject.Find ("blr");
		bur= GameObject.Find ("bur");
		bul = GameObject.Find ("bul");
		
		star = GameObject.Find ("star");
		point = GameObject.Find ("point");

        var avaliableTowers = from t in Lib.currentLevel.Element("towers").Elements("tower")
                              select Int16.Parse(t.Attribute("id").Value);

        avaliableTowersList = avaliableTowers.ToList<Int16>();

		tower = new GameObject[6,3];
		for (int i=0; i<6; i++)
			for (int e=0; e<3; e++) {
			IFish fish=getFish ((2-e)+(i*3)+1);
			tower[i,e] = new GameObject("tower"+i+"level"+e);
			tower[i,e].AddComponent<SpriteRenderer>();
			tower[i,e].AddComponent("TowerSelectButton");
			BoxCollider2D box=tower[i,e].AddComponent<BoxCollider2D>();
			box.size=new Vector3(2f,2f,0);
			Lib.setSprite(tower[i,e],"Sprites/Towers/"+fish.Image);

            //if(fish.Id!=1 && fish.Id!=4&&PlayerPrefs.GetInt("TowerBuy"+fish.Id,0)==0){
            //    tower[i,e].renderer.material.color = new Color(.15f,.15f,.15f);
            //}

			tower[i,e].renderer.sortingLayerName = "Others";
			tower[i,e].renderer.sortingOrder = 5;
			tower[i,e].transform.position = new Vector3(i*Lib.width()/7.6f - (Lib.width()/3.8f),e*Lib.height()/6.4f-(Lib.height()/6),0);
			tower[i,e].transform.localScale = new Vector3(fish.Scale,fish.Scale,1f);
			tower[i,e].transform.rotation = transform.rotation;

            //if ((fish.RequiredStars > PlayerPrefs.GetInt("TotalStars", 0)) || !(avaliableTowersList.Exists(x => x == fish.Id)))
            //{
            //    GameObject rejectimg= new GameObject("reject"+i+"level"+e);
            //    rejectimg.AddComponent<SpriteRenderer>();
            //    Lib.setSprite(rejectimg,"Sprites/Misc/tacha");
            //    rejectimg.renderer.sortingLayerName = "Others";
            //    rejectimg.renderer.sortingOrder = 6;
            //    rejectimg.transform.position = new Vector3(i*Lib.width()/7.6f - (Lib.width()/3.8f),e*Lib.height()/6.4f-(Lib.height()/6),0);
            //    rejectimg.transform.localScale = new Vector3(.4f,.4f,1f);
            //    rejectimg.transform.rotation = transform.rotation;

            //}
		}
		for (int i=0; i< 5; i++) {
			GameObject rejectimg= new GameObject("objselect"+i);
			rejectimg.AddComponent<SpriteRenderer>();
			Lib.setSprite(rejectimg,"Sprites/Misc/palomita");
			rejectimg.renderer.sortingLayerName = "Others";
			rejectimg.renderer.sortingOrder = 6;
			rejectimg.transform.position = new Vector3(i*Lib.width()/7.6f - (Lib.width()/3.8f),Lib.height()*2,0);
			rejectimg.transform.localScale = new Vector3(.4f,.4f,1f);
			rejectimg.transform.rotation = transform.rotation;
            if (PlayerPrefs.GetInt("TowerSelected" + i, 0) != 0)
                IsAnyFishSelected = true;
		}
		Lib.newFade ();
        fade = GameObject.Find("fade");
        Lib.unfades();
	}
	
	void buttonsActions(){
		if (btnback.transform.position.z == 1) {
			Lib.fades ();
			action=0;
		}

        if (btnplay.transform.position.z == 1)
        {
            if (!IsAnyFishSelected)
                Lib.setString(txttipotorre, "You must select at least one fish");
            else
            {
                action = 1;
                Lib.fades();
            }
        }
		if(Lib.isFadeReady()){
			if(action==0)
				Application.LoadLevel ("levelSelect");
			if(action==1)
                Application.LoadLevel("genericLevel");
		}
	}
	// Update is called once per frame
	void Update () {
		buttonsActions ();
        IsAnyFishSelected = false;
		//txt
		txtstar.transform.position=new Vector3(-Lib.width()/2.2f + .35f,Lib.height()/2.2f -.15f,0f);
		txtpoint.transform.position=new Vector3(Lib.width()/2.2f -.4f-(pointtxt*.114f),Lib.height()/2.2f -.15f,0f);
		txttitle.transform.position=new Vector3(-(titletxt*.088f),Lib.height()/2.2f -.1f,0f);
		txtsubtitle.transform.position=new Vector3(-(subtitletxt*.04f),Lib.height()/2.2f -.45f,0f);
		txtbasic.transform.position=new Vector3(-Lib.width()/2.2f +.1f,Lib.height()/20f *3f +.15f ,0f);
		txtadvanced.transform.position=new Vector3(-Lib.width()/2.2f +.1f,0.1f,0f);
		txtimproved.transform.position=new Vector3(-Lib.width()/2.2f +.1f,Lib.height()/20f*-3f +.15f,0f);
		txttipotorre.transform.position=new Vector3( (Lib.getStringLength(txttipotorre)*-.04f),-Lib.height()/2.2f +.5f,0f);

		//btn
        btnback.transform.position = new Vector3(-Lib.width() / 2f, -Lib.height() / 2f, 0);
        btnplay.transform.position = new Vector3(Lib.width() / 2f, -Lib.height() / 2f, 0);
		for (int i=0; i<6; i++)
		for (int e=0; e<3; e++) {
			if(tower[i,e].transform.position.z==1){
				IFish fish=getFish((2-e)+(i*3)+1);

                /*if (fish.RequiredStars > PlayerPrefs.GetInt("TotalStars", 0))
                    Lib.setString(txttipotorre, String.Format("You need {0} stars to unlock",fish.RequiredStars));
                else*/ if(avaliableTowersList.Exists(x => x == fish.Id))
                    Lib.setString(txttipotorre, fish.Name);
                else
                    Lib.setString(txttipotorre, "Not avaliable for this level");
                
				bool remove=false;
				for (int u=0; u< 5; u++) {
					if(PlayerPrefs.GetInt("TowerSelected"+u,0)==(2-e)+(i*3)+1){
						PlayerPrefs.SetInt("TowerSelected"+u,0);
						u=10;
						remove=true;
					}
				}
				for (int u=0; remove ==false && u< 5; u++) {
                    if(avaliableTowersList.Exists(x => x == fish.Id) && PlayerPrefs.GetInt("TowerSelected"+u,0)==0 /* && !(fish.Id!=1 && fish.Id!=4&&PlayerPrefs.GetInt("TowerBuy"+((2-e)+(i*3)+1),0)==0)*/){
						PlayerPrefs.SetInt("TowerSelected"+u,(2-e)+(i*3)+1);
						u=10;
                    }
					
				}

			}
			tower[i,e].transform.position = new Vector3(i*Lib.width()/7.6f - (Lib.width()/3.8f),e*Lib.height()/6.4f-(Lib.height()/6),0);
		}
		for (int u=0; u< 5; u++) {
			GameObject aceptimg= GameObject.Find("objselect"+u);
			if(PlayerPrefs.GetInt("TowerSelected"+u,0)==0){
				aceptimg.transform.position = new Vector3(Lib.width(),Lib.height(),0);
			}else{
                IsAnyFishSelected = true;
				int i=(PlayerPrefs.GetInt("TowerSelected"+u,0)-1)/3;
				int e=2-(PlayerPrefs.GetInt("TowerSelected"+u,0)-1)%3;
				aceptimg.transform.position = new Vector3(i*Lib.width()/7.6f - (Lib.width()/3.8f),e*Lib.height()/6.4f-(Lib.height()/6),0);

			}

		}
		//obj
		backgroundbox();
		star.transform.position=new Vector3(-Lib.width()/2.2f + .1f,Lib.height()/2.2f -.25f,0f);
		point.transform.position=new Vector3(Lib.width()/2.2f -.1f ,Lib.height()/2.2f -.30f,0f);

        fade.transform.localScale = new Vector3(Camera.main.aspect, 1, 1);
		
		if (!Lib.isFading()) {
			Lib.faderr ();
		}
	}
	void backgroundbox(){
		bleft.transform.position = new Vector3 (-Lib.width()/2.2f,0, 0);
		bright.transform.position = new Vector3 (Lib.width()/2.2f,0, 0);
		bbottom.transform.position = new Vector3 (0,-Lib.height()/2.3f, 0);
		bupper.transform.position = new Vector3 (0,Lib.height()/2.3f, 0);
		bcenter.transform.position = new Vector3 (0,0, 0);
		bll.transform.position = new Vector3 (-Lib.width()/2.2f,-Lib.height()/2.3f, 0);
		blr.transform.position = new Vector3 (Lib.width()/2.2f,-Lib.height()/2.3f, 0);
		bul.transform.position = new Vector3 (-Lib.width()/2.2f,Lib.height()/2.3f, 0);
		bur.transform.position = new Vector3 (Lib.width()/2.2f,Lib.height()/2.3f, 0);
		
		bcenter.transform.localScale= new Vector3 (Lib.width()*4.55f,Lib.height()*4.1f, 0);
		bbottom.transform.localScale= new Vector3 (Lib.width()*4.55f,-1f, 0);
		bupper.transform.localScale= new Vector3 (Lib.width()*4.55f,1f, 0);
		bleft.transform.localScale= new Vector3 (Lib.height()*4.1f,1f, 0);
		bright.transform.localScale= new Vector3 (Lib.height()*4.1f ,-1f, 0);
	}
	IFish getFish(int id){
        string linears = "RoundedDefence.Components.Fishes.Linears";
        string radials = "RoundedDefence.Components.Fishes.Radials";
        string roundeds = "RoundedDefence.Components.Fishes.Roundeds";
        string statics = "RoundedDefence.Components.Fishes.Statics";
        string targets = "RoundedDefence.Components.Fishes.Targets";
		string actives = "RoundedDefence.Components.Fishes.Actives";
		var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.IsClass && (t.Namespace == linears || t.Namespace == actives || t.Namespace == radials || t.Namespace == roundeds || t.Namespace == statics || t.Namespace == targets)
				select t;
			foreach (Type t in q) {
				IFish fish = (IFish)Activator.CreateInstance (t);
				if(id==fish.Id)
				return fish;
			}
		return null;
	}
}
