using UnityEngine;
using System.Collections;
using RoundedDefence;
using RoundedDefence.Components;

public class LevelSelect : MonoBehaviour {
	public static int lvlSelected=0;
	public static Level level;
	
	GameObject fade;
	GameObject musica;
	GameObject sound;

	GameObject msg;
	GameObject score;
	GameObject starText;
	GameObject starStar;
	GameObject starScore;
	
	GameObject back;
	GameObject play;
	GameObject hudbar;
	
	Camera cam ;
	float height;
	float width ;
	float fader=0;
	float fading=0;
	int txt=0;
	int txt2=0;
	// Use this for initialization
	void Start () {
		Lib.mute ();
		fade = GameObject.Find ("fade");
		musica = GameObject.Find ("musica");
		sound = GameObject.Find ("sound");

		play = GameObject.Find ("play");
		back = GameObject.Find ("back");
		hudbar = GameObject.Find ("hudbar");
		
		starText = GameObject.Find ("starsText");
		msg = GameObject.Find ("msg");
		score = GameObject.Find ("score");
		starStar = GameObject.Find ("starStars");
		starScore = GameObject.Find ("starScore");
		score.renderer.sortingLayerName="Shots";
		msg.renderer.sortingLayerName="Shots";
		starText.renderer.sortingLayerName="Shots";    
		TextMesh t = (TextMesh)starText.GetComponent(typeof(TextMesh));
		t.text = PlayerPrefs.GetInt("TotalStars",0)+"";
		lvlSelected = 0;
		cam=Camera.main;
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		Update ();
		fading = -.04f;
		fader = 1f;
	}
	void Update(){
		if (fading == 0) {
			Vector3 move=new Vector3(0,0,0);
			play.transform.position=move;
			score.transform.position=move;
			starScore.transform.position=move;
			drawDescription ();
			height = 2f * cam.orthographicSize;
			width = height * cam.aspect;
			if (back.transform.position.z == 1) {
				fader=0f;
				fading=.04f;
			}
			if(fader+.04f>1)
				Application.LoadLevel ("mainMenu");
			musica.transform.position=new Vector3(width/2f ,height/2f,10f);
			sound.transform.position=new Vector3(width/2f - .5f,height/2f -.05f,10f);
			starStar.transform.position=new Vector3(-width/2f+.2f,height/2f-.17f,10f);
			starText.transform.position=new Vector3(-width/2f +.4f,height/2f-.04f,10f);
			back.transform.position=new Vector3(-width/2f +1f,-height/2f+.6f,10f);
			hudbar.transform.position=new Vector3(0,-height/2f +.4f,10f);

			msg.transform.position=new Vector3(txt*-.08f,-height/2f+1f,10f);

			score.transform.Translate(new Vector3((txt2*-.057f)+.2f,-height/2f+.6f,0f));
          	starScore.transform.Translate(new Vector3((txt2*-.057f),-height/2f+.45f,0f));
            play.transform.Translate(new Vector3(width/2f -1f,-height/2f+.6f,0f));
			
			musica.transform.Translate(cam.transform.position);
			hudbar.transform.Translate(cam.transform.position);
			sound.transform.Translate(cam.transform.position);
			starStar.transform.Translate(cam.transform.position);
			starText.transform.Translate(cam.transform.position);
			back.transform.Translate(cam.transform.position);
			msg.transform.Translate(cam.transform.position);
			play.transform.Translate(cam.transform.position);
			score.transform.Translate(cam.transform.position);
			starScore.transform.Translate(cam.transform.position);
		} else {
			faderr ();
		}
	}
	void drawDescription(){
		TextMesh t = (TextMesh)msg.GetComponent(typeof(TextMesh));
		if (lvlSelected != 0 && level!=null) {
			bool enabledd=PlayerPrefs.GetInt("LvlUnlocked",1)>=level.getLvlNumb();
			if(enabledd){
				enabledd=PlayerPrefs.GetInt("TotalStars",0)>=level.getMinStars();
				if(enabledd){
					drawStats ();
				}else{
					t.text ="YOU NEED "+level.getMinStars()+" STARS TO PLAY";
					}
			}else{
				t.text ="PASS LEVEL "+(lvlSelected-1)+" TO PLAY";
			}
		} else {
			t.text ="SELECT A LEVEL";
		}
		txt=t.text.Length;
	}
	void drawStats(){
		TextMesh t = (TextMesh)msg.GetComponent(typeof(TextMesh));
		TextMesh t2 = (TextMesh)score.GetComponent(typeof(TextMesh));
		SpriteRenderer sprRenderer = (SpriteRenderer)starScore.renderer;
		t.text = "SCORE : " + level.getScore ();
		if(level.getScore()<level.getOneStar()){
			sprRenderer.sprite=Resources.Load<Sprite>("Sprites/Misc/star1") ;
			t2.text = "at "+level.getOneStar();
		}else if(level.getScore()<level.getTwoStar()){
			sprRenderer.sprite=Resources.Load<Sprite>("Sprites/Misc/star2") ;
			t2.text = "at "+level.getTwoStar();
		}else if(level.getScore()<level.getThreeStar()){
			sprRenderer.sprite=Resources.Load<Sprite>("Sprites/Misc/star3");
			t2.text = "at "+level.getThreeStar();
		}else{
		}
		txt=t.text.Length;
		txt2=t2.text.Length;
		Vector3 move=new Vector3(0,0,10);
		play.transform.position=move;
		score.transform.position=move;
		starScore.transform.position=move;
	}

	void faderr(){
		fader += fading ;
		if (fader > 0f && fader < 1f) {
			Color c = fade.renderer.material.color;
			c.a = fader;
			fade.renderer.material.color = c;
			cam.audio.volume=1f-fader;
		} else {
			fading=0f;
			
		}
	}

}
