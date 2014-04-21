using UnityEngine;
using System.Collections;
using RoundedDefence;

public class Button : MonoBehaviour {
	public Sprite unpress;
	public Sprite press;
	public Sprite pressed;
	private bool on;
	private bool click;
	SpriteRenderer sprRenderer;
	// Use this for initialization
	void Start () {
		on = false;
		click = false;
		sprRenderer = (SpriteRenderer)renderer;
	}
	
	// Update is called once per frame
	void Update () {
		if (on == true) {
			sprRenderer.sprite = press;
			if(click== true){
				sprRenderer.sprite = pressed;
			}
			on=false;
		} else {
			sprRenderer.sprite=unpress;
			click=false;
		}
	}
	
	void OnMouseOver()
	{
		on = true;
		if (click == true && Input.GetMouseButtonUp (0)) {
			click=false;
			clickSound ();
			transform.Translate(new Vector3(0,0,1f));

		}
		if (Input.GetMouseButtonDown (0))
			click = true;
	}
	
	private void clickSound(){
		GameObject gm=GameObject.Find("_GM");
		gm.audio.clip=Lib.clickClip;
		if(Lib.sound)
			gm.audio.Play ();
	}
}
