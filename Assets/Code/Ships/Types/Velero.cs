using System;

namespace RoundedDefence.Components.Ships.Types
{
	public class Velero:Ship
	{
        public static string image = "Velero";
        public static string id = "sailing";
        public Velero()
            : base(id, image)
        {
            Point start = Position;
			life = getTotalLife();
			start = Lib.toTiles (start);
			//setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
		public new string getname(){
			return "Barco velero";
		}
		public new string getDescription(){
			return "Los mas rapidos del mundo";
		}
		public new byte getType(){return 3;}
		public new byte getSpeed(){return 9;}
		public new double getBoost(){return .5;}
		public new double getDefence(){return .9;}
		public new  int getTotalLife(){return 30;}
	}
}

