using UnityEngine;
using System;
using System.Collections;
using RoundedDefence;

public class PointMapListener : MonoBehaviour {
    GameObject shadow;
    public static int[] costMap = new int[220];
    bool over;

    public delegate void ClickAction();
    public delegate void HoverAction(string[] point);
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
            string[] point = name.Substring(13).Split(',');
            /////////////////
            if (!over)
                if(OnHover != null)
                    OnHover(point);
            renderer.enabled = true;
            if (Input.GetMouseButtonDown(0))
            {
                PointMapListener.costMap[(Int16.Parse(point[0]))] = 10000;
                GameObject fish = new GameObject(name + "fish");
                fish.transform.position = transform.position;
                fish.AddComponent<SpriteRenderer>();
                Lib.setSprite(fish, "Sprites/Towers/" + Lib.Fishes[TowerSelector.idselected].Image);
                fish.transform.localScale = (new Vector3(1,1,1))*0.05f;
                if(OnClicked != null)
                    OnClicked();
            }
        }
        over = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!over && renderer.enabled == true)
        {
            for (int i = 1; i < 18; i++)
            {
                for (int e = 0; e < Lib.getNcircles(i); e++)
                {
                    GameObject point2 = GameObject.Find(String.Format("Point{0},{1}", i, e));
                    point2.renderer.enabled = false;
                }
            }
            renderer.enabled = false;
        }
        over = false;
	}
}
