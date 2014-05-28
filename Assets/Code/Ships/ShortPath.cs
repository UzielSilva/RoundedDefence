using System;
using System.Collections.Generic;
namespace RoundedDefence
{
	public class ShortPath
	{
		private int inicio;
		private int final;
		public int[] valueMap= new int[220];
		List<Camino> wall= new List<Camino>();

		public ShortPath (int beginLvl,int endLvl ){
			reset(beginLvl, endLvl);
		}
		public void reset(int beginLvl,int endLvl){
			inicio = beginLvl;
			final = endLvl;
			for (int e = 0; e < 220; e++) {
				valueMap[e] = 999999;
			}
		}
		private void newer(int lvl, int stime, int time) {
			if (valueMap[lvl] > stime) {
				valueMap[lvl] = stime;
				wall.Add(new Camino(lvl,stime+time));
			}

		}
		public Path getPath(){
			newer (inicio, 0, 1);
			int minDiference = 1;
			for (int time=0; wall.Count!=0; time +=minDiference) {
				int minTime = wall[0].t;
                List<Camino> enumerator = new List<Camino>(wall);
				foreach (Camino ca in enumerator) {
                    int tim = 4;
                    if (minTime > ca.t)
                    {
                        minTime = ca.t;
                    }
                    if (ca.lvl == final)
                    {
                        goto next;
                    }
                    if (time >= ca.t)
					{
						if(ca.lvl-21>13)
							newer(ca.lvl-21, time, tim);
						if(ca.lvl+21<220)
							newer(ca.lvl+21, time, tim);
						if(ca.lvl-13>13)
							newer(ca.lvl-13, time, tim);
						if(ca.lvl+13<220)
							newer(ca.lvl+13, time, tim);
						if(ca.lvl+34<220)
							newer(ca.lvl+34, time, tim);
						if(ca.lvl-34>13)
							newer(ca.lvl-34, time, tim);
                        wall.Remove(ca);
                    }
				}
				minDiference = minTime - time;
			}
			//return null;
			next: 
			return new Path(final,valueMap);
			}
		}
	}
