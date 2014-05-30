using System;

namespace RoundedDefence.Components.Fishes
{
    abstract class TargetFish : IFish
    {
        private Int32[] radius;
        private Int32[] requiredFood;
        private Int32 requiredStars;
        private Double[] velocity;
        private Int32[] damage;
        private Int32 level;
        private Int32 stamina;
        private Int32[] health;
        public Int32 Level { get { return level; } }
        public Int32 Health { get { return health[Level-1]; } }
        public Int32 RequiredStars { get { return requiredStars; } }
		
		private Int32 id;
		private String image;
		private String name;
		private float scale;
        private static Int32 maxLevel = 4;
        
        public Point Position { get; set; }
        public Int32 RequiredFood { get { return requiredFood[Level-1]; } }
        public Double Velocity { get { return velocity[Level-1]; } }
		public Int32 Damage { get { return damage[Level-1]; } }
		public Int32 Id { get { return id; } }
		public String Image { get { return image; } }
		public String Name { get { return name; } }
		public float Scale { get { return scale; } }
		public TargetFish(Int32[] requiredFood, Int32 requiredStars, Double[] velocity, Int32[] damage, Int32[] health , 
		                   string image,string name,Int32 id, Int32[] radius,float scale)
        {
            if (requiredFood.Length != 4
                || velocity.Length != 4
                || damage.Length != 4)
				throw new Exception("Bad arguments, array's length must be 4.");
			this.level = 1;
            this.requiredFood = requiredFood;
            this.requiredStars = requiredStars;
            this.velocity = velocity;
            this.damage = damage;
            this.health = health;
            this.radius = radius;
			this.stamina = Health;
			this.image = image;
			this.name = name;
			this.id = id;
			this.scale = scale;
        }
        public void Upgrade()
        {
            if (level != maxLevel)
            {
                level++;
                this.stamina = Health;
            }
        }
        public void isAttacked(Int32 damage)
        {
            this.stamina -= damage;
        }

    }

}