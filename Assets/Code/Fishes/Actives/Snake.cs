using System;

namespace RoundedDefence.Components.Fishes.Actives
{
	class Snake : ActiveFish
		
	{
		public static Int32 radius = 10;
        public static Int32 requiredFood = 200;
        public static Int32 requiredStars = 20;
		public static Double timeToAction = 2.5;
		public static Int32 damage = 1000;
		public static string image = "Especiales/midgard";
		public static string name = "Snake of Midgard";
		public static Int32 id = 18;
		public static float scale = .2f;
		public Snake()
			: base(requiredFood, requiredStars, timeToAction, damage,image,name,id,scale)
		{
		}
	}
}
