using UnityEngine;
using System.Collections;
using RoundedDefence;

public class CameraZoom : MonoBehaviour {

    GameObject zoomBar;
    GameObject point;
    float minZoomBar = 0.1f;
    float maxZoomBar = 0.95f;
    public Camera Cam;
    public Vector3 target;
    private Vector3 old;
    public float maxZoom;
    public float minZoom;
    public int direction;
    public float magnitude;
    public static bool pointClicked;
    int smooth = 8;
//    private bool isZoomed = false;

	// Use this for initialization
	void Start () {
        zoomBar = GameObject.Find("pseudozoom");
        zoomBar.AddComponent<PointZoom>();
        point = new GameObject("point");
        SpriteRenderer sprRenderer = point.AddComponent<SpriteRenderer>();
        Lib.setSprite(point, "Sprites/Misc/pointzoom");
        sprRenderer.sortingLayerName = "Shots";
        point.transform.position = new Vector3(zoomBar.renderer.bounds.max.x, zoomBar.renderer.bounds.max.y, zoomBar.renderer.bounds.max.z);
        direction = 1;
        magnitude = camera.orthographicSize;
        old = target;
	}
	
	// Update is called once per frame
    void Update()
    {
        camera.transform.position = old;
        point.transform.position = new Vector3(zoomBar.transform.position.x, zoomBar.renderer.bounds.max.y, zoomBar.renderer.bounds.max.z-.2f);
        float value = ((minZoom - camera.orthographicSize) / (maxZoom - minZoom));
        if (value < -1) value = -1;
        if (value > 0) value = 0;
        point.transform.Translate(new Vector3(0, -zoomBar.renderer.bounds.size.y * minZoomBar + value * zoomBar.renderer.bounds.size.y * (maxZoomBar - minZoomBar), 0));
        if (pointClicked)
        {
            if (Lib.mouseCord(Cam).y <= zoomBar.renderer.bounds.max.y - zoomBar.renderer.bounds.size.y * minZoomBar //1.2
                && Lib.mouseCord(Cam).y >= zoomBar.renderer.bounds.max.y - zoomBar.renderer.bounds.size.y * maxZoomBar) //-0.8
                camera.orthographicSize = -((Lib.mouseCord(Cam).y - zoomBar.renderer.bounds.max.y + zoomBar.renderer.bounds.size.y * minZoomBar) / (zoomBar.renderer.bounds.size.y * (maxZoomBar - minZoomBar)) * (maxZoom - minZoom) - minZoom);
            if (Lib.mouseCord(Cam).y > zoomBar.renderer.bounds.max.y - zoomBar.renderer.bounds.size.y * minZoomBar)
                camera.orthographicSize = minZoom;

            if (Lib.mouseCord(Cam).y < zoomBar.renderer.bounds.max.y - zoomBar.renderer.bounds.size.y * maxZoomBar)
                camera.orthographicSize = maxZoom;
            magnitude = camera.orthographicSize;
        }
        else if (Input.GetKey("c"))
        {
            direction = 1;
        }
        else if (Input.GetKey("v"))
        {
            direction = -1;
        }
        else direction = 0;
        magnitude += 0.2f*direction;
        if (magnitude > maxZoom +1f) magnitude = maxZoom+1f;
        if (magnitude < minZoom) magnitude = minZoom;
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, magnitude, Time.deltaTime * smooth);
        if (camera.orthographicSize > maxZoom) { camera.orthographicSize = maxZoom; magnitude = maxZoom; }
        old = camera.transform.position;
        camera.transform.position = new Vector3(0, 0, camera.transform.position.z) + (new Vector3(target.x, target.y, 0)) * (maxZoom - camera.orthographicSize) / (maxZoom - minZoom);
    }
}
