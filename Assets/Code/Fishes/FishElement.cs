using UnityEngine;
using System;
using System.Collections;
using RoundedDefence.Components.Fishes;
using RoundedDefence;

public class FishElement : MonoBehaviour {
    public int id;
    public Vector3 position;
    int step;
    float radius = 4.1f;
    IFish thisFish;
    ShortPath p;
    Vector3 normal;
    Vector3 init;
    float timer;

    // Use this for initialization
	void Start () {
        thisFish = (IFish)Activator.CreateInstance(Lib.Fishes[id].GetType());
        transform.position =  position;
       	//transform.Rotate(Vector3.forward, 90 + Lib.toAngle(angle));
        SpriteRenderer sprRenderer = GetComponent<SpriteRenderer>();
        sprRenderer.sprite = Resources.Load<Sprite>("Sprites/Towers/" + thisFish.Image);
        transform.localScale = (Vector3.one*0.1f);
        renderer.sortingLayerName = "Towers";

        normal = transform.position.normalized;
        init = transform.position;
        timer = Time.time;
        step = 1;
	}
	
	// Update is called once per frame
	void Update () {

        
	
	}
    void goToNextStep()
    {}
}
