using System;
using System.Drawing;

namespace RoundedDefence
{
	public class Lib
	{
		public static int tileHeight = 10;
		public Lib ()
		{
		}
		public static byte getNcircles(int rad) {
			byte frac = 2;
			while (rad > 2) {
				if (rad % 2 != 0) rad--;
				rad = rad / 2;
				frac++;
			}
			return (byte)Math.Pow(2.0, frac);
		}
		public static Point toTiles(Point p){
			return new Point(p.X/tileHeight,p.Y*getNcircles(p.X/tileHeight)/360);
		}
	}
}

