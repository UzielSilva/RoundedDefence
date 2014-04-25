using System;
namespace RoundedDefence.Components.Ships
{
	public class Petrolero:Ship
	{
        public static string image = "";
        public static string id = "oiler";
        public Petrolero(Point start)
        {
			life = getTotalLife();
			start = Lib.toTiles (start);
			setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
	}
}

