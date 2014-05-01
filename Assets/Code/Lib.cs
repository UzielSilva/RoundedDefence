using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using RoundedDefence.Components.Levels;
using RoundedDefence.Components.Ships;
using System.Collections;
using System.Xml.Linq;

namespace RoundedDefence{
	public class Lib : MonoBehaviour{
		public static XDocument data;
        public static Dictionary<String, IShip> Ships;
		public static XElement currentLevel;
		public static int tileHeight = 10;
		static GameObject fade;
		static float fader=0;
		static float fading=0;
		public static bool music=PlayerPrefs.GetInt("Music",1)==1;
		public static bool sound = PlayerPrefs.GetInt("Sound",1)==1;
		public static AudioClip clickClip = Resources.Load("Music/Sounds/Clicks/click25") as AudioClip;

		public static void setCurrentLevel(string classlevel, int world, int levelnum){
			var q = from t in data.Element(XName.Get("levels")).Elements(XName.Get("level"))
				where t.Attribute(XName.Get("class")).Value == classlevel
                    && t.Attribute(XName.Get("world")).Value == world.ToString()
                    && t.Attribute(XName.Get("levelnum")).Value == levelnum.ToString()
					select t;
			currentLevel = q.ToArray()[0];
		}

        public static XElement getLevel(string classlevel, int world, int levelnum)
        {
            var q = from t in data.Element(XName.Get("levels")).Elements(XName.Get("level"))
                    where t.Attribute(XName.Get("class")).Value == classlevel
                        && t.Attribute(XName.Get("world")).Value == world.ToString()
                        && t.Attribute(XName.Get("levelnum")).Value == levelnum.ToString()
                    select t;
            return q.ToArray()[0];
        }

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
				//return new Point (p.X / tileHeight, p.Y * getNcircles (p.X / tileHeight) / 360);
            return null;
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
        static float time = 0;
        static float initTime = 0;
        static float duration = 0.5f;
        static Vector3 originPosition;
        public static void cameraFollow(GameObject obj)
        {
            Camera.main.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, Camera.main.transform.position.z);
        }
        public static bool smoothCameraFollow(GameObject target)
        {
            if (initTime == 0)
            {
                initTime = Time.time;
                originPosition = Camera.main.transform.position;
            }
            float currentTime = Time.time - initTime;
            if (currentTime < duration)
            {
                Vector3 distance = target.transform.position - originPosition;
                float factor = (1 - Mathf.Cos(currentTime * Mathf.PI / duration))/2;
                distance = distance * factor;
                Vector3 objective = originPosition + distance;
                Camera.main.transform.position = new Vector3(objective.x, objective.y, Camera.main.transform.position.z);
                return false;
            }
            else
            {
                initTime = 0;
                return true;
            }
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
		public static void MakeGrayscale( Texture2D tex) {
			var texColors = tex.GetPixels();
			for (int i = 0; i < texColors.Length; i++) {
				var grayValue = texColors[i].grayscale;
				texColors[i] =new Color(grayValue, grayValue, grayValue, texColors[i].a);
			}
			tex.SetPixels(texColors);
			tex.Apply();
		}
	}
}

