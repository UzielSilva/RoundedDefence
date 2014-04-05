using System;
using System.Drawing;

namespace RoundedDefence
{
	public class Ship
	{
		public int shipAngle,life;
		public double radio, angle;
		public Bitmap image;
		public Bonus bonus;
		public Path path;
		public Ship (){
		}
		public string getname(){
			return "NO VALID";
		}
		public string getDescription(){
			return "NO VALID";
		}
		public byte getType(){return 0;}
		public byte getDelay(){return 0;}
		public int getScore(){return 0;}
		public byte getSpeed(){return 0;}
		public double getBoost(){return 1;}
		public int getBonus(){return 0;}
		public int getShield(){return 0;}
		public double getDefence(){return 1;}
		public int getTotalLife(){return 0;}
		public int getLife(){return life;}
		public Bitmap getImage(){return image;}
		public void setPath(Path p){path = p;}


		public void addBonus(int b){
			switch(b){
			case 0:
				break;
			case 1:
				bonus.addBoost (5, 1);
				break;
			case 2:
				bonus.addBoost (10, 1);
				break;
			case 3:
				bonus.addBoost (15, 1);
				break;
			case 4:
				bonus.addDefence(5,1);
				break;
			case 5:
				bonus.addDefence(10,1);
				break;
			case 6:
				bonus.addDefence(15,1);
				break;
			}
		}

		public void move(){
			double spd = getSpeed()+bonus.speed;
			spd /= getBoost()+bonus.boost;
			if (radio != path.camino [0].lvl * Lib.tileHeight) {
				if (radio > path.camino [0].lvl * Lib.tileHeight) {
					radio -= spd;
				} else {
					radio += spd;
				}
			}

		}
		public void hit(double dmg){
			dmg-= getShield()+bonus.shield;
			dmg /= getDefence()+bonus.defence;
			if (dmg > 0)
				life -= (int)dmg;
			if (life < 0)
				kill ();
		}
		private void kill(){
		}
		public Point getPosition(){
			return new Point((int)radio,(int)angle);
		}
		public Point getTilesPosition(){
			return Lib.toTiles(getPosition());
		}

	}
}
/*
enemigos: 
	vikingos,
	pesqueros,
	de guerra, 
	piratas, 
	veleros, 
	mercantes, 
	submarinos, 
	rompehielos, 
	petroleros, 
	pasajeros, 
	zepelin

bosses:
	titanic(pasajero), 
	black pearl(pirata),
	dragon(vikingo), 
	fantasma,
	Dream Symphony(velero),
	Majestic Maersk(mercante),
	Knock Nevis(petrolero),
	The Astute (submarino)

*/
