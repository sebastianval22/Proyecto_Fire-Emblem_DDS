using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.CostEffects;

public class ResistanceCostPercentageEffect : Effect, ICostEffect
{
    
    private readonly int _costPercentage;
    
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