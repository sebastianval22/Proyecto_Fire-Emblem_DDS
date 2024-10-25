namespace Fire_Emblem.Skills.Effects.CostEffects;

public class DefenseCostPercentageEffect : Effect,  ICostEffect
{
    
    private int _costPercentage;
    
    public DefenseCostPercentageEffect(int costPercentage)
    {
        _costPercentage = costPercentage;
    }
    
    public override void Apply(Unit unit)
    {
        int reductionCost = Convert.ToInt32(Math.Floor((unit.Defense.Value) * (_costPercentage / 100.0)));
        unit.Defense.Penalty -= reductionCost;
    }
}
