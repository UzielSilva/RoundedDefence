using UnityEngine;
using System.Collections;

public class TowerSelector : MonoBehaviour {

    public static int selected = 0;
    public static int idselected = 0;
	// Use this for initialization
	void Start () {
        renderer.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (idselected != 0)
        {
            GameObject towerSelected = GameObject.Find("Tower" + selected);
            transform.position = towerSelected.transform.position;
            renderer.enabled = true;
        }else renderer.enabled = false;
	}
}
