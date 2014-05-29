using UnityEngine;
using System;
using System.Collections;
using RoundedDefence;
using System.Xml.Linq;
using System.Linq;
using RoundedDefence.Components.Ships;

public class LevelSelect : MonoBehaviour {
	//text
    GameObject txtmsg;
    GameObject txtname;
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
	GameObject objhudbarl;
	GameObject objhudbarr;
	GameObject objhudbar2;

    GameObject fade;
//    Vector3 position;
    Vector3 position2;
    GameObject zoomBar;
	
//	private int cam1Deep=0;


    public static Camera GUI;
    public Camera gui;
    static GameObject collider;
    Rect rCamera;

    GameObject[] previews;

    CameraZoom zoom;
//    LoadLevelSelectGUI GM;

	int action=0;
	// Use this for initialization
	void Start () {
        GUI = gui;
        Lib.mute();
        Lib.newFade();
        Lib.unfades();

		//text
		txtstar =Lib.newText("txtstars");
        txtmsg = Lib.newText("txtmsg");
        txtname = Lib.newText("txtname");
		txtscore = Lib.newText("txtscore");

        Lib.setString(txtstar, PlayerPrefs.GetInt("TotalStars", 0) + "");

		//buttons
		btnmusica = GameObject.Find ("btnmusica");
		btnsound = GameObject.Find ("btnsound");
		btnplay = GameObject.Find ("btnplay");
		btnback = GameObject.Find ("btnback");
		//others
		objhudbar = GameObject.Find ("hudbar");
		objhudbarl = GameObject.Find ("hudbarl");
		objhudbarr = GameObject.Find ("hudbarr");
		objhudbar2 = GameObject.Find ("hudbar2");
		objstarStar = GameObject.Find ("starStars");
		objstarScore = GameObject.Find ("starScore");
        fade = GameObject.Find("fade");
        collider = new GameObject("Collider");
        collider.AddComponent<SpriteRenderer>();
        BoxCollider2D col2d = collider.AddComponent<BoxCollider2D>();
        col2d.size = fade.renderer.bounds.size;
        collider.AddComponent<MouseHandlerLevelSelect>();
        collider.transform.position = new Vector3(0, 0,1);
//        position = new Vector3(0, 0, 10);
        position2 = new Vector3(0, 0, -10);
        zoom = GUI.gameObject.AddComponent<CameraZoom>();
        zoom.target = position2;
        zoom.Cam = Camera.main;
      //  GM = GameObject.Find("_GM").GetComponent<LoadLevelSelectGUI>();
        var levels = from level in Lib.data.Element(XName.Get("levels")).Elements(XName.Get("level"))
                     select level;
        zoom.maxZoom = levels.ToArray().Length;
        zoom.minZoom = 1;

        zoomBar = GameObject.Find("pseudozoom");

        previews = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            previews[i] = new GameObject("Preview" + i);
            previews[i].AddComponent<SpriteRenderer>();
            previews[i].transform.Rotate(Vector3.forward, -90);
        }

	}
	void buttonsActions(){
		if (btnback.transform.position.z == -8) {
			action=0;
			Lib.fades();
		}
		if (btnplay.transform.position.z == -8) {
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
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            previews[i].transform.position = new Vector3(Lib.width() / 2f - 0.4f, Lib.height() / 8f -0.3f, 1f);
            SpriteRenderer sprRenderer = (SpriteRenderer)previews[i].renderer;
            sprRenderer.sprite = null;
            Lib.followCamera(previews[i]);
        }
		buttonsActions ();
		buttonsFade ();
		Vector3 move=new Vector3(0,0,0);
		btnplay.transform.position=move;
		txtscore.transform.position=move;
        txtname.transform.position = move;
		objstarScore.transform.position=move;

        drawDescription();
		//txt
		txtstar.transform.position = new Vector3(-Lib.width() / 2f +.4f-((PlayerPrefs.GetInt("TotalStars", 0)+"").Length*.055f), Lib.height() / 2f - .34f, -9f);
        txtname.transform.Translate(new Vector3(- (Lib.width()/3.2f), -Lib.height() / 2f + .7f, -19f));
        txtmsg.transform.position = new Vector3(Lib.getStringLength(txtmsg) * -.048f, -Lib.height() / 2f + .7f, -9f);
        txtscore.transform.Translate(new Vector3((Lib.getStringLength(txtscore) * -.048f) + .2f, -Lib.height() / 2f + .35f, -19f));
		//btn
        btnmusica.transform.position = new Vector3(Lib.width() / 2f- .6f, Lib.height() / 2f - .2f, -9f);
        btnsound.transform.position = new Vector3(Lib.width() / 2f - .2f, Lib.height() / 2f - .2f, -9f);
        btnplay.transform.Translate(new Vector3(Lib.width() / 2f , -Lib.height() / 2f  , -19f));
        btnback.transform.position = new Vector3(-Lib.width() / 2f , -Lib.height() / 2f  , -9f);
		//obj
		objstarStar.transform.position = new Vector3(-Lib.width() / 2f + .4f, Lib.height() / 2f - .17f, -9f);
		objhudbar.transform.position = new Vector3(0, -Lib.height() / 2f, -9f);   
		objhudbar2.transform.position = new Vector3(0, -Lib.height() / 2f, -9f);
		objhudbarl.transform.position = new Vector3(-43.6f*Lib.width()/100, -1.3f, -9f);
		objhudbarr.transform.position = new Vector3(43.6f*Lib.width()/100, -1.3f, -9f);
		objhudbar.transform.localScale = new Vector3 (Lib.width()*4.3f, 8f, 1f);
		objhudbar2.transform.localScale = new Vector3 (Lib.width()*4.5f, 6.5f, 1f);
		objstarScore.transform.Translate(new Vector3((Lib.getStringLength(txtscore)*-.048f),-Lib.height()/2f+.20f,-19f));

        zoomBar.transform.position = new Vector3(-Lib.width() / 2f + .4f, Lib.height() / 8f - 0.3f, -9f);

        rCamera = new Rect(0, 0, 10, 10);
        rCamera.xMin = 0;
        rCamera.xMax = Screen.width;
        rCamera.yMax = Screen.height;
        rCamera.yMin = 0;
        gui.pixelRect = rCamera;
        gui.enabled = true;
        collider.transform.localScale = new Vector3(Camera.main.aspect * gui.orthographicSize, gui.orthographicSize, 1);

        if (IslandSelected.centroid == "")
            zoom.minZoom = 1;

        //txt
        //btn
        //obj
		
		fade.transform.localScale = new Vector3(Camera.main.aspect, 1, 1);
		if (!Lib.isFading()) {
			Lib.faderr ();
		}

	}
    void drawShips()
    {
        if (IslandSelected.centroid != "")
        {
            var ships = (from wave in Lib.currentLevel.Element(XName.Get("waves")).Elements(XName.Get("wave"))
                                from ship in wave.Elements(XName.Get("ship"))
                                orderby ship.Attribute(XName.Get("id")).Value descending
                                select ship.Attribute(XName.Get("id")).Value).Distinct<string>();
            int i = 0;
            float totalLength = 0;
            foreach (string ship in ships)
            {
                IShip theShip = Lib.Ships[ship];
                totalLength += Resources.Load<Sprite>(String.Format("Sprites/Ships/{0}", theShip.Image)).rect.width;
            }
            float accumulateLength = 0;
            foreach (string ship in ships)
            {
                GameObject preview = GameObject.Find("Preview" + i);
                SpriteRenderer sprRenderer = preview.GetComponent<SpriteRenderer>();
                IShip theShip = Lib.Ships[ship];
                sprRenderer.sprite = Resources.Load<Sprite>(String.Format("Sprites/Ships/{0}", theShip.Image));
                sprRenderer.sortingLayerName = "Shots";
                preview.transform.Translate(new Vector3((totalLength / 2f - accumulateLength - sprRenderer.sprite.rect.width/2f) / 340f, 0, 0));
                accumulateLength += sprRenderer.sprite.rect.width;
                i++;
            }
        }
    }
	void drawDescription(){
        Lib.setString(txtname, "");
        int requiredStars = Int32.Parse(Lib.currentLevel.Attribute(XName.Get("required-stars")).Value);
        int levelNum = Int16.Parse(Lib.currentLevel.Attribute(XName.Get("levelnum")).Value);
        if (IslandSelected.centroid != "")
        {
            int world = Int16.Parse(Lib.currentLevel.Attribute(XName.Get("world")).Value);
            if (PlayerPrefs.GetInt("WorldUnlocked", 1) >= world)
            {
                bool enabledd = PlayerPrefs.GetInt("LvlUnlocked", 1) >= levelNum;
                if (enabledd)
                {
                    enabledd = PlayerPrefs.GetInt("TotalStars", 0) >= requiredStars;
                    if (enabledd)
                    {
                        drawStats();
                        drawShips();
                    }
                    else
                    {
                        Lib.setString(txtmsg, "YOU NEED " + requiredStars + " STARS TO PLAY");
                    }
                }
                else
                {
                    Lib.setString(txtmsg, "PASS LEVEL " + (levelNum - 1) + " TO PLAY");
                }
            }
            else
            {
                Lib.setString(txtmsg, "CLEAR WORLD " + (world - 1) + " TO PLAY");
            }
		} else {
			Lib.setString(txtmsg,"SELECT A LEVEL");
		}
	}
	void drawStats(){
		//TODO: Assign score storage.
		int score = 0;
        int oneStar = Int32.Parse(Lib.currentLevel.Element(XName.Get("scores")).Attribute(XName.Get("one-star")).Value);
        int twoStar = Int32.Parse(Lib.currentLevel.Element(XName.Get("scores")).Attribute(XName.Get("two-star")).Value);
        int threeStar = Int32.Parse(Lib.currentLevel.Element(XName.Get("scores")).Attribute(XName.Get("three-star")).Value);
        Lib.setString(txtname, Lib.currentLevel.Attribute(XName.Get("name")).Value);
        Lib.setString(txtmsg, "SCORE : 0" );
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
        txtname.transform.position=move;
		txtscore.transform.position=move;
		btnplay.transform.position=move;
		objstarScore.transform.position=move;
	}


}
