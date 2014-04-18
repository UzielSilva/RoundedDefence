using UnityEngine;
using System.Collections;
using RoundedDefence.Components;
using RoundedDefence;

public class LvlSelect : MonoBehaviour {
	public int lvlNumb=0;
	private bool enabledd=false;
	public Sprite Image1;
	public Sprite Image2;
	public Level level;
	// Use this for initialization
	void Start () {
		level=Lib.getLvl(lvlNumb);

		setTexture ();
		if(enabledd)
		setStars ();
	}
	void star(Sprite sprite,int lvl){
		GameObject gameObject = new GameObject("Star"+lvlNumb+"-"+lvl);
		gameObject.AddComponent<SpriteRenderer>();
		SpriteRenderer sprRenderer= (SpriteRenderer)gameObject.renderer; 
		sprRenderer.sprite=sprite;
		sprRenderer.sortingLayerName = "Ships";
		sprRenderer.sortingOrder = lvl;
		gameObject.transform.position = transform.position;
		gameObject.transform.rotation = transform.rotation;
		Vector3 move = new Vector3 (Mathf.Cos(Mathf.PI/180*(225+(lvl*30)))*0.6f, 
		                            Mathf.Sin(Mathf.PI/180*(225+(lvl*30)))*0.6f, 0);
		gameObject.transform.Translate (move, Space.World); 
	}
	// Update is called once per frame
	void Update () {
	
	} 
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0)) {
			LevelSelect.lvlSelected=lvlNumb;
			LevelSelect.level=level;
			GameObject gm=GameObject.Find("_GM");
			gm.audio.clip=Lib.clickClip;
			if(Lib.sound)
			gm.audio.Play ();
		}
	}
	void setTexture(){
		SpriteRenderer sprRenderer= (SpriteRenderer)renderer;
		enabledd=PlayerPrefs.GetInt("LvlUnlocked",1)>=lvlNumb&&PlayerPrefs.GetInt("TotalStars",0)>=level.getMinStars();
		if (enabledd) {
			sprRenderer.sprite = Image1;	
		} else {
			sprRenderer.sprite = Image2;
		}
	}
	void setStars(){
		if(level.getScore()>=level.getOneStar())
			star (Resources.Load<Sprite>("Sprites/Misc/star1"),0);
		else
			star (Resources.Load<Sprite>("Sprites/Misc/nostar"),0);
		if(level.getScore()>=level.getTwoStar())
			star (Resources.Load<Sprite>("Sprites/Misc/star2"),1);
		else
			star (Resources.Load<Sprite>("Sprites/Misc/nostar"),1);
		if(level.getScore()>=level.getThreeStar())
			star (Resources.Load<Sprite>("Sprites/Misc/star3"),2);
		else
			star (Resources.Load<Sprite>("Sprites/Misc/nostar"),2);
		if(0!=level.getAllStar())
			star (Resources.Load<Sprite>("Sprites/Misc/star4"),3);
		else
			star (Resources.Load<Sprite>("Sprites/Misc/nostar"),3);

		}
}
