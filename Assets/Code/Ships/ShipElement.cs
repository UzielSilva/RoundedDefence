using UnityEngine;
using System;
using System.Collections;
using RoundedDefence.Components.Ships;
using RoundedDefence;

public class ShipElement : MonoBehaviour {
    public String id;
    public Int16 angle;
    int level;
    float radius = 2.8f;
    IShip thisShip;
    Vector3 normal;
    Vector3 init;
    float timer;
	
    // Use this for initialization
	void Start () {
        //level = 25;
        //thisShip = Lib.Ships[id];
        //float initAngle = Lib.toTiles(new Point(level,angle)).Y;
        //ShortPath p = new ShortPath(25,(byte)initAngle,1,0);
        //thisShip.Path = p.getPath();
        //initAngle = initAngle*(360f/Lib.getNcircles(level));
        //transform.position = new Vector3(radius * Mathf.Cos(initAngle * Mathf.PI / 180), radius * Mathf.Sin(initAngle * Mathf.PI / 180), 0);
        //transform.Rotate(Vector3.forward, 90 + initAngle);
        //SpriteRenderer sprRenderer = GetComponent<SpriteRenderer>();
        //sprRenderer.sprite = Resources.Load<Sprite>("Sprites/Ships/" + thisShip.Image);
        //renderer.sortingLayerName = "Ships";
        //normal = transform.position.normalized;
        //init = transform.position;
        //timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        goToNextLevel();
        
	
	}
    void goToNextLevel()
    {
        //float velocity = 0.05f;
        //float currentTime = Time.time - timer;
        //Camino c = thisShip.Path.camino[level-1];
        //GameObject point = GameObject.Find(String.Format("Point{0},{1}",c.lvl,c.p));
        //Vector3 old = transform.position;
        //Vector3 direction = (transform.position - point.transform.position).normalized*velocity;
        //transform.position += direction;
        //if ((old - transform.position).magnitude >= (old - point.transform.position).magnitude)
        //    level--;
    }
}
