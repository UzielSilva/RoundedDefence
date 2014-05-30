using System;

namespace RoundedDefence.Components.Fishes.Targets
{
	class Erizo : TargetFish
	{
		public static Int32[] radius = { 4, 5, 6, 7 };
		public static Int32[] requiredFood = { 4, 10, 13, 15 };
		public static Double[] velocity = { 1.5, 1.2, 1, 0.8 };
        public static Int32 requiredStars = 20;
        public static Int32[] damage = { 3, 5, 7, 10 };
		public static Int32[] health = { 100, 150, 200, 220 };
		public static string image = "Venenosos/erizo de mar";
		public static string name = "Sea urchin";
		public static Int32 id = 11;
		public static float scale = .3f;
        public static bool rotate = false;
		public Erizo()
            : base(requiredFood, requiredStars, velocity, damage, health, image, name, id, radius, rotate, scale)
		{}
	}
}
