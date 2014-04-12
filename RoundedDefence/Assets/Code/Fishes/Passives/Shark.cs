using System;

namespace RoundedDefence.Components.Fishes.Passives
{
    class Shark : PassiveFish
    {
        public static Int32[] width = { 1, 2, 3, 4 };
        public static Int32[] requiredFood = { 5, 10, 13, 15 };
        public static Double[] timeToAction = { 1.5, 1.2, 1, 0.8 };
        public static Int32[] damage = { 3, 5, 7, 10 };
        public static Int32[] health = { 100, 150, 200, 220 };
        public Shark()
            : base(requiredFood, timeToAction, damage, health)
        {
        }
        public override Boolean IsInArea(Point p)
        {
            Int32 Width = width[Level];
            if (this.Position.X <= p.X 
                && this.Position.X + Width > p.X)
                return true;
            return false;
        }
    }
}
