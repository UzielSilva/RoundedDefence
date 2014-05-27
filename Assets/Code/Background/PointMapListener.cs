using UnityEngine;
using System.Collections;
using RoundedDefence;

public class PointMapListener : MonoBehaviour {
    GameObject shadow;
    bool over;
	// Use this for initialization
	void Start () {
        over = false;
	}

    void OnMouseOver () {
        over = true;
        if (TowerSelector.idselected != 0)
        {
            renderer.enabled = true;
            if (Input.GetMouseButtonDown(0))
            {
                GameObject fish = new GameObject(name + "fish");
                fish.transform.position = transform.position;
                fish.AddComponent<SpriteRenderer>();
                Lib.setSprite(fish, "Sprites/Towers/" + Lib.Fishes[TowerSelector.idselected].Image);
                fish.transform.localScale = (new Vector3(1,1,1))*0.05f;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(!over)
            renderer.enabled = false;
        over = false;
	}
}
