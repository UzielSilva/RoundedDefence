using System;

namespace RoundedDefence.Components.Fishes
{
    interface IFish
	{
		Int32 Id { get; }
		String Image { get; }
        Point Position { get; set; }
        Int32 RequiredFood { get; }
		Double TimeToAction { get; }
		Int32 Damage { get; }
    }
}
