using System;
using System.Drawing;

namespace RoundedDefence
{
	public class Pesquero :Ship
	{
		public Pesquero (Point start)
		{
			life = getTotalLife();
			start = Lib.toTiles (start);
			setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
		public new string getname(){
			return "Barco Pesquero";
		}
		public  new string getDescription(){
			return "Uno de los barcos mas comunes.";
		}
		public  new byte getType(){
			return 1;
		}
		public  new byte getSpeed(){
			return 3;
		}
		public new int getBonus(){
			return 0;
		}
		public new int getShield(){
			return 0;
		}
		public new int getTotalLife(){
			return 20;
		}

		public new void move(){
		}
		public new void kill(){
		}
	}
}

