using System;

namespace RoundedDefence.Components.Fishes.Statics
{
	class Iceberg : RadialFish
	{
        public static float[] radius = { 4, 5, 6, 7 };
		public static Int32[] requiredFood = { 2, 10, 13, 15 };
		public static Double[] timeToAction = { 1.5, 1.2, 1, 0.8 };
        public static Int32 requiredStars = 20;
        public static Int32[] damage = { 3, 5, 7, 10 };
		public static Int32[] health = { 100, 150, 200, 220 };
		public static string image = "Barrera/iceberg";
		public static string name = "Iceberg";
		public static Int32 id = 8;
		public static float scale = .2f;
		public Iceberg()
            : base(requiredFood, requiredStars, timeToAction, damage, health, image, name, id, radius, scale)
		{	}
	}
}
