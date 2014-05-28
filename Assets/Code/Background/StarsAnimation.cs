using UnityEngine;
using System.Collections;

public class StarsAnimation : MonoBehaviour {
	public Sprite sprite;
    public Camera cam1;
	public Camera cam2;
	public Font font;
	public Material material;
	// Use this for initialization
	void Start () {
		for (int i=0; i<200; i++) {
			GameObject gameObject = new GameObject("Star"+i);
			TextMesh t=gameObject.AddComponent<TextMesh>();
			t.font=font;
			t.fontSize = 34;
			MeshRenderer m=GetComponent<MeshRenderer>();
			m.material = material;
			gameObject.AddComponent<SpriteRenderer>();
			Star s = gameObject.AddComponent<Star>();
            s.cam1 = cam1;
            s.cam2 = cam2;
			SpriteRenderer sprRenderer= (SpriteRenderer)gameObject.renderer; 
			sprRenderer.sprite=sprite;
		}
	}

}
