using System;

namespace RoundedDefence.Components.Ships
{
	public class RompeHielo:Ship
	{
        public static string id = "icebreaker";
        public RompeHielo(Point start)
        {
			life = getTotalLife();
			start = Lib.toTiles (start);
			setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
	}
}

