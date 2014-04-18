using System;
using UnityEngine;
using RoundedDefence.Components;
using System.Collections;
namespace RoundedDefence{
	public class Lib : MonoBehaviour{
	public static int tileHeight = 10;
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

	}
}

