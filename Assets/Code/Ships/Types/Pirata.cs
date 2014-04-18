using System;

namespace RoundedDefence
{
	public class Pirata:Ship
	{
		public Pirata (Point start)
		{
			life = getTotalLife();
			start = Lib.toTiles (start);
			setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
		public new string getname(){
			return "Barco Pirata";
		}
		public  new string getDescription(){
			return "Nunca discutas con un pirata, solo perderas tiempo.";
		}
		public new byte getType(){return 2;}
		public new byte getSpeed(){return 4;}
		public new int getTotalLife(){return 40;}

	}
}

