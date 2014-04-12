using System;

namespace RoundedDefence.Components
{
	public class Lvl1:Level
	{
		public Lvl1 (){
			waves.Add (new Wave (22,0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 9, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0));
		}
		public new Boolean hasPesquero(){return true;}

		public new int getOneStar(){return 100;}
		public new int getTwoStar(){return 300;}
		public new int getThreeStar(){return 500;}
	}
}

