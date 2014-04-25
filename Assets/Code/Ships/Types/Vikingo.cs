using System;

namespace RoundedDefence.Components.Ships
{
	public class Vikingo:Ship
	{
        public static string image = "";
        public static string id = "viking";
        public Vikingo(Point start)
        {
			life = getTotalLife();
			start = Lib.toTiles (start);
			setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
		public new string getname(){
			return "Barco Vikingo";
		}
		public  new string getDescription(){
			return "Solo los mas resistentes sobreviven.";
		}
		public new byte getType(){return 4;}
		public new byte getSpeed(){return 3;}
		public new double getBoost(){return .9;}
		public new double getDefence(){return 1.5;}
		public new int getTotalLife(){return 50;}

	}
}

