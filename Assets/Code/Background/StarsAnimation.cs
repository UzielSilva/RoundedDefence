using UnityEngine;
using System.Collections;

public class StarsAnimation : MonoBehaviour {
	public Sprite sprite;
    public Camera cam;
	// Use this for initialization
	void Start () {
		for (int i=0; i<200; i++) {
			GameObject gameObject = new GameObject("Star"+i);
			gameObject.AddComponent<SpriteRenderer>();
			Star s = gameObject.AddComponent<Star>();
            s.cam = cam;
			SpriteRenderer sprRenderer= (SpriteRenderer)gameObject.renderer; 
			sprRenderer.sprite=sprite;
		}
	}

}
