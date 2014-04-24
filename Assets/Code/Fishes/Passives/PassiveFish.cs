﻿using System;

namespace RoundedDefence.Components.Fishes.Passives
{
    abstract class PassiveFish : IFish
    {
        private Int32[] requiredFood;
        private Double[] timeToAction;
        private Int32[] damage;
        private Int32 level;
        private Int32 stamina;
        private Int32[] health;
        public Int32 Level { get { return level; } }
        public Int32 Health { get { return health[Level-1]; } }
		
		private Int32 id;
		private String image;
		private float scale;
        private static Int32 maxLevel = 4;
        
        public Point Position { get; set; }
        public Int32 RequiredFood { get { return requiredFood[Level-1]; } }
        public Double TimeToAction { get { return timeToAction[Level-1]; } }
		public Int32 Damage { get { return damage[Level-1]; } }
		public Int32 Id { get { return id; } }
		public String Image { get { return image; } }
		public float Scale { get { return scale; } }
		public PassiveFish(Int32[] requiredFood, Double[] timeToAction, Int32[] damage, Int32[] health , 
		                   string image,Int32 id,float scale)
        {
            if (requiredFood.Length != 4
                || timeToAction.Length != 4
                || damage.Length != 4)
				throw new Exception("Bad arguments, array's length must be 4.");
			this.level = 1;
            this.requiredFood = requiredFood;
            this.timeToAction = timeToAction;
            this.damage = damage;
            this.health = health;
			this.stamina = Health;
			this.image = image;
			this.id = id;
			this.scale = scale;
        }
        public abstract Boolean IsInArea(Point p);
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