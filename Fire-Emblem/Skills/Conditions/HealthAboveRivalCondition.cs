namespace Fire_Emblem.Skills.Conditions;

public class HealthAboveRivalCondition : Condition
{
    private readonly int _thresholdAbove;
    public HealthAboveRivalCondition(int thresholdAbove)
    {
        _thresholdAbove = thresholdAbove;
    }
    
    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
        return unit.CurrentHP >= rival.CurrentHP + _thresholdAbove;
    }
}