﻿using System;
using System.Xml.Linq;
using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RoundedDefence;
using RoundedDefence.Components.Ships;
using RoundedDefence.Components.Fishes;

public class LoadGenericLevel : MonoBehaviour {

	public Vector3 ShipScale;
	GameObject background;
	GameObject island;
	GameObject txtwave;
	GameObject btnnextwave;
    bool doAnimation = true;
    bool inWave = true;
    float timer;

	public Font font;
    public string countSprite;
	public Material material;
    GameObject counter;
    List<XElement>.Enumerator waves;
    XElement currentWave;
    bool hasNextWave;
    List<XElement>.Enumerator currentShips;
    XElement currentShip;
    bool hasNextShip;
    List<XElement>.Enumerator currentMessages;
    XElement currentMessage;
    bool hasNextMessage;

    public Camera gui;
    public Camera main;
    static GameObject collider;
    Rect rCamera;
    public Texture fog;

    CameraZoom zoom;

    GameObject fade;
    Vector3 position;
    Vector3 position2;
	GameObject zoomBar;
	GameObject btnmusica;
	GameObject btnsound;

    GameObject[] towers;

	// Use this for initialization
    void Start()
    {
		
		btnmusica = GameObject.Find ("btnmusica");
		btnsound = GameObject.Find ("btnsound");
        Lib.mute();
        timer = Time.time;
		txtwave =Lib.newText("txtwave");
		btnnextwave = GameObject.Find ("btnnextwave");
        var waveList = Lib.currentLevel.Element(XName.Get("waves")).Elements(XName.Get("wave")).ToList();
        waves = waveList.GetEnumerator();
        hasNextWave = waves.MoveNext();
        currentWave = waves.Current;
		setCurrentWave();
        background = new GameObject("background");
        background.AddComponent<SpriteRenderer>();
        background.transform.position = new Vector3(0,0,2);
        background.transform.localScale *= 0.28f;
        island = GameObject.Find("island");
        position = new Vector3(0, 0, 10);
        position2 = new Vector3(0, 0, -10);

        Lib.setSprite(background, "Sprites/Background/" + Lib.currentLevel.Attribute("background-image").Value);
        Lib.setSprite(island, "Sprites/Islands/" + Lib.currentLevel.Attribute("unlocked-sprite").Value);

        zoom = gui.gameObject.AddComponent<CameraZoom>();
        zoom.target = position2;
        zoom.Cam = main;
        zoom.maxZoom = 3;
        zoom.minZoom = 1;

        Lib.newFade();
        fade = GameObject.Find("fade"); 
        zoomBar = GameObject.Find("pseudozoom");

        towers = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            towers[i] = new GameObject("Tower" + i);
            towers[i].AddComponent<SpriteRenderer>();
            BoxCollider2D box = towers[i].AddComponent<BoxCollider2D>();
            box.size = new Vector2(0, 0);
            TowerOption option = towers[i].AddComponent<TowerOption>();
            option.option = i;
            option.id = 0;

        }

