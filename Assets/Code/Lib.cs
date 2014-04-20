using System;
using UnityEngine;
using RoundedDefence.Components;
using System.Collections;
namespace RoundedDefence{
	public class Lib : MonoBehaviour{
		public static int tileHeight = 10;
		static GameObject fade;
		static float fader=0;
		static float fading=0;
		public static bool music=PlayerPrefs.GetInt("Music",1)==1;
		public static bool sound = PlayerPrefs.GetInt("Sound",1)==1;
		public static AudioClip clickClip = Resources.Load("Music/Sounds/Clicks/click25") as AudioClip;
		public static byte getNcircles(int rad) {
			byte frac = 2;
			while (rad > 2) {
					if (rad % 2 != 0)
							rad--;
					rad = rad / 2;
					frac++;
			}
			return (byte)Math.Pow (2.0, frac);
		}
		public static Point toTiles(Point p){
				return new Point (p.X / tileHeight, p.Y * getNcircles (p.X / tileHeight) / 360);
		}
		public static void mute(){
			if (music)
				muteMusic (false);
		}
		public static void muteSound(){
			sound = !sound;
			PlayerPrefs.SetInt("Sound",sound?1:0);
		}
		public static void muteMusic(bool mod){
			GameObject Obmusic = GameObject.Find ("Camera");
			if(Obmusic.audio.isPlaying)
				Obmusic.audio.Pause();
			else
				Obmusic.audio.Play();
			if (mod) {
					music = !music;
					PlayerPrefs.SetInt("Music",music?1:0);
			}
		}
		public static Level getLvl(int lvl){
			switch(lvl){
			case -1:return new LvlS1();
			case 1:return new Lvl1();
			case 2:return new Lvl2();
			case 3:return new Lvl3();
			default:	return null;
			}
		}
		public static Vector3 mouseCord(){
			Vector3 pos = Input.mousePosition ;
			pos.z = 10; // select distance = 10 units from the camera
			return Camera.main.ScreenToWorldPoint (pos);
		}
		public static void newFade(){
			fade = new GameObject("fade");
			fade.AddComponent<SpriteRenderer>();
			setSprite (fade,"Sprites/Background/fade");
			fade.renderer.sortingLayerName="Others";
			fade.renderer.sortingOrder = 200;
		}
		public static bool isFading(){
			return fading == 0;
		}
		public static bool isFadeReady(){
			return fader+.04f>1 && fading==0;
		}
		public static void unfades(){
			fading = -.04f;
			fader = 1f;
		}
		public static void fades(){
			fader=0f;
			fading=.04f;
		}
		public static void faderr(){
			fader += fading ;
			if (fader > 0f && fader < 1f) {
				if(fade!=null){
				Color c = fade.renderer.material.color;
				c.a = fader;
				fade.renderer.material.color = c;
				}
				Camera.main.audio.volume=1f-fader;
			} else {
				fading=0f;
				
			}
		}
		public static float height(){
			return 2f * Camera.main.orthographicSize ;
		}
		public static float width(){
			return 2f * Camera.main.orthographicSize * Camera.main.aspect;
		}
		public static void followCamera(GameObject obj){
			obj.transform.Translate(Camera.main.transform.position);
		}
		public static void setSprite(GameObject obj,string str){
			SpriteRenderer sprRenderer = (SpriteRenderer)obj.renderer;
			sprRenderer.sprite=Resources.Load<Sprite>(str) ;
		}
		public static int getStringLength(GameObject obj){
			TextMesh t = (TextMesh)obj.GetComponent(typeof(TextMesh));
			return t.text.Length;
		}
		public static void setString(GameObject obj,string str){
			TextMesh t = (TextMesh)obj.GetComponent(typeof(TextMesh));
			t.text=str;
		}
		public static GameObject newText(string str){
			GameObject obj= GameObject.Find (str);
			obj.renderer.sortingLayerName="Shots";
			return obj;
		}
	}
}

