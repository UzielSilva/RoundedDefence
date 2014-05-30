using UnityEngine;
using System;
using System.Collections;
using System.Reflection;
using System.Linq;
using RoundedDefence.Components.Fishes;
using RoundedDefence.Components.Fishes.Actives;
using RoundedDefence.Components.Fishes.Linears;
using RoundedDefence.Components.Fishes.Radials;
using RoundedDefence.Components.Fishes.Roundeds;
using RoundedDefence.Components.Fishes.Statics;
using RoundedDefence.Components.Fishes.Targets;
using RoundedDefence;

public class FishElement : MonoBehaviour {
    public int id;
    public Vector3 position;
    int step;
    IFish thisFish;
    ShortPath p;
    Vector3 normal;
    Vector3 init;
    float timer;
    Vector3 center;
    delegate void FishBehaviour();
    event FishBehaviour ExecuteBehaviour;

    float radius;
    float angle;
    float speed;

    // Use this for initialization
	void Start () {
        thisFish = (IFish)Activator.CreateInstance(Lib.Fishes[id].GetType());
        if (typeof(ActiveFish).IsAssignableFrom(Lib.Fishes[id].GetType()))
            ExecuteBehaviour = activesActions;
        if (typeof(LinearFish).IsAssignableFrom(Lib.Fishes[id].GetType()))
        {
            ExecuteBehaviour = linearsActions;
        }
        if (typeof(RadialFish).IsAssignableFrom(Lib.Fishes[id].GetType()))
            ExecuteBehaviour = radialsActions;
        if (typeof(RoundedFish).IsAssignableFrom(Lib.Fishes[id].GetType()))
        {
            ExecuteBehaviour = roundedsActions;
            center = Vector3.zero;
            radius = Vector3.Distance(position, Vector3.zero);
            angle = 30;
        }
        if (typeof(StaticFish).IsAssignableFrom(Lib.Fishes[id].GetType()))
            ExecuteBehaviour = staticsActions;
        if (typeof(TargetFish).IsAssignableFrom(Lib.Fishes[id].GetType()))
            ExecuteBehaviour = targetsActions;
        transform.position =  position;
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

        ExecuteBehaviour();
	
	}
    void activesActions()
    { }
    void linearsActions()
    {
        
    }
    void radialsActions()
    { }
    void roundedsActions()
    {
        speed = (float)((RoundedFish)thisFish).Velocity*0.01f;
        angle += speed;
        angle = ((2 * Mathf.PI) + angle) % (Mathf.PI * 2);
        transform.position = new Vector3(center.x + (radius * Mathf.Cos(angle)), center.y + (radius * Mathf.Sin(angle)), 0f);
        transform.Rotate(Vector3.forward, speed * 180 / Mathf.PI);
    
    }
    void staticsActions()
    { }
    void targetsActions()
    { }
}
