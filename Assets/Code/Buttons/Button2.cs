using UnityEngine;
using System.Collections;
using RoundedDefence;

public class Button2 : MonoBehaviour {
	public Sprite unpress;
	public Sprite pressed;
	public int type;
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
		bool select = false;
		if(type==0){
			select=Lib.sound;
		}else{
			select=Lib.music;
		}
		if (select == true) {
			sprRenderer.sprite = unpress;
		} else {
			sprRenderer.sprite=pressed;
		}
		if (on == true) {
			on=false;
		} else {
			click=false;
		}
	}
	
	void OnMouseOver()
	{
		on = true;
		if (click == true && Input.GetMouseButtonUp (0)) {
			click=false;
			on=false;
			if(type==0){
				Lib.muteSound();
			}else{
				Lib.muteMusic(true);
			}
			
		}
		if (Input.GetMouseButtonDown (0))
			click = true;
	}
}
