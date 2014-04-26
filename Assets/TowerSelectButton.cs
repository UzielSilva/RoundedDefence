using UnityEngine;
using System.Collections;
using RoundedDefence;

public class TowerSelectButton : MonoBehaviour {

	private bool on;
	private bool click;
	// Use this for initialization
	void Start () {
		on = false;
		click = false;
	}
	
	// Update is called once per frame
	void Update () {
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
