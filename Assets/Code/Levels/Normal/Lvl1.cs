using System;

namespace RoundedDefence.Components
{
	public class Lvl1:Level
	{
		public Lvl1 (){
			waves.Add (new Wave (22,0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 9, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0));
			waves.Add (new Wave (22,0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0));
		}
		public  override  Boolean hasPesquero(){return true;}
		
		public  override  int getLvlNumb (){return 1;}
		public  override  int getMinStars (){return 0;}
		public override  int getOneStar(){return 100;}
		public override  int getTwoStar(){return 300;}
		public  override  int getThreeStar(){return 500;}


		public  override Boolean hasGuerra (){return false;}
		public  override Boolean hasMercante (){return false;}
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

