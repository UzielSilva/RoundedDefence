using System;

namespace RoundedDefence.Components.Fishes.Static
{
	class Rock: StaticFish
	{
		public static Int32[] requiredFood = { 2, 10, 13, 15 };
        public static Int32 requiredStars = 20;
        public static String effect = "Stop";
        public static Int32[] damage = { 3, 5, 7, 10 };
		public static Int32[] health = { 100, 150, 200, 220 };
		public static string image = "Barrera/roca";
		public static string name = "Rock block";
		public static Int32 id = 7;
		public static float scale = .3f;
		public Rock()
            : base(requiredFood, requiredStars, effect, damage, health, image, name, id, scale)
		{}
	}
}
