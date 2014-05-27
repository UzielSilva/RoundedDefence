using UnityEngine;
using System;
using System.Collections;
using RoundedDefence.Components.Ships;
using RoundedDefence;

public class ShipElement : MonoBehaviour {
    public String id;
    public Int16 angle;
    public bool actualizePath;
    int level = 17;
    int blockAngle;
    int step;
    float radius = 4.1f;
    IShip thisShip;
    ShortPath p;
    Vector3 normal;
    Vector3 init;
    float timer;

    // Use this for initialization
    void Start()
    {
        PointMapListener.OnClicked += SetNewPath;
        thisShip = (IShip)Activator.CreateInstance(Lib.Ships[id].GetType());
        blockAngle = Lib.toTiles(new Point(level, angle)).Y;
        p = new ShortPath(level, blockAngle, 0, 0);
        p.costMap = PointMapListener.costMap;
        thisShip.Path = p.getPath();
        
        float initAngle = blockAngle * (360f / Lib.getNcircles(level));
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
    void SetNewPath()
    {
        if (blockAngle != null)
        {
            blockAngle = Lib.toTiles(new Point(level, angle)).Y;
            p = new ShortPath(level, blockAngle, 0, 0);
            p.costMap = PointMapListener.costMap;
            thisShip.Path = p.getPath();
            step = 1;
        }
    }
    void goToNextStep()
    {
        float velocity = 0.005f;
        float currentTime = Time.time - timer;
        Camino c = thisShip.Path.camino[thisShip.Path.camino.Count - step];
        GameObject point = GameObject.Find(String.Format("Point{0},{1}", c.lvl, c.p));
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
            step++;
            level = c.lvl;
            blockAngle = c.p;
        }
    }
}
