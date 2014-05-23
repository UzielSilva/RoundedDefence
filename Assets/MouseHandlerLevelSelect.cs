using UnityEngine;
using System.Collections;

public class MouseHandlerLevelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnMouseOver()
    {
        CameraZoom zoom = LevelSelect.GUI.GetComponent<CameraZoom>(); 
        if(Input.GetMouseButtonDown(0) )
        {
            IslandSelected.centroid = "";
            zoom.magnitude = zoom.maxZoom + 0.02f;
            IslandSelected selector1 = GameObject.Find("Selector1").GetComponent<IslandSelected>();
            IslandSelected selector2 = GameObject.Find("Selector2").GetComponent<IslandSelected>();
            selector1.transform.position = new Vector3 (0, -6, 0);
            selector2.transform.position = new Vector3(0, -6, 0);
        }
        
    }

	// Update is called once per frame
	void Update () {
	
	}
}
