using System;

namespace RoundedDefence.Components.Ships.Types
{
	public class Submarino:Ship
	{
        public static string image = "Submarino";
        public static string id = "submarine";
        public Submarino()
            : base(id, image)
        {
            Point start = Position;
			life = getTotalLife();
			start = Lib.toTiles (start);
			//setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
	}
}

