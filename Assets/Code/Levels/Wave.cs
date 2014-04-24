using System;
using RoundedDefence.Components.Ships;

namespace RoundedDefence.Components.Levels
{
	public class Wave
	{
		private int[] amount=new int[11];
		private long time;
		private long delay;
		private Boolean empty;
		public Wave (long del,int gue,int mer,int pas,int pes,int pet,int pir,int rom,int sub, int vel,int vik, int zep){
			delay = del;
			amount [0] = gue;
			amount [1] = mer;
			amount [2] = pas;
			amount [3] = pes;
			amount [4] = pet;
			amount [5] = pir;
			amount [6] = rom;
			amount [7] = sub;
			amount [8] = vel;
			amount [9] = vik;
			amount [10] = zep;
			time = 0;
			empty = false;
		}
		public Ship getShip(){
			if (time-- > 0)
				return null;
			Random r = new Random();
			int n = (int)(r.NextDouble() * 11);
			for (int i = 0; i < 11; i++) {
				if (amount [n + i] != 0) {
					amount [n + i]--;
					Ship ship = select (n + i);
					time=ship.getDelay ();
				}
			}
			empty = true;
			return null;
		}
		public Ship select(int i){
			switch(i){
			case 0: return new Guerra(getApropiateStart());
			case 1: return new Mercante(getApropiateStart());
			case 2: return new Pasajero(getApropiateStart());
			case 3: return new Pesquero(getApropiateStart());
			case 4: return new Petrolero(getApropiateStart());
			case 5: return new Pirata(getApropiateStart());
			case 6: return new RompeHielo(getApropiateStart());
			case 7: return new Submarino(getApropiateStart());
			case 8: return new Velero(getApropiateStart());
			case 9: return new Vikingo(getApropiateStart());
			case 10: return new Zepelin(getApropiateStart());
			default:
				return null;
			}
		}
		public long getTime(){
			return delay;
		}
		public Point getApropiateStart(){
			return new Point(0,0);
		}
		public Boolean isEmpty(){
			return empty;
		}
	}
}

