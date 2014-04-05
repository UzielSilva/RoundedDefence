using System;
using System.Drawing;

namespace RoundedDefence.Components
{
	public class Guerra:Ship
	{
		public Guerra (Point start){
			life = getTotalLife();
			start = Lib.toTiles (start);
			setPath(new ShortPath((byte)start.X,(byte)start.Y,0,0).getPath());
		}
	}
}

