using System;

namespace RoundedDefence
{
	public class Lib
	{
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
	}
}

