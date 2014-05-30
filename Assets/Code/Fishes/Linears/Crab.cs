using System;

namespace RoundedDefence.Components.Fishes.Linears
{
    class Crab : LinearFish
    {
        public static Int32[] requiredFood = { 6, 10, 13, 15 };
        public static Double[] velocity = { 1.5, 1.2, 1, 0.8 };
        public static Int32 requiredStars = 20;
        public static Int32[] damage = { 3, 5, 7, 10 };
		public static Int32[] health = { 100, 150, 200, 220 };
		public static string image = "Ataque/cangrejo";
		public static string name = "King Crab";
		public static Int32 id = 3;
		public static float scale = .2f;
        public Crab()
            : base(requiredFood, requiredStars, velocity, damage, health, image, name, id, scale)
        {}
    }
}
