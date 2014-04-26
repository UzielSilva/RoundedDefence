using System;

namespace RoundedDefence.Components.Fishes.Passives
{
	class Rock: PassiveFish
	{
		public static Int32[] width = { 1, 2, 3, 4 };
		public static Int32[] length = { 5, 6, 7, 8 };
		public static Int32[] requiredFood = { 2, 10, 13, 15 };
		public static Double[] timeToAction = { 1.5, 1.2, 1, 0.8 };
		public static Int32[] damage = { 3, 5, 7, 10 };
		public static Int32[] health = { 100, 150, 200, 220 };
		public static string image = "Barrera/roca";
		public static string name = "Rock block";
		public static Int32 id = 7;
		public static float scale = .3f;
		public Rock()
			: base(requiredFood, timeToAction, damage, health,image,name,id,scale)
		{
		}
		public override Boolean IsInArea(Point p)
		{
			Int32 Width = width[Level];
			Int32 Length = length[Level];
			if (this.Position.X <= p.X 
			    && this.Position.X + Width > p.X 
			    && this.Position.Y <= p.Y 
			    && this.Position.Y + Length > p.Y )
				return true;
			return false;
		}
	}
}
