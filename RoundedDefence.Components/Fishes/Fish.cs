using System;
using System.Drawing;

namespace RoundedDefence.Components.Fishes
{
    abstract class Fish
    {
        private Int32[] requiredFood;
        private Double[] timeToAction;
        private Int32[] damage;
        private Int32 level;
		//public Int32 Level { get { return level; } };

        private static Int32 maxLevel = 4;
        
        public Point Position { get; set; }
		//    public Int32 RequiredFood { get { return requiredFood[Level]; } }
		//public Double TimeToAction { get { return timeToAction[Level]; } }
		//public Int32 Damage { get { return damage[Level]; } }
        public Fish(Int32[] requiredFood, Double[] timeToAction, Int32[] damage)
        {
            if (requiredFood.Length != 4
                || timeToAction.Length != 4
                || damage.Length != 4)
                throw new Exception("Bad arguments, array's length must be 4.");
            this.requiredFood = requiredFood;
            this.timeToAction = timeToAction;
            this.damage = damage;
            this.level = 1;
        }
        public abstract Boolean IsInArea(Point p);
        public void Upgrade()
        {
			if (level != maxLevel){
                level++;
            }
        }

    }
}
