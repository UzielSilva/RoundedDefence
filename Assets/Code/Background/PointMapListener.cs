using UnityEngine;
using System;
using System.Collections;
using RoundedDefence;
using RoundedDefence.Components.Fishes;

public class PointMapListener : MonoBehaviour {
    public bool over;

    public delegate void ClickAction();
    public delegate void HoverAction(int point);
    public static event ClickAction OnClicked;
    public static event HoverAction OnHover;

	// Use this for initialization
	void Start () {
        over = false;
	}
    void OnMouseOver()
    {
        if (TowerSelector.idselected != 0)
        {
            int theInt = Int16.Parse(name.Substring(13));
            if (OnHover != null)
                OnHover(theInt);
            renderer.enabled = true;
            if (Lib.map[theInt] == 1000)
                Lib.setSprite(gameObject, "Sprites/Misc/circlered");
            else
                Lib.setSprite(gameObject, "Sprites/Misc/circlegreen");
            if (Input.GetMouseButtonDown(0))
            {
                if (Lib.map[theInt] != 1000)
                {
                    GameObject point2 = GameObject.Find(String.Format("Point{0}", theInt));
                    SpriteRenderer sprRenderer = point2.GetComponent<SpriteRenderer>();
                    sprRenderer.color = Color.red;
                    Lib.map[theInt] = 1000;
                    GameObject theFish = new GameObject(TowerSelector.idselected + name);
                    theFish.AddComponent<SpriteRenderer>();
                    FishElement theSettings = theFish.AddComponent<FishElement>();
                    theSettings.id = TowerSelector.idselected;
                    theSettings.position = transform.position;
                    if(OnClicked != null)
                        OnClicked();
                }
            }
            over = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!over && renderer.enabled == true)
        {
            for (int i = 13; i < 220; i++)
            {
                SpriteRenderer thePoint2 = GameObject.Find(String.Format("Point{0}", i)).GetComponent<SpriteRenderer>();
                if (Lib.map[i] == 1000)
                    thePoint2.color = Color.red;
                else
                    thePoint2.color = Color.gray;
            }
            renderer.enabled = false;
        }
        over = false;
	}
}
