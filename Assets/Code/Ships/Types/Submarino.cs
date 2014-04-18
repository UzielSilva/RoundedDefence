using System;

namespace RoundedDefence.Components
{
	public class Submarino:Ship
	{
		public Submarino (Point start){
			life = getTotalLife();
			start = Lib.toTiles (start);
			setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
	}
}

