using UnityEngine;
using System.Collections;
using RoundedDefence;

public class ShowAndHide : MonoBehaviour {
	float fade;
	public float speed;
	public int delay;
	public string txt;
	public Font font;
	public Material material;
	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3 (.1f, .1f, 1f);
		TextMesh t=gameObject.AddComponent<TextMesh>();
		t.font=font;
		t.fontSize = 34;
		MeshRenderer m=GetComponent<MeshRenderer>();
		m.material = material;
		Lib.newText (name);
		Lib.setString (gameObject, txt);
		transform.position = new Vector3 (txt.Length*-.08f,.2f,-9f);
		fade = 0f;
		Color c = renderer.material.color;
		c.a = fade;
		renderer.material.color = c;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (txt.Length*-.08f,-.2f,-9f);
		if((speed>0&&delay>0)||(speed<0&&delay==0))
		fade += speed;
		if (fade > 1f) {
			fade=1f;
			speed=-speed;
		}
		if (fade == 1f&& delay>0)
			delay--;
		if (delay == 0 && fade < 0) {
			fade=0;
			Destroy (this.gameObject);
				}

			Color c = renderer.material.color;
			c.a = fade;
			renderer.material.color = c;

	}
}
