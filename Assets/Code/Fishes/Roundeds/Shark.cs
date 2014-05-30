using System;

namespace RoundedDefence.Components.Fishes.Roundeds
{
    class Shark : RoundedFish
    {
        public static Int32[] width = { 1, 2, 3, 4 };
        public static Int32[] requiredFood = { 5, 10, 13, 15 };
        public static Double[] timeToAction = { 1.5, 1.2, 1, 0.8 };
        public static Int32 requiredStars = 20;
        public static Int32[] damage = { 3, 5, 7, 10 };
        public static Int32[] health = { 100, 150, 200, 220 };
		public static Int32[] velocity = { 1, 2, 3, 4 };
		public static string image = "Ataque/tiburon";
		public static string name = "Shark";
		public static Int32 id = 2;
		public static float scale = .2f;
        public Shark()
            : base(requiredFood, requiredStars, timeToAction, damage, health, image, name, id, scale)
        {
        }
        private Point _Position;
		public new Point Position { 
			get{
                if (_Position != null)
                {
                    _Position = new Point(_Position.X, _Position.Y += velocity[Level] % 360);
                    return _Position;
                }
                else return null;
			} 
			set{
				_Position = value;
			}
		}
    }
}
