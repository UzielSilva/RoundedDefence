using UnityEngine;
using System;
using System.Collections;
using RoundedDefence.Components.Ships;
using RoundedDefence;

public class ShipElement : MonoBehaviour {
    public String id;
    public Int16 angle;
    int step;
    float radius = 2.8f;
    IShip thisShip;
    Vector3 normal;
    Vector3 init;
    float timer;
	
    // Use this for initialization
	void Start () {
        thisShip = (IShip)Activator.CreateInstance(Lib.Ships[id].GetType());
        ShortPath p = new ShortPath(angle, 21, Lib.map);
        thisShip.Path = p.getPath(); 
        transform.position =  Lib.toCords(angle);
       	transform.Rotate(Vector3.forward, 90 + Lib.toAngle(angle));
        SpriteRenderer sprRenderer = GetComponent<SpriteRenderer>();
        sprRenderer.sprite = Resources.Load<Sprite>("Sprites/Ships/" + thisShip.Image);
        renderer.sortingLayerName = "Ships";
        normal = transform.position.normalized;
        init = transform.position;
        timer = Time.time;
        step = 1;
	}
	
	// Update is called once per frame
	void Update () {

       if (step < thisShip.Path.camino.Count)
            goToNextStep();
        
	
	}
    void goToNextStep()
    {
		/*
        float velocity = 0.01f;
        float currentTime = Time.time - timer;
        Camino c = thisShip.Path.camino[thisShip.Path.camino.Count - step];
        GameObject point = GameObject.Find(String.Format("Point{0},{1}", c.lvl, c.p));
        Vector3 old = transform.position;
        Vector3 direction = (point.transform.position - transform.position).normalized * velocity;
        transform.position += direction;
        if ((old - transform.position).magnitude >= (old - point.transform.position).magnitude
            || point.transform.position == transform.position)
        {
            level = c.lvl;
            step++;
        }
        */
    }
}
