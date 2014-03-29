using System;

namespace RoundedDefence
{
	public class ShortPath
	{
		private byte inicioLvl=0;
		private byte inicioP=0;
		private byte finalLvl=0;
		private byte finalP=0;
		private int valueMap= new int[25][64];

		public ShortPath (byte beginLvl,byte beginP,byte endLvl,byte endP ){
			reset(beginLvl,beginP, endLvl, endP);
		}
		public void reset(byte beginLvl,byte beginP,byte endLvl,byte endP){
			inicioLvl = beginLvl;
			inicioP = beginP;
			finalLvl = endLvl;
			finalP = endP;
			for (int i = 0; i < 25; i++) {
				for (int e = 0; e < 64; e++) {
					valueMap[i][e] = 999999;
				}
			}
		}
		private void newer(byte lvl, byte p, int stime, int time) {
			byte x = (p + Lib.getNcircles(lvl)) % Lib.getNcircles(lvl);
			byte y = (lvl + 25) % 25;
			if (valueMap[y][x] > stime) {
				valueMap[y][x] = stime;
				wall.add(new Camino(y, x, time));
			}

		}
	}
}

