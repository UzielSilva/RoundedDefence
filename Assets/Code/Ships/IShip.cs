using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoundedDefence.Components.Ships
{
    public interface IShip
    {
        String Id { get; }
        String Image { get; }
        Point Position { get; set; }
        Path Path { get; set; }
        void Hit(double damage);
        float Life { get; }
        float FullLife { get; }
    }
}
