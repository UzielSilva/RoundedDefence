using System;

namespace RoundedDefence.Components.Fishes.Actives
{
    abstract class ActiveFish : IFish
    {
        private Int32 requiredFood;
        private Double timeToAction;
        private Int32 damage;
		private Int32 id;
		private String image;
		private float scale;
        
        public Point Position { get; set; }
        public Int32 RequiredFood { get { return requiredFood; } }
		public Double TimeToAction { get { return timeToAction; } }
		public Int32 Damage { get { return damage; } }
		public Int32 Id { get { return id; } }
		public String Image { get { return image; } }
		public float Scale { get { return scale; } }
        public ActiveFish(Int32 requiredFood, Double timeToAction, Int32 damage,
		                  string image,Int32 id,float scale)
        {
            this.requiredFood = requiredFood;
			this.timeToAction = timeToAction;
			this.damage = damage;
			this.image = image;
			this.id = id;
			this.scale = scale;
        }
        public abstract Boolean IsInArea(Point p);
    }
}
