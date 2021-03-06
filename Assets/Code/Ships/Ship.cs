using System;

namespace RoundedDefence.Components.Ships
{
	public abstract class Ship : IShip
	{
		public float shipAngle,life;
		public Bonus bonus;
		private Path path;
        private string id;
        private string image;

        public Point Position { get; set; }
        public string Id { get { return id; } }
        public string Image { get { return image; } }
        public Path Path { get { return path; } set { path = value; } }
        public Ship (string Id, string Image){
            id = Id;
            image = Image;
            Position = new Point(0, 0);
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
        public float Life { get { return life; } }
		//public Bitmap getImage(){return image;}
        public float FullLife { get { return 100; } }

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
		}
		public void Hit(double dmg){
				life -= (float)dmg;
		}
		private void kill(){
		}
		public Point getPosition(){
			return null;
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
