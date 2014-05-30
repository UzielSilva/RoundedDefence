using System;

namespace RoundedDefence.Components.Fishes.Statics
{
	class BlackHole : StaticFish
	{
		public static Int32[] requiredFood = { 2, 10, 13, 15 };
        public static Int32 requiredStars = 20;
		public static String effect = "Teletransport";
		public static Int32[] damage = { 3, 5, 7, 10 };
		public static Int32[] health = { 100, 150, 200, 220 };
		public static string image = "Barrera/black hole";
		public static string name = "Black Hole";
		public static Int32 id = 9;
		public static float scale = .2f;
		public BlackHole()
			: base(requiredFood, requiredStars, effect, damage, health,image,name,id,scale)
		{}
	}
}
