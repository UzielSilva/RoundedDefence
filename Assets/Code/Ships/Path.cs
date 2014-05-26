using System;
using System.Collections.Generic;
using RoundedDefence;

namespace RoundedDefence
{
	public class Path
	{
		public List<Camino> camino= new List<Camino>();
		int[,] valueMap;
		public Path (int lvl,int p,int[,] map)
		{
			valueMap = map;
			while (value (lvl,p)!=0) {
				camino.Add (new Camino(lvl,p,0));
				int lowest = value (lvl, p);
				int id = 0;

				if (lvl < 1) {
					for(int i=0;i<Lib.getNcircles(1);i++)
						if (lowest >= value (1, i)) {
							p = i;
							lowest = value ( 1, i);
					}
					id = 6;
				} else {
					if (lowest >= value (lvl, p + 1)) {
						lowest = value (lvl, p + 1);
						id = 1;
					}
					if (lowest >= value (lvl, p - 1)) {
						lowest = value (lvl, p - 1);
						id = 2;
					}
			
					if (lvl > 1) {
                        int chlvl = ShortPath.getNcircles(lvl) / ShortPath.getNcircles(lvl - 1);
						if (lowest >= value (lvl - 1, p / chlvl)) {
							lowest = value (lvl - 1, p / chlvl);
							id = 3;
						}
					}
					if (lvl < 17) {
                        if (ShortPath.getNcircles((lvl + 1) % 18) > ShortPath.getNcircles(lvl))
                        {
							if (lowest >= value (lvl + 1, p * 2)) {
								lowest = value (lvl + 1, p * 2);
								id = 4;
							}
							if (lowest >= value (lvl + 1, p * 2 + 1)) {
								//lowest = value (lvl + 1, p*2+1); // not necesary
								id = 5;
							}
						} else {
							if (lowest >= value (lvl + 1, p)) {
								//lowest = value (lvl + 1, p); //not necesary
								id = 6;
							}
						}
					}
				}
				switch(id){
				case 0:
					goto error;
				case 1:
                    p = (p + 1 + ShortPath.getNcircles(lvl)) % ShortPath.getNcircles(lvl);
					break;
				case 2:
                    p = (p - 1 + ShortPath.getNcircles(lvl)) % ShortPath.getNcircles(lvl);
					break;
				case 3:
                    int chlvl = ShortPath.getNcircles(lvl) / ShortPath.getNcircles(lvl - 1);
					p = p / chlvl;
					lvl = (lvl - 1 + 18) % 18;
					break;
				case 4:
					lvl = (lvl+1 + 18) % 18;
                    p = (p * 2 + ShortPath.getNcircles(lvl)) % ShortPath.getNcircles(lvl);
					break;
				case 5:
					lvl = (lvl+1 + 18) % 18;
                    p = (p * 2 + 1 + ShortPath.getNcircles(lvl)) % ShortPath.getNcircles(lvl);
					break;
				case 6:
					lvl = (lvl+1 + 18) % 18;
					break;

				}

				}
		error:
			;

		}
		
		private int value(int lvl, int p) {
            int x = (p + ShortPath.getNcircles(lvl)) % ShortPath.getNcircles(lvl);
			int y = (lvl + 18) % 18;
			return valueMap [y, x];

		}
	}
}