        Lib.unfades();
	}
	void addMessage(XElement msg){
		imessage++;
		GameObject obj = new GameObject ("message"+imessage);
		ShowAndHide sah=(ShowAndHide)obj.AddComponent("ShowAndHide");
		sah.font = font;
		sah.txt = msg.Value;
		sah.delay = Int16.Parse(currentMessage.Attribute("delay").Value);
		sah.speed = .04f;
		sah.material = material;
		}
	// Update is called once per frame
	int msgTime=0;
	int imessage=0;
	void Update () {
		btnmusica.transform.position = new Vector3(Lib.width() / 2f- .6f, Lib.height() / 2f - .2f, -9f);
		btnsound.transform.position = new Vector3(Lib.width() / 2f - .2f, Lib.height() / 2f - .2f, -9f);
        for (int i = 0; i < 5; i++)
        {
            towers[i].transform.position = new Vector3(-Lib.width() / 2f - 0.4f, Lib.height() / 8f + 0.7f, -9f);
            SpriteRenderer sprRenderer = (SpriteRenderer)towers[i].renderer;
            sprRenderer.sprite = null;
             }
        drawTowersMenu();
        zoomBar.transform.position = new Vector3(Lib.width() / 2f - .4f, Lib.height() / 8f - 0.3f, -9f);
        
		if (btnnextwave.transform.position.z == 1) {
			inWave=false;
			
			Destroy (GameObject.Find("message"+imessage));
		}
        btnnextwave.transform.position = new Vector3(Lib.width() / 6f, Lib.height() / 6f, 0f);
        fade.transform.localScale = new Vector3(Camera.main.aspect, 1, 1);
            if (inWave)
            {

                int currentTime = (int)((Time.time - timer)*10);
			Lib.setString(txtwave,currentTime-Int16.Parse(currentWave.Attribute("time").Value) +"");
                if (currentTime > Int16.Parse(currentWave.Attribute("time").Value))
                {
					print ("next");
                    inWave = false;
                }
                else
                {
                    if (hasNextMessage && msgTime <= currentTime)
                    {
					addMessage(currentMessage);
					//print (currentMessage.Attribute("time").Value);
						msgTime+=Int16.Parse(currentMessage.Attribute("time").Value);
					
					print (msgTime+"  " + currentTime);
                        hasNextMessage = currentMessages.MoveNext();
                        currentMessage = currentMessages.Current;
                    }
                    if (hasNextShip && Int16.Parse(currentShip.Attribute("time").Value) <= currentTime)
                    {
                        Int16 angle = Int16.Parse(currentShip.Attribute("angle").Value);
                        String id = currentShip.Attribute("id").Value;
                    GameObject ship = new GameObject(String.Format("Ship.{0}.{1}.{2}", id, angle, currentTime));
                    ship.transform.localScale = ShipScale;
                    ship.AddComponent<SpriteRenderer>();
                    ShipElement s = ship.AddComponent<ShipElement>();
                    s.id = id;
                    s.angle = angle;
                    hasNextShip = currentShips.MoveNext();
                    currentShip = currentShips.Current;
                }
            }
        }
        else
        {
            hasNextWave = waves.MoveNext();
            currentWave = waves.Current;
            if (hasNextWave)
            {
                inWave = true;
                msgTime = 0;
                timer = Time.time;
                setCurrentWave();
            }
            else
            {
                Debug.Log("Level cleared");
            }
        }

        Lib.dofade();
	}
    void drawTowersMenu()
    {
        int[] towersArray = new int[5];
        for(int i = 0; i < 5; i++)
            towersArray[i] = PlayerPrefs.GetInt("TowerSelected" + i, 0);

        var towers = from t in towersArray
                     where t != 0
                     orderby t ascending
                     select t;

        int j = 0;
            foreach (int towerNum in towers)
            {
                GameObject tower = GameObject.Find("Tower" + j);
                BoxCollider2D box = tower.GetComponent<BoxCollider2D>();
                box.size = new Vector2(3, 3);
                TowerOption option = tower.GetComponent<TowerOption>();
                option.id = towerNum;
                SpriteRenderer sprRenderer = tower.GetComponent<SpriteRenderer>();
                IFish theFish = Lib.Fishes[towerNum];
                sprRenderer.sprite = Resources.Load<Sprite>(String.Format("Sprites/Towers/{0}", theFish.Image));
                sprRenderer.transform.localScale = (new Vector3(1,1,1))*0.2f;
                sprRenderer.sortingLayerName = "Shots";
                tower.transform.Translate(new Vector3(0, -j*0.7f, 0));
                j++;
            }
    }
    void setCurrentWave()
	{
		msgTime=0;
		timer = Time.time;
		var ships = from ship in currentWave.Elements("ship")
			orderby Int16.Parse(ship.Attribute("time").Value) ascending
				select ship;
		currentShips = ships.ToList<XElement>().GetEnumerator();
		hasNextShip = currentShips.MoveNext();
		currentShip = currentShips.Current;
		var msgs = from msg in currentWave.Elements("msg") select msg;
		currentMessages = msgs.ToList<XElement>().GetEnumerator();
		hasNextMessage = currentMessages.MoveNext();
		currentMessage = currentMessages.Current;
		playMusic (currentWave.Attribute ("background-music").Value);
	}
	void playMusic(string txt){
		GameObject music=new GameObject(txt);
		music.AddComponent ("FadeMusic");
	}
}
