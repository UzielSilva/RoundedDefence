using System;
using System.Xml.Linq;
using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RoundedDefence;
using RoundedDefence.Components.Ships;

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
    static GameObject collider;
    Rect rCamera;

    GameObject fade;
    Vector3 position;
    GameObject fade2;
    Vector3 position2;

	// Use this for initialization
    void Start()
    {
        Lib.mute();
        timer = Time.time;
		txtwave =Lib.newText("txtwave");
		btnnextwave = GameObject.Find ("btnnextwave");
        var waveList = Lib.currentLevel.Element(XName.Get("waves")).Elements(XName.Get("wave")).ToList();
        waves = waveList.GetEnumerator();
        hasNextWave = waves.MoveNext();
        currentWave = waves.Current;
		setCurrentWave();
        //background = GameObject.Find("background");
        background = new GameObject("background");
        background.AddComponent<SpriteRenderer>();
        background.transform.position = new Vector3(0,0,2);
        background.transform.localScale *= 0.3f;
        island = GameObject.Find("island");

        Lib.setSprite(background, "Sprites/Background/" + Lib.currentLevel.Attribute("background-image").Value);
        Lib.setSprite(island, "Sprites/Islands/" + Lib.currentLevel.Attribute("unlocked-sprite").Value);

        Lib.newFade("fade");
        Lib.newFade("fade2");
        fade = GameObject.Find("fade"); 
        fade2 = GameObject.Find("fade2");
        position = new Vector3(0, 0, 10);
        position2 = new Vector3(0, 0, -10);
        Lib.unfades();
	}
	void addMessage(XElement msg){
        Debug.Log(msg.Value);
		GameObject obj = new GameObject (msg.Value);
		ShowAndHide sah=(ShowAndHide)obj.AddComponent("ShowAndHide");
		sah.font = font;
		sah.txt = msg.Value;
		sah.delay = Int16.Parse(currentMessage.Attribute("delay").Value);
		sah.speed = .04f;
		sah.material = material;
		}
	// Update is called once per frame
	int msgTime=0;
	void Update () {
		if (btnnextwave.transform.position.z == 1) {
			inWave=false;
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
						msgTime+=Int16.Parse(currentMessage.Attribute("time").Value);
                        hasNextMessage = currentMessages.MoveNext();
                        currentMessage = currentMessages.Current;
                    }
                    if (hasNextShip && Int16.Parse(currentShip.Attribute("time").Value) <= currentTime)
                    {
                        Int16 angle = Int16.Parse(currentShip.Attribute("angle").Value);
                        String id = currentShip.Attribute("id").Value;

                        GameObject ship = new GameObject(String.Format("Ship.{0}.{1}.{2}", id, angle,currentTime));
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
					inWave=true;
				msgTime=0;
                    timer = Time.time;
                    setCurrentWave();
                }
                else
                {
                    Debug.Log("Level cleared");
                }
            }

        rCamera = new Rect(0, 0, 10, 10);
        rCamera.xMin = Screen.height / 5f;
        rCamera.xMax = Screen.width - Screen.height / 5f;
        rCamera.yMax = Screen.height;
        rCamera.yMin = Screen.height / 5;
        gui.pixelRect = rCamera;
        gui.enabled = true;

        Lib.dofade(fade, position, gui);
        Lib.dofade(fade2, position2, Camera.main);
	}
    void setCurrentWave()
	{
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
