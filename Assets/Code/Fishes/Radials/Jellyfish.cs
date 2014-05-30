using System;

namespace RoundedDefence.Components.Fishes.Radials
{
    class Jellyfish : RadialFish
    {
        public static float[] radius = { 4, 5, 6, 7 };
        public static Int32[] requiredFood = { 4, 10, 13, 15 };
        public static Double[] timeToAction = { 1.5, 1.2, 1, 0.8 };
        public static Int32 requiredStars = 20;
        public static Int32[] damage = { 3, 5, 7, 10 };
		public static Int32[] health = { 100, 150, 200, 220 };
		public static string image = "Venenosos/medusas";
		public static string name = "Jelly and fish";
		public static Int32 id = 10;
		public static float scale = .2f;
        public Jellyfish()
			: base(requiredFood, requiredStars, timeToAction, damage, health,image,name,id,radius,scale)
        {}
    }
}
