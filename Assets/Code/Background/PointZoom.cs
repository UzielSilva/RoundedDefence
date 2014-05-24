using UnityEngine;
using System.Collections;

public class PointZoom : MonoBehaviour {

    bool pointOver = false;
    bool value = false;
	// Use this for initialization
	void Start () {
	
	}

    void OnMouseOver()
    {
        pointOver = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (pointOver && Input.GetMouseButton(0))
            value = true;
        if (!Input.GetMouseButton(0))
            value = false;
        CameraZoom.pointClicked = value;
        pointOver = false;
	}
}
