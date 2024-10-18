namespace Fire_Emblem.Skills.Effects;

public class ResistanceCostPercentageEffect : Effect, ICostEffect
{
    private int _costPercentage;
    public ResistanceCostPercentageEffect(int costPercentage)
    {
        _costPercentage = costPercentage;
    }
    public override void Apply(Unit unit)
    {
        int reductionCost = Convert.ToInt32(Math.Floor((unit.Resistance.Value) * (_costPercentage / 100.0)));
        unit.Resistance.Penalty -= reductionCost;
    }
}