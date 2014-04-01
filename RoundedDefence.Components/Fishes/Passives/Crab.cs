﻿using System;
using System.Drawing;

namespace RoundedDefence.Components.Fishes.Passives
{
    class Crab : PassiveFish
    {
        public static Int32[] Radius = { 4, 5, 6, 7 };
        public static Int32[] requiredFood = { 5, 10, 13, 15 };
        public static Double[] timeToAction = { 1.5, 1.2, 1, 0.8 };
        public static Int32[] damage = { 3, 5, 7, 10 };
        public static Int32[] health = { 100, 150, 200, 220 };
        public Crab()
            : base(requiredFood, timeToAction, damage, health)
        {
        }
        public override Boolean IsInArea(Point p)
        {
            double x = p.X*Math.Cos(p.Y);
            double y = p.X*Math.Sin(p.Y);
            double px = this.Position.X*Math.Cos(this.Position.Y);
            double py = this.Position.X*Math.Sin(this.Position.Y);
            Int32 radius = Radius[Level];
            if (Math.Pow(x - px, 2) + Math.Pow(y - py, 2) <= Math.Pow(radius,2))
                return true;
            return false;
        }
    }
}
