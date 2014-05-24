using UnityEngine;
using System.Collections;

public class TowerOption : MonoBehaviour {

    public int id;
    public int option;
	// Use this for initialization
	void Start () {
	
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TowerSelector.idselected != id)
            {
                TowerSelector.selected = option;
                TowerSelector.idselected = id;
            }
            else
            {
                TowerSelector.selected = 0;
                TowerSelector.idselected = 0;

            }
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
