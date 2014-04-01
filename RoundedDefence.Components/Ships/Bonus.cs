using System;

namespace RoundedDefence
{
	public class Bonus
	{
		public byte shield = 0;
		private byte tshield = 0;
		public byte speed = 0;
		private byte tspeed = 0;
		public byte boost = 0;
		private byte tboost = 0;
		public byte defence = 0;
		private byte tdefence = 0;
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
	}
}

