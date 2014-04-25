using System;

namespace RoundedDefence.Components.Ships
{
	public class Zepelin:Ship
	{
        public static string image = "";
        public static string id = "zeppelin";
        public Zepelin(Point start)
        {
			life = getTotalLife();
			start = Lib.toTiles (start);
			setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
	}
}

