using System;

namespace RoundedDefence.Components.Ships
{
	public class Guerra:Ship
	{
        public static string id = "warrior";
        public static string image = "";
		public Guerra (Point start){
			life = getTotalLife();
			start = Lib.toTiles (start);
			setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
	}
}

