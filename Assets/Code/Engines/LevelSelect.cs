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

    GameObject leftbar;
    GameObject rightbar;
    GameObject fade;
    Vector3 position;
    GameObject fade2;
    Vector3 position2;
    GameObject zoomBar;

    public static Camera GUI;
    public Camera gui;
    static GameObject collider;
    Rect rCamera;

    GameObject[] previews;

    CameraZoom zoom;
    LoadLevelSelectGUI GM;

	int action=0;
	// Use this for initialization
	void Start () {
        GUI = gui;
        Lib.mute();
        Lib.newFade("fade");
        Lib.newFade("fade2");
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
		objstarStar = GameObject.Find ("starStars");
		objstarScore = GameObject.Find ("starScore");
        leftbar = GameObject.Find("leftbar");
        rightbar = GameObject.Find("rightbar");
        fade = GameObject.Find("fade");
        collider = new GameObject("Collider");
        collider.AddComponent<SpriteRenderer>();
        collider.transform.position = fade.transform.position+(new Vector3(0,0,10));
        BoxCollider2D col2d = collider.AddComponent<BoxCollider2D>();
        col2d.size = fade.renderer.bounds.size;
        MouseHandlerLevelSelect handler = collider.AddComponent<MouseHandlerLevelSelect>();
        fade2 = GameObject.Find("fade2");
        position = new Vector3(0, 0, 10);
        position2 = new Vector3(0, 0, -10);
        zoom = GUI.gameObject.AddComponent<CameraZoom>();
        GM = GameObject.Find("_GM").GetComponent<LoadLevelSelectGUI>();
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
		if (btnback.transform.position.z == -21) {
			action=0;
			Lib.fades();
		}
		if (btnplay.transform.position.z == -21) {
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
            previews[i].transform.position = new Vector3(-Lib.width() / 2f + 0.4f, Lib.height() / 8f -0.3f, -30f);
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
        txtstar.transform.position = new Vector3(Lib.width() / 2f - .4f, Lib.height() / 2f - .04f, -30f);
        txtname.transform.Translate(new Vector3((Lib.getStringLength(txtname) * -.048f) - 1.8f, -Lib.height() / 2f + .7f, 20));
        txtmsg.transform.position = new Vector3(-Lib.getStringLength(txtmsg) * -.048f, -Lib.height() / 2f + .7f, -30f);
        txtscore.transform.Translate(new Vector3((Lib.getStringLength(txtscore) * -.048f) + .2f, -Lib.height() / 2f + .35f, 20));
		//btn
        btnmusica.transform.position = new Vector3(-Lib.width() / 2f + .6f, Lib.height() / 2f - .2f, -30f);
        btnsound.transform.position = new Vector3(-Lib.width() / 2f + .2f, Lib.height() / 2f - .2f, -30f);
        btnplay.transform.Translate(new Vector3(Lib.width() / 2f - .7f, -Lib.height() / 2f + .35f, 20f));
        btnback.transform.position = new Vector3(Lib.width() / 2f - .7f, -Lib.height() / 2f + .35f, -30f);
		//obj
        objstarStar.transform.position = new Vector3(Lib.width() / 2f - .22f, Lib.height() / 2f - .17f, -30f);
        objhudbar.transform.position = new Vector3(0, -Lib.height() / 2f, -10f);
        leftbar.transform.position = new Vector3((Lib.width() - leftbar.renderer.bounds.size.x) / 2f, 0, -30f);
        rightbar.transform.position = new Vector3(-(Lib.width() - rightbar.renderer.bounds.size.x) / 2f, 0, -30f);
		objstarScore.transform.Translate(new Vector3(-(Lib.getStringLength(txtscore)*-.048f),-Lib.height()/2f+.20f,0));

        zoomBar.transform.position = new Vector3(Lib.width() / 2f - .4f, Lib.height() / 8f - 0.3f, -30f);

        rCamera = new Rect(0, 0, 10, 10);
        rCamera.xMin = Screen.height / 5f;
        rCamera.xMax = Screen.width - Screen.height / 5f;
        rCamera.yMax = Screen.height;
        rCamera.yMin = Screen.height / 5;
        gui.pixelRect = rCamera;
        gui.enabled = true;
        fade.transform.localScale = new Vector3(Camera.main.aspect * gui.orthographicSize, gui.orthographicSize, 1);
        fade2.transform.localScale = new Vector3(Camera.main.aspect, 1, 1);

        if (IslandSelected.centroid == "")
            zoom.minZoom = 1;
        else if (IslandSelected.centroid.Substring(0, 6) == "LevelS")
            zoom.minZoom = GM.scaleLevelSpecial.magnitude * 1.5f;
        else
            zoom.minZoom = GM.scaleLevelNormal.magnitude * 1.5f;
            

        //txt
        Lib.followCamera(txtstar);
        Lib.followCamera(txtscore);
        Lib.followCamera(txtmsg);
        Lib.followCamera(txtname);
        //btn
        Lib.followCamera(btnmusica);
        Lib.followCamera(btnsound);
        Lib.followCamera(btnback);
        Lib.followCamera(btnplay);
        //obj
        Lib.followCamera(objstarScore);
        Lib.followCamera(objstarStar);
        Lib.followCamera(objhudbar);
        Lib.followCamera(leftbar);
        Lib.followCamera(rightbar);
        Lib.followCamera(zoomBar);

        Lib.dofade(fade,position,gui);
        Lib.dofade(fade2, position2,Camera.main);

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
		Vector3 move=new Vector3(0,0,-10);
        txtname.transform.position=move;
		txtscore.transform.position=move;
		btnplay.transform.position=move;
		objstarScore.transform.position=move;
	}


}
