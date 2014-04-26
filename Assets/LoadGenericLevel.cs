using System;
using System.Reflection;
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
    bool doAnimation = true;
    bool inWave = true;
    float timer = 0;
    int count = 3;
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
    Dictionary<String, IShip> Ships;

	// Use this for initialization
    void Start()
    {
        Lib.mute();
        var waveList = Lib.currentLevel.Element(XName.Get("waves")).Elements(XName.Get("wave")).ToList();
        waves = waveList.GetEnumerator();
        hasNextWave = waves.MoveNext();
        currentWave = waves.Current;
        var ships = from ship in currentWave.Elements("ship")
                    orderby Int16.Parse(ship.Attribute("time").Value) ascending
                    select ship;
        currentShips = ships.ToList<XElement>().GetEnumerator();
        hasNextShip = currentShips.MoveNext();
        currentShip = currentShips.Current;
        var msgs = from msg in currentWave.Elements("msg")
                    orderby Int16.Parse(msg.Attribute("time").Value) ascending
                    select msg;
        currentMessages = msgs.ToList<XElement>().GetEnumerator();
        hasNextMessage = currentMessages.MoveNext();
        currentMessage = currentMessages.Current;
        counter = new GameObject("counter");
        counter.transform.position = new Vector3(0, 0, 0);
        counter.AddComponent<SpriteRenderer>();
        background = GameObject.Find("background");
        island = GameObject.Find("island");

        Ships = new Dictionary<string, IShip>();
        string @namespace = "RoundedDefence.Components.Ships.Types";

        var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.IsClass && t.Namespace == @namespace
                select t;

        foreach (Type t in q)
        {
            IShip ship = (IShip)Activator.CreateInstance(t);
            String id = ship.Id;

            Ships.Add(id, ship);
        }

        GameObject camera = GameObject.Find("Camera");
        AudioSource audioSource = camera.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("Music/music/" + Lib.currentLevel.Attribute("background-music").Value) as AudioClip;
        audioSource.loop = true;
        audioSource.Play();
        Lib.setSprite(background, "Sprites/Background/" + Lib.currentLevel.Attribute("background-image").Value);
        Lib.setSprite(island, "Sprites/Islands/" + Lib.currentLevel.Attribute("unlocked-sprite").Value);
        Lib.newFade();
        Lib.unfades();
	}
	void addMessage(String txt){
		GameObject obj = new GameObject (txt);
		ShowAndHide sah=(ShowAndHide)obj.AddComponent("ShowAndHide");
		sah.font = font;
		sah.txt = txt;
		sah.delay = 200;
		sah.speed = .01f;
		sah.material = material;
		}
	// Update is called once per frame
	void Update () {
        if (!doAnimation)
        {
            if (inWave)
            {
                int currentTime = (int)(Time.time - timer);
                if (currentTime > Int16.Parse(currentWave.Attribute("time").Value))
                {
                    inWave = false;
                }
                else
                {
                    if (hasNextMessage && Int16.Parse(currentMessage.Attribute("time").Value) == currentTime)
                    {
						addMessage(currentMessage.Value);
                        hasNextMessage = currentMessages.MoveNext();
                        currentMessage = currentMessages.Current;
                    }
                    if (hasNextShip && Int16.Parse(currentShip.Attribute("time").Value) == currentTime)
                    {
                        Int32 angle = Int16.Parse(currentShip.Attribute("angle").Value);
                        String id = currentShip.Attribute("id").Value;
                        float radius = 2f;
                        IShip sh = Ships[id];
                        GameObject ship = new GameObject(String.Format("Ship.{0}.{1}.{2}", id, angle, currentTime));
                        ship.transform.position = new Vector3(radius * Mathf.Cos(angle * Mathf.PI / 180), radius * Mathf.Sin(angle * Mathf.PI / 180), 0);
                        ship.transform.localScale = ShipScale;
                        ship.AddComponent<SpriteRenderer>();
                        ship.renderer.sortingLayerName = "Ships";
                        Lib.setSprite(ship, "Sprites/Ships/" + sh.Image);
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
                    timer = Time.time;
                    setCurrentWave();
                }
                else
                {
                    Debug.Log("Level cleared");
                }
            }
        }

        if (!Lib.isFading())
        {
            Lib.faderr();
        }
        else if (doAnimation)
            Animation();
	}
    void Animation()
    {
        if (timer == 0)
        {
            timer = Time.time;
            Lib.setSprite(counter, "Sprites/Misc/" + countSprite + count);
            SpriteRenderer sprRenderer = counter.GetComponent<SpriteRenderer>();
            sprRenderer.sortingLayerName = "Others";
        }
        var stateTime = Time.time - timer;
        int restSeconds = (int)(stateTime);
        if (restSeconds == 1)
        {
            timer = Time.time;
            count--;
            Lib.setSprite(counter, "Sprites/Misc/" + countSprite + count);
            if (count < 0)
            {
                doAnimation = false;
                Lib.setSprite(counter, "");
            }
        }
    }
    void setCurrentWave()
    {
        var ships = from ship in currentWave.Elements("ship")
                    orderby Int16.Parse(ship.Attribute("time").Value) ascending
                    select ship;
        currentShips = ships.ToList<XElement>().GetEnumerator();
        currentShips.MoveNext();
        currentShip = currentShips.Current;
        var msgs = from msg in currentWave.Elements("msg")
                   orderby Int16.Parse(msg.Attribute("time").Value) ascending
                   select msg;
        currentMessages = msgs.ToList<XElement>().GetEnumerator();
        currentMessages.MoveNext();
        currentMessage = currentMessages.Current;
    }
}
