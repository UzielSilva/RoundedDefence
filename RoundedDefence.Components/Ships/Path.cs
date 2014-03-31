using System;
using System.Collections.Generic;

namespace RoundedDefence
{
	public class Path
	{
		List<Camino> camino= new List<Camino>();
		int[,] valueMap;
		public Path (int lvl,int p,int[,] map)
		{
			valueMap = map;
			while (value (lvl,p)!=0) {
				camino.Add (new Camino((byte)lvl,(byte)p,0));
				int lowest = value (lvl, p);
				int id = 0;
				if(lowest >= value (lvl, p+1)){
					lowest = value (lvl, p + 1);
					id = 1;
				}
				if(lowest >= value (lvl, p-1)){
					lowest = value (lvl, p - 1);
					id = 2;
				}
				
				if (lvl > 1) {
					int chlvl = Lib.getNcircles (lvl) / Lib.getNcircles (lvl - 1);
					if (lowest >= value (lvl - 1, p / chlvl)) {
						lowest = value (lvl - 1, p / chlvl);
						id = 3;
					}
				}
				if (lvl < 24) {
					if (Lib.getNcircles((lvl + 1) % 25) > Lib.getNcircles(lvl)) {
						if (lowest >= value (lvl +1, p*2)) {
							lowest = value (lvl + 1, p*2);
							id = 4;
						}
						if (lowest >= value (lvl +1, p*2+1)) {
							lowest = value (lvl + 1, p*2+1);
							id = 5;
						}
					} else {
						if (lowest >= value (lvl +1, p)) {
							lowest = value (lvl + 1, p);
							id = 6;
						}
					}
				}
				switch(id){
				case 0:
					goto error;
				case 1:
					p=(p+1 + Lib.getNcircles(lvl)) % Lib.getNcircles(lvl);
					break;
				case 2:
					p = (p - 1 + Lib.getNcircles (lvl)) % Lib.getNcircles (lvl);
					break;
				case 3:
					int chlvl = Lib.getNcircles (lvl) / Lib.getNcircles (lvl - 1);
					p = p / chlvl;
					lvl = (lvl - 1 + 25) % 25;
					break;
				case 4:
					lvl = (lvl+1 + 25) % 25;
					p=(p*2+1 + Lib.getNcircles(lvl)) % Lib.getNcircles(lvl);
					break;
				case 5:
					lvl = (lvl+1 + 25) % 25;
					p=(p*2 + Lib.getNcircles(lvl)) % Lib.getNcircles(lvl);
					break;
				case 6:
					lvl = (lvl+1 + 25) % 25;
					break;

				}

				}
		error:
			;

		}
		
		private int value(int lvl, int p) {
			int x = (p + Lib.getNcircles(lvl)) % Lib.getNcircles(lvl);
			int y = (lvl + 25) % 25;
			return valueMap [x, y];

		}
	}
}

