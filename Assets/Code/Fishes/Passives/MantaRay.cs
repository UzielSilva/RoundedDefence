using System;
namespace RoundedDefence.Components.Fishes.Passives
{
	class MantaRay : PassiveFish
	{
		public static Int32[] width = { 4, 5, 6, 7 };
		public static Int32[] requiredFood = { 3, 10, 13, 15 };
		public static Double[] timeToAction = { 1.5, 1.2, 1, 0.8 };
		public static Int32[] damage = { 3, 5, 7, 10 };
		public static Int32[] health = { 100, 150, 200, 220 };
		public static string image = "Ataque/mantaray";
		public static Int32 id = 1;
		public MantaRay()
			: base(requiredFood, timeToAction, damage, health)
		{
		}
		public override Boolean IsInArea(Point p)
		{
			Int32 Width = width[Level];
			if ((p.Y % 180) - (this.Position.Y % 180) < Width)
				return true;
			return false;
		}
	}
}
