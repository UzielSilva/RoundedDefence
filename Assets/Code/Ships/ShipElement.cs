using UnityEngine;
using System;
using System.Collections;
using RoundedDefence.Components.Ships;
using RoundedDefence;

public class ShipElement : MonoBehaviour {
    public String id;
    public Int16 angle;
    float radius = 2.3f;
    IShip thisShip;
    Vector3 normal;
    Vector3 init;
    float timer;
	
    // Use this for initialization
	void Start () {

        thisShip = Lib.Ships[id];
        transform.position = new Vector3(radius * Mathf.Cos(angle * Mathf.PI / 180), radius * Mathf.Sin(angle * Mathf.PI / 180), 0);
        transform.Rotate(Vector3.forward, 90 + angle);
        SpriteRenderer sprRenderer = GetComponent<SpriteRenderer>();
        sprRenderer.sprite = Resources.Load<Sprite>("Sprites/Ships/" + thisShip.Image);
        renderer.sortingLayerName = "Ships";
        normal = transform.position.normalized;
        init = transform.position;
        timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float velocity = 0.05f;
        float currentTime = Time.time - timer;
        transform.position = new Vector3(init.x - normal.x * currentTime * velocity, init.y - normal.y * currentTime * velocity, init.z - normal.z * currentTime * velocity);
	
	}
}
