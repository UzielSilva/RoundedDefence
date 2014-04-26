using System;

namespace RoundedDefence.Components.Ships.Types
{
	public class Guerra:Ship
	{
        public static string id = "warrior";
        public static string image = "";
        public Guerra()
            : base(id, image)
        {
			life = getTotalLife();
            Point start = Position;
			start = Lib.toTiles (start);
			//setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
	}
}

