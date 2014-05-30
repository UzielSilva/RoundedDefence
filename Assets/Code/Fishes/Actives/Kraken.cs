using System;

namespace RoundedDefence.Components.Fishes.Actives
{
    class Kraken : ActiveFish
    {
        public static Int32 radius = 10;
        public static Int32 requiredFood = 150;
        public static Int32 requiredStars = 150;
		public static Double timeToAction = 2.5;
		public static Int32 damage = 1000;
		public static string image = "Especiales/kraken";
		public static string name = "Kraken";
		public static Int32 id = 17;
		public static float scale = .2f;

        public Kraken()
			: base(requiredFood,requiredStars, timeToAction, damage,image,name,id,scale)
        {}
    }
}
