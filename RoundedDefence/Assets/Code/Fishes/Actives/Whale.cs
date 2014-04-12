using System;
using System.Drawing;

namespace RoundedDefence.Components.Fishes.Actives
{
    class Whale : ActiveFish

    {
        public static Int32 radius = 10;
        public static Int32 requiredFood = 200;
        public static Double timeToAction = 2.5;
        public static Int32 damage = 1000;
        public Whale()
            : base(requiredFood, timeToAction, damage)
        {
        }
        public override Boolean IsInArea(Point p)
        {
            double x = p.X*Math.Cos(p.Y);
            double y = p.X*Math.Sin(p.Y);
            double px = this.Position.X*Math.Cos(this.Position.Y);
            double py = this.Position.X*Math.Sin(this.Position.Y);
            if (Math.Pow(x - px, 2) + Math.Pow(y - py, 2) <= Math.Pow(radius,2))
                return true;
            return false;
        }
    }
}
