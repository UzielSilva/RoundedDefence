using System;

namespace RoundedDefence.Components.Fishes.Targets
{
	class FlyFish : TargetFish
	{
		public static Int32[] radius = { 4, 5, 6, 7 };
		public static Int32[] requiredFood = { 6, 10, 13, 15 };
		public static Double[] velocity = { 1.5, 1.2, 1, 0.8 };
        public static Int32 requiredStars = 0;
        public static Int32[] damage = { 3, 5, 7, 10 };
		public static Int32[] health = { 100, 150, 200, 220 };
		public static string image = "Multiple/peces_voladores";
		public static string name = "Flappy fish";
		public static Int32 id = 4;
		public static float scale = .2f;
		public FlyFish()
            : base(requiredFood, requiredStars, velocity, damage, health, image, name, id, radius, scale)
		{}
	}
}
