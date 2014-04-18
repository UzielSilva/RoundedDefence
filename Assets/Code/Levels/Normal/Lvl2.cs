using System;

namespace RoundedDefence.Components
{
	public class Lvl2:Level
	{
		public Lvl2 (){
			waves.Add (new Wave (22,0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 4, 0, 3, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 6, 0, 4, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 10, 0, 12, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 20, 0, 10, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 30, 0, 12, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 40, 0, 15, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 50, 0, 20, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 60, 0, 30, 0, 0, 0, 0, 0, 0, 0));
		}
		public  override  Boolean hasPesquero(){return true;}
		public  override  Boolean hasMercante(){return true;}
		
		public  override  int getLvlNumb (){return 2;}
		public  override  int getMinStars (){return 0;}
		public  override  int getOneStar(){return 200;}
		public  override  int getTwoStar(){return 800;}
		public  override  int getThreeStar(){return 1000;}

		
		public  override Boolean hasGuerra (){return false;}
		public  override Boolean hasPasajero (){return false;}
		public  override Boolean hasPetrolero (){return false;}
		public  override Boolean hasPirata (){return false;}
		public  override Boolean hasRompeHielo (){return false;}
		public  override Boolean hasSubmarino (){return false;}
		public  override Boolean hasVelero (){return false;}
		public  override Boolean hasVikingo (){return false;}
		public  override Boolean hasZepelin (){return false;}
		
		public   override Boolean hasCangrejos (){return false;}
		public   override Boolean hasMedusas (){return false;}
		public   override Boolean hasPulpos (){return false;}
		public   override Boolean hasArrecifes (){return false;}
		public  override Boolean hasVoladores (){return false;}
		public  override Boolean hasTiburones (){return false;}
		public  override Boolean hasKraken (){return false;}
		public  override Boolean hasBallenas (){return false;}
		public  override Boolean hasSirenas (){return false;}
	}
}

