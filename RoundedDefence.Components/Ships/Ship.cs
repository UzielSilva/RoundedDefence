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
			return "";
		}
		public string getDescription(){
			return "";
		}
		public byte getType(){
			return 0;
		}
		public byte getSpeed(){
			return 0;
		}
		public int getBonus(){
			return 0;
		}
		public int getShield(){
			return 0;
		}
		public int getTotalLife(){
			return 0;
		}
		public int getLife(){
			return life;
		}
		public Bitmap getImage(){
			return image;
		}
		public void addBonus(Bonus b){
			bonus = b;
		}
		public void setPath(Path p){
			path = p;
		}

		public void move(){
		}
		public void kill(){
		}
		public Point getPosition(){
			return new Point((int)radio,(int)angle);
		}

	}
}

