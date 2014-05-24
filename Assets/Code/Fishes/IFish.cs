using System;

namespace RoundedDefence.Components.Fishes
{
    public interface IFish
	{
		Int32 Id { get; }
		String Name { get; }
		String Image { get; }
        Point Position { get; set; }
        Int32 RequiredFood { get; }
        Int32 RequiredStars { get; }
		Double TimeToAction { get; }
		Int32 Damage { get; }
		float Scale { get; }
    }
}
