namespace Fire_Emblem.Skills.Conditions;

public class OrCondition : Condition
{
    private readonly Condition _condition1;
    private readonly Condition _condition2;

    public OrCondition(Condition condition1, Condition condition2)
    {
        _condition1 = condition1;
        _condition2 = condition2;
    }

    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        return _condition1.IsMet(unit, roundFight) || _condition2.IsMet(unit, roundFight);
    }
}