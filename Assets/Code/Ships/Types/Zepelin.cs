using System;

namespace RoundedDefence.Components
{
	public class Zepelin:Ship
	{
		public Zepelin (Point start){
			life = getTotalLife();
			start = Lib.toTiles (start);
			setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
	}
}

