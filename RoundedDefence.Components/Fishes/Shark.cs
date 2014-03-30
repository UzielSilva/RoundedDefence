using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoundedDefence.Fishes
{
    class Shark : Fish
    {
        public static Int32[] Width = { 1, 2, 3, 4 };
        public static Int32[] requiredFood = { 5, 10, 13, 15 };
        public static Double[] timeToAction = { 1.5, 1.2, 1, 0.8 };
        public static Int32[] damage = { 3, 5, 7, 10 };
        public Shark()
            : base(requiredFood, timeToAction, damage)
        {
        }
        public override Boolean IsInArea(Point p)
        {
            Int32 width = Width[level];
            if (this.Position.X >= p.X && this.Position.X + width < p.X)
                return true;
            return false;
        }
        internal override void Upgrade() {}
    }
}
