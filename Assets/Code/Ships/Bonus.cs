using System;

namespace RoundedDefence
{
	public class Bonus
	{
		public byte shield = 0;
		private int tshield = 0;
		public byte speed = 0;
		private int tspeed = 0;
		public byte boost = 0;
		private int tboost = 0;
		public byte defence = 0;
		private int tdefence = 0;
		public Bonus ()
		{
		}
		public void update(){
			if (tshield != 0)
				tshield--;
			else
				shield = 0;

			if (tspeed != 0)
				tspeed--;
			else
				speed = 0;

			if (tboost != 0)
				tboost --;
			else
				boost = 0;

			if (tdefence != 0)
				tdefence--;
			else
				defence = 0;
		}
		public void addShield (byte i,int t){
			if (shield < i){
				shield = i;
				tshield=t;
			}
		}
		public void addDefence (byte i,int t){
			if (defence < i){
				defence = i;
				tdefence=t;
			}
		}
		public void addSpeed (byte i,int t){
			if (speed < i){
				speed = i;
				tspeed=t;
			}
		}
		public void addBoost (byte i,int t){
			if (boost < i){
				boost = i;
				tboost=t;
			}
		}
			
	}
}

