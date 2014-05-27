using UnityEngine;
using System;
using System.Collections;
using RoundedDefence.Components.Ships;
using RoundedDefence;

public class ShipElement : MonoBehaviour {
    public String id;
    public Int16 angle;
    int level;
    int step;
    float radius = 2.8f;
    IShip thisShip;
    Vector3 normal;
    Vector3 init;
    float timer;
	
    // Use this for initialization
	void Start () {
        level = 24;
        thisShip = (IShip)Activator.CreateInstance(Lib.Ships[id].GetType());
        float initAngle = Lib.toTiles(new Point(level, angle)).Y;
        ShortPath p = new ShortPath(level, (int)initAngle, 0, 0);
        thisShip.Path = p.getPath(); 
        initAngle = initAngle * (360f / Lib.getNcircles(level));
        transform.position = new Vector3(radius * Mathf.Cos(initAngle * Mathf.PI / 180), radius * Mathf.Sin(initAngle * Mathf.PI / 180), 0);
        transform.Rotate(Vector3.forward, 90 + initAngle);
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
        float velocity = 0.01f;
//        float currentTime = Time.time - timer;
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
    }
}
