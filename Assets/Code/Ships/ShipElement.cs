using UnityEngine;
using System;
using System.Collections;
using RoundedDefence.Components.Ships;
using RoundedDefence;

public class ShipElement : MonoBehaviour {
    public String id;
    public Int16 angle;
    int step;
    float radius = 4.1f;
    IShip thisShip;
    ShortPath p;
    Vector3 normal;
    Vector3 init;
    float timer;

    GameObject lifeBar;
    GameObject life;

    // Use this for initialization
	void Start () {
        PointMapListener.OnClicked += SetNewPath;
        thisShip = (IShip)Activator.CreateInstance(Lib.Ships[id].GetType());
        ShortPath p = new ShortPath(angle, 13, Lib.map);
        thisShip.Path = p.getPath(); 
        transform.position =  Lib.toCords(angle);
       	transform.Rotate(Vector3.forward, 90 + Lib.toAngle(angle));
        SpriteRenderer sprRenderer = GetComponent<SpriteRenderer>();
        sprRenderer.sprite = Resources.Load<Sprite>("Sprites/Ships/" + thisShip.Image);
        renderer.sortingLayerName = "Ships";
        gameObject.AddComponent<CircleCollider2D>();
        Rigidbody2D theCollider = gameObject.AddComponent<Rigidbody2D>();
        theCollider.gravityScale = 0;
        theCollider.isKinematic = false;
        normal = transform.position.normalized;
        init = transform.position;
        timer = Time.time;
        step = 1;

        lifeBar = new GameObject(name + "LifeBar");
        SpriteRenderer spr = lifeBar.AddComponent<SpriteRenderer>();
        Lib.setSprite(lifeBar, "Sprites/Misc/barhp_case1");
        spr.sortingLayerName = "Shots";
        lifeBar.transform.localScale = Vector3.one*0.3f;
        lifeBar.transform.position = transform.position + new Vector3(0, 0.2f, 0);

        life = new GameObject(name + "Life");
        SpriteRenderer spr2 = life.AddComponent<SpriteRenderer>();
        Lib.setSprite(life, "Sprites/Misc/barhp_life1");
        spr2.sortingLayerName = "Shots";
        spr2.sortingOrder = 10;
        life.transform.localScale = Vector3.one * 0.3f;
        life.transform.position = transform.position + new Vector3(0, 0.2f, 0);
	}
	
	// Update is called once per frame
	void Update () {

        rigidbody2D.velocity = Vector3.zero;
        rigidbody2D.angularVelocity = 0;

        lifeBar.transform.position = transform.position + new Vector3(0, 0.2f, 0);
        life.transform.position = transform.position + new Vector3(0, 0.2f, 0);

       if (step < thisShip.Path.camino.Count)
						goToNextStep ();
				else
						Lib.kill ();
	
	}
    void SetNewPath()
     {
        Camino c = thisShip.Path.camino[thisShip.Path.camino.Count - step];
        ShortPath p = new ShortPath(c.lvl, 13, Lib.map);
        thisShip.Path = p.getPath();
        step = 1;
     }
    void goToNextStep()
    {

        float velocity = 0.01f;
        float currentTime = Time.time - timer;
        Camino c = thisShip.Path.camino[thisShip.Path.camino.Count - step];
		GameObject point =GameObject.Find(String.Format("Point{0}", c.lvl));
        Vector3 old = transform.position;
        Vector3 direction = (point.transform.position - transform.position).normalized;
        if (point.transform.position != transform.position)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            if (direction.y > 0 && direction.y <= 1)
                transform.Rotate(Vector3.forward, 90 + 360 - 180 * Mathf.Acos(Vector3.Dot(new Vector3(-1, 0, 0), direction)) / Mathf.PI);
            else
                transform.Rotate(Vector3.forward, 90 + 180 * Mathf.Acos(Vector3.Dot(new Vector3(-1, 0, 0), direction)) / Mathf.PI);
        }
        direction = direction * velocity;
        transform.position += direction;
        if ((old - transform.position).magnitude >= (old - point.transform.position).magnitude
            || point.transform.position == transform.position)
        {
			transform.rotation=new Quaternion(0,0,0,0);
			transform.Rotate(Vector3.forward, 90 + Lib.toAngle(c.lvl));
            step++;
        }
    }
    public void hit(double damage)
    {
        thisShip.Hit((double)damage);
        float currentlife = thisShip.Life;
        float fullLife = thisShip.FullLife;
        if (currentlife <= 0)
        {
            Destroy(gameObject);
            Destroy(lifeBar);
            Destroy(life);
        }
        life.transform.localScale = new Vector3(life.transform.localScale.x * (currentlife / fullLife), life.transform.localScale.y, life.transform.localScale.z);
    }
}
