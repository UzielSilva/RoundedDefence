using System;

namespace RoundedDefence.Components.Ships
{
	public class Pasajero:Ship
	{
        public static string image = "";
        public static string id = "passenger";
        public Pasajero(Point start)
        {
			life = getTotalLife();
			start = Lib.toTiles (start);
			setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
	}
}

