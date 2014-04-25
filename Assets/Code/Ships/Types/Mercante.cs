using System;

namespace RoundedDefence.Components.Ships
{
	public class Mercante:Ship
	{
        public static string image = "";
        public static string id = "merchant";
        public Mercante(Point start)
        {
			life = getTotalLife();
			start = Lib.toTiles (start);
			setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
		public new string getname(){
			return "Barco Mercante";
		}
		public new string getDescription(){
			return "Sobreviven hasta en las hambrunas";
		}
		public new byte getType(){return 0;}
		public new byte getSpeed(){return 4;}
		public new int getTotalLife(){return 100;}
	}
}

