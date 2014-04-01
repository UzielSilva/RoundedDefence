using System;
using System.Drawing;

namespace RoundedDefence.Components.Fishes
{
    class Reef : Fish
    {
        public static Int32[] width = { 1, 2, 3, 4 };
        public static Int32[] length = { 5, 6, 7, 8 };
        public static Int32[] requiredFood = { 5, 10, 13, 15 };
        public static Double[] timeToAction = { 1.5, 1.2, 1, 0.8 };
        public static Int32[] damage = { 3, 5, 7, 10 };
        public static Int32[] health = { 100, 150, 200, 220 };
        public Reef()
            : base(requiredFood, timeToAction, damage, health)
        {
        }
        public override Boolean IsInArea(Point p)
        {
            Int32 Width = width[Level];
            Int32 Length = length[Level];
            if (this.Position.X <= p.X 
                && this.Position.X + Width > p.X 
                && this.Position.Y <= p.Y 
                && this.Position.Y + Length > p.Y )
                return true;
            return false;
        }
    }
}
