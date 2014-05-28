using System;

namespace RoundedDefence.Components.Ships.Types
{
	public class RompeHielo:Ship
	{
        public static string image = "";
        public static string id = "icebreaker";
        public RompeHielo()
            : base(id, image)
        {
            Point start = Position;
			life = getTotalLife();
			//start = Lib.toTiles (start);
			//setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
	}
}

