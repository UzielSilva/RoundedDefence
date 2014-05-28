using System;
namespace RoundedDefence.Components.Ships.Types
{
	public class Raya:Ship
	{
        public static string image = "Raya/Raya";
        public static string id = "ray";
        public Raya()
            : base(id, image)
        {
            Point start = Position;
			life = getTotalLife();
			//start = Lib.toTiles (start);
			//setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
	}
}

