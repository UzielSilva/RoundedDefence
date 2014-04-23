using System;

namespace RoundedDefence.Components.Fishes.Actives
{
	class Snake : ActiveFish
		
	{
		public static Int32 radius = 10;
		public static Int32 requiredFood = 200;
		public static Double timeToAction = 2.5;
		public static Int32 damage = 1000;
		public static string image = "Especiales/snake";
		public static Int32 id = 18;
		public Snake()
			: base(requiredFood, timeToAction, damage)
		{
		}
		public override Boolean IsInArea(Point p)
		{
			double x = p.X*Math.Cos((Math.PI / 180) * p.Y);
			double y = p.X*Math.Sin((Math.PI / 180) * p.Y);
			double px = this.Position.X*Math.Cos((Math.PI / 180) * this.Position.Y);
			double py = this.Position.X*Math.Sin((Math.PI / 180) * this.Position.Y);
			if (Math.Pow(x - px, 2) + Math.Pow(y - py, 2) <= Math.Pow(radius,2))
				return true;
			return false;
		}
	}
}
