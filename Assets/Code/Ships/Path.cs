using System;
using System.Collections.Generic;
using RoundedDefence;

namespace RoundedDefence
{
	public class Path
	{
		public List<Camino> camino= new List<Camino>();
		int[] valueMap;
		public Path (int lvl,int[] map)
		{
			valueMap = map;
			int lowest = valueMap [lvl];
			if (lvl == 13) {
				if(lowest>valueMap[14]){lvl=14;lowest=valueMap[14];}
				if(lowest>valueMap[15]){lvl=15;lowest=valueMap[15];}
				if(lowest>valueMap[16]){lvl=16;lowest=valueMap[16];}
				if(lowest>valueMap[17]){lvl=17;lowest=valueMap[17];}
				camino.Add (new Camino(0,0));
				camino.Add (new Camino(0,0));
			}
			while (valueMap [lvl]!=0) {
				camino.Add (new Camino(lvl,0));
				lowest = valueMap [lvl];
				int id = 0;
				if(lvl+21<231&&valueMap [lvl+21]<lowest){
					id=1;
					lowest=valueMap [lvl+21];
				}
				if(lvl+34<231&&valueMap [lvl+34]<lowest){
					id=3;
					lowest=valueMap [lvl+34];
				}
				if(lvl+13<231&&valueMap [lvl+13]<lowest){
					id=5;
					lowest=valueMap [lvl+13];
				}
				if(lvl-21>13&&valueMap [lvl-21]<=lowest){
					id=2;
					lowest=valueMap [lvl-21];
				}
				if(lvl-34>13&&valueMap [lvl-34]<=lowest){
					id=4;
					lowest=valueMap [lvl-34];
				}
				if(lvl-13>13&&valueMap [lvl-13]<=lowest){
					id=6;
					lowest=valueMap [lvl-13];
				}
				switch(id){
				case 1:lvl+=21; break;
				case 2:lvl-=21; break;
				case 3:lvl+=34; break;
				case 4:lvl-=34; break;
				case 5:lvl+=13; break;
				case 6:lvl-=13; break;
				}
				}

		}
	}
}

