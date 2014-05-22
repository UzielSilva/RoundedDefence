using UnityEngine;
using System.Collections;
using RoundedDefence;

public class CameraZoom : MonoBehaviour {

    GameObject zoomBar;
    GameObject point;
    public float maxZoom;
    public float minZoom;
    int smooth = 5;
    private bool isZoomed = false;

	// Use this for initialization
	void Start () {
        zoomBar = GameObject.Find("pseudozoom");
        point = new GameObject("point");
        SpriteRenderer sprRenderer = point.AddComponent<SpriteRenderer>();
        Lib.setSprite(point, "Sprites/Misc/point");
        sprRenderer.sortingLayerName = "Shots";
        point.transform.position = new Vector3(zoomBar.renderer.bounds.max.x, zoomBar.renderer.bounds.max.y, zoomBar.renderer.bounds.max.z);

	}
	
	// Update is called once per frame
    void Update()
    {
        point.transform.position = new Vector3(zoomBar.transform.position.x, zoomBar.renderer.bounds.max.y, zoomBar.renderer.bounds.max.z);
        float value = ((minZoom - camera.orthographicSize) / (maxZoom - minZoom));
        if (value < -1) value = -1;
        if (value > 0) value = 0;
        point.transform.Translate(new Vector3(0, -zoomBar.renderer.bounds.size.y * 0.05f + value * zoomBar.renderer.bounds.size.y * 0.9f, 0));
        if (Input.GetKey("c"))
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, minZoom, Time.deltaTime * smooth);
        }
        if (Input.GetKey("v"))
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, maxZoom, Time.deltaTime * smooth);
        }
	}
}
