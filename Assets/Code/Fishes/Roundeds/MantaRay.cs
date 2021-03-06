using System;
namespace RoundedDefence.Components.Fishes.Roundeds
{
	class MantaRay : RoundedFish
	{
        public static Int32[] width = { 4, 5, 6, 7 };
		public static Int32[] requiredFood = { 3, 10, 13, 15 };
		public static Double[] timeToAction = { 1.5, 1.2, 1, 0.8 };
        public static Int32 requiredStars = 0;
        public static Int32[] damage = { 3, 5, 7, 10 };
		public static Int32[] health = { 100, 150, 200, 220 };
		public static string image = "Ataque/mantarraya";
		public static string name = "Manta ray";
		public static Int32 id = 1;
		public static float scale = .2f;
		public MantaRay()
            : base(requiredFood, requiredStars, timeToAction, damage, health, image, name, id, scale)
		{
		}
	}
}
