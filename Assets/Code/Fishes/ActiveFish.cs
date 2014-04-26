using System;

namespace RoundedDefence.Components.Fishes
{
    abstract class ActiveFish : IFish
    {
        private Int32 requiredFood;
        private Int32 requiredStars;
        private Double timeToAction;
        private Int32 damage;
		private Int32 id;
		private String image;
		private String name;
		private float scale;
        
        public Point Position { get; set; }
        public Int32 RequiredFood { get { return requiredFood; } }
        public Int32 RequiredStars { get { return requiredStars; } }
		public Double TimeToAction { get { return timeToAction; } }
		public Int32 Damage { get { return damage; } }
		public Int32 Id { get { return id; } }
		public String Image { get { return image; } }
		public String Name { get { return name; } }
		public float Scale { get { return scale; } }
        public ActiveFish(Int32 requiredFood, Int32 requiredStars, Double timeToAction, Int32 damage,
		                  string image,string name,Int32 id,float scale)
        {
            this.requiredFood = requiredFood;
            this.requiredStars = requiredStars;
			this.timeToAction = timeToAction;
			this.damage = damage;
			this.image = image;
			this.id = id;
			this.scale = scale;
			this.name = name;
        }
        public abstract Boolean IsInArea(Point p);
    }
}
