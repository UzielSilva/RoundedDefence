using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    int smooth = 5;
    private bool isZoomed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("c"))
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 0.5f, Time.deltaTime * smooth);
        }
        if (Input.GetKey("v"))
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 5f, Time.deltaTime * smooth);
        }
	}
}
