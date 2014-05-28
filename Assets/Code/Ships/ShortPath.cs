using System;
using System.Collections.Generic;
namespace RoundedDefence
{
	public class ShortPath
	{
<<<<<<< HEAD
		private int inicioLvl;
		private int inicioP;
		private int finalLvl;
		private int finalP;
		private int[,] valueMap= new int[18,256];
        public int[,] costMap = new int[18, 256];
=======
		private int inicio;
		private int final;
		public int[] valueMap= new int[220];
>>>>>>> origin/master
		List<Camino> wall= new List<Camino>();

		public ShortPath (int beginLvl,int endLvl ){
			reset(beginLvl, endLvl);
		}
<<<<<<< HEAD
		public void reset(int beginLvl,int beginP,int endLvl,int endP){
			inicioLvl = beginLvl;
			inicioP = beginP;
			finalLvl = endLvl;
            finalP = endP;
            for (int i = 0; i < 18; i++)
            {
                for (int e = 0; e < 256; e++)
                {
                    valueMap[i, e] = 999999;
                }
            }
            for (int i = 0; i < 18; i++)
            {
                for (int e = 0; e < 256; e++)
                {
                    costMap[i, e] = i;
                }
            }
		}
		private void newer(int lvl, int p, int stime, int time) {
			int x = (p + getNcircles(lvl)) % getNcircles(lvl);
			int y = (lvl + 18) % 18;
			if (valueMap[y,x] > stime) {
				valueMap[y,x] = stime;
				wall.Add(new Camino(y, x,stime+time));
=======
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
>>>>>>> origin/master
			}

		}
		public Path getPath(){
			newer (inicio, 0, 1);
			int minDiference = 1;
			for (int time=0; wall.Count!=0; time +=minDiference) {
				int minTime = wall[0].t;
                List<Camino> enumerator = new List<Camino>(wall);
				foreach (Camino ca in enumerator) {
                    int tim = costMap[ca.lvl,ca.p];
                    if (minTime > ca.t)
                    {
                        minTime = ca.t;
                    }
                    if (ca.lvl == final)
                    {
                        goto next;
                    }
                    if (time >= ca.t)
<<<<<<< HEAD
                    {
                        if (ca.lvl > 0)
                        {
                            int chlvl = getNcircles(ca.lvl) / getNcircles(ca.lvl - 1);
                            newer(ca.lvl - 1, ca.p / chlvl, time, tim);
                            if (ca.lvl < 17)
                            {
                                if (getNcircles((ca.lvl + 1) % 18) > getNcircles(ca.lvl))
                                {
                                    newer(ca.lvl + 1, ca.p * 2, time, tim);
                                    newer(ca.lvl + 1, ca.p * 2 + 1, time, tim);
                                }
                                else
                                {
                                    newer(ca.lvl + 1, ca.p, time, tim);
                                }
                            }
                        }
                        tim *= 256 / getNcircles(ca.lvl);
                        newer(ca.lvl, ca.p + 1, time, tim);
                        newer(ca.lvl, ca.p - 1, time, tim);
=======
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
>>>>>>> origin/master
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
