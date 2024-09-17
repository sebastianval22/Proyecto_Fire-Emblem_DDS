namespace Fire_Emblem.Skills.Effects;

public class NeutralizePenaltyEffect : Effect
{
    public override void Apply(Unit unit)
    {
        unit.PenaltyHasBeenNeutralized = true;
    }
}