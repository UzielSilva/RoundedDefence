using System;

namespace RoundedDefence.Components.Fishes.Statics
{
	class Coral : StaticFish
	{
		public static Int32[] radius = { 4, 5, 6, 7 };
		public static Int32[] requiredFood = { 4, 10, 13, 15 };
		public static String effect = "DownSpd";
        public static Int32 requiredStars = 20;
        public static Int32[] damage = { 3, 5, 7, 10 };
		public static Int32[] health = { 100, 150, 200, 220 };
		public static string image = "Alentadores/arrecife";
		public static Int32 id = 14;
		public static string name = "Coral";
		public static float scale = .15f;
		public Coral()
            : base(requiredFood, requiredStars, effect, damage, health, image, name, id, scale)
		{
		}
		public override Boolean IsInArea(Point p)
		{
			double x = p.X*Math.Cos((Math.PI / 180) * p.Y);
			double y = p.X*Math.Sin((Math.PI / 180) * p.Y);
			double px = this.Position.X*Math.Cos((Math.PI / 180) * this.Position.Y);
			double py = this.Position.X*Math.Sin((Math.PI / 180) * this.Position.Y);
			Int32 Radius = radius[Level];
			if (Math.Pow(x - px, 2) + Math.Pow(y - py, 2) <= Math.Pow(Radius,2))
				return true;
			return false;
		}
	}
}