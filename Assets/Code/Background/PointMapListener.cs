using UnityEngine;
using System;
using System.Collections;
using RoundedDefence;
using RoundedDefence.Components.Fishes;

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
            if (Input.GetMouseButtonDown(0))
            {

                GameObject theFish = new GameObject(TowerSelector.idselected + name);
                theFish.AddComponent<SpriteRenderer>();
                FishElement theSettings = theFish.AddComponent<FishElement>();
                theSettings.id = TowerSelector.idselected;
                theSettings.position = transform.position;
            }
        }
        over = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!over && renderer.enabled == true)
        {
            //for (int i = 1; i < 18; i++)
            //{
            //    for (int e = 0; e < Lib.getNcircles(i); e++)
            //    {
            //        GameObject point2 = GameObject.Find(String.Format("Point{0},{1}", i, e));
            //        point2.renderer.enabled = false;
            //    }
            //}
            //renderer.enabled = false;
        }
        over = false;
	}
}
