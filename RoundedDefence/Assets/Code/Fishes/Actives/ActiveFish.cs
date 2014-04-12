using System;

namespace RoundedDefence.Components.Fishes.Actives
{
    abstract class ActiveFish : IFish
    {
        private Int32 requiredFood;
        private Double timeToAction;
        private Int32 damage;
        
        public Point Position { get; set; }
        public Int32 RequiredFood { get { return requiredFood; } }
        public Double TimeToAction { get { return timeToAction; } }
        public Int32 Damage { get { return damage; } }
        public ActiveFish(Int32 requiredFood, Double timeToAction, Int32 damage)
        {
            this.requiredFood = requiredFood;
            this.timeToAction = timeToAction;
            this.damage = damage;
        }
        public abstract Boolean IsInArea(Point p);
    }
}
