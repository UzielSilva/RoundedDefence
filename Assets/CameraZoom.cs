using UnityEngine;
using System.Collections;
using RoundedDefence;

public class CameraZoom : MonoBehaviour {

    public float maxZoom;
    public float minZoom;
    int smooth = 5;
    private bool isZoomed = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
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
