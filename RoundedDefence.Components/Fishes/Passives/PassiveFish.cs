using System;
using System.Drawing;

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
        public Int32 Health { get { return health[level]; } }
        public Int32 Level { get { return level; } }

        private static Int32 maxLevel = 4;
        
        public Point Position { get; set; }
        public Int32 RequiredFood { get { return requiredFood[Level]; } }
        public Double TimeToAction { get { return timeToAction[Level]; } }
        public Int32 Damage { get { return damage[Level]; } }
        public PassiveFish(Int32[] requiredFood, Double[] timeToAction, Int32[] damage, Int32[] health)
        {
            if (requiredFood.Length != 4
                || timeToAction.Length != 4
                || damage.Length != 4)
                throw new Exception("Bad arguments, array's length must be 4.");
            this.requiredFood = requiredFood;
            this.timeToAction = timeToAction;
            this.damage = damage;
            this.health = health;
            this.stamina = Health;
            this.level = 1;
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