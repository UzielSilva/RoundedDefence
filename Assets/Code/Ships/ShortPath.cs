using System;
using System.Collections.Generic;
namespace RoundedDefence
{
	public class ShortPath
	{
		private int inicioLvl;
		private int inicioP;
		private int finalLvl;
		private int finalP;
		private int[,] valueMap= new int[25,64];
		List<Camino> wall= new List<Camino>();

		public ShortPath (int beginLvl,int beginP,int endLvl,int endP ){
			reset(beginLvl,beginP, endLvl, endP);
		}
		public void reset(int beginLvl,int beginP,int endLvl,int endP){
			inicioLvl = beginLvl;
			inicioP = beginP;
			finalLvl = endLvl;
			finalP = endP;
			for (int i = 0; i < 25; i++) {
				for (int e = 0; e < 64; e++) {
					valueMap[i,e] = 999999;
				}
			}
		}
		private void newer(int lvl, int p, int stime, int time) {
			int x = (p + Lib.getNcircles(lvl)) % Lib.getNcircles(lvl);
			int y = (lvl + 25) % 25;
			if (valueMap[y,x] > stime) {
				valueMap[y,x] = stime;
				wall.Add(new Camino(y, x,stime+time));
			}

		}
		public Path getPath(){
			newer (inicioLvl, inicioP, 0, 1);
			int minDiference = 1;
			for (int time=0; wall.Count!=0; time +=minDiference) {
				int minTime = wall[0].t;
				foreach (Camino ca in wall) {
                    int tim = 4;
                    if (minTime > ca.t)
                    {
                        minTime = ca.t;
                    }
                    if (ca.lvl == finalLvl && ca.p == finalP)
                    {
                        goto next;
                    }
                    if (time >= ca.t)
                    {
                        if (ca.lvl > 1)
                        {
                            int chlvl = Lib.getNcircles(ca.lvl) / Lib.getNcircles(ca.lvl - 1);
                            newer(ca.lvl - 1, ca.p / chlvl, time, tim);
                            if (ca.lvl < 24)
                            {
                                if (Lib.getNcircles((ca.lvl + 1) % 25) > Lib.getNcircles(ca.lvl))
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
                        tim *= 64 / Lib.getNcircles(ca.lvl);
                        newer(ca.lvl, ca.p + 1, time, tim);
                        newer(ca.lvl, ca.p - 1, time, tim);
                        //wall.Remove(ca);
                    }
				}
				minDiference = minTime - time;
			}
			return null;
			next: 
			return new Path(finalLvl,finalP,valueMap);
			}
		}
	}
