using System;

namespace RoundedDefence.Components.Ships.Types
{
	public class Pasajero:Ship
	{
        public static string image = "Transportador/Transportador";
        public static string id = "passenger";
        public Pasajero()
            : base(id, image)
        {
            Point start = Position;
			life = getTotalLife();
			//start = Lib.toTiles (start);
			//setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
	}
}

