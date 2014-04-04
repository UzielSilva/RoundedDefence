using System;
using System.Drawing;

namespace RoundedDefence.Components
{
	public class Mercante:Ship
	{
		public Mercante (Point start){
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
		public new byte getType(){return 5;}
		public new byte getSpeed(){return 4;}
		public new int getTotalLife(){return 100;}
	}
}

