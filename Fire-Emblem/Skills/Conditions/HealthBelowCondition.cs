namespace Fire_Emblem.Skills.Conditions;

public class HealthBelowCondition : Condition
{
    private readonly int _threshold;

    public HealthBelowCondition(int threshold)
    {
        _threshold = threshold;
    }

    public override bool IsMet(Unit unit)
    {
        return unit.CurrentHP < _threshold;
    }
}