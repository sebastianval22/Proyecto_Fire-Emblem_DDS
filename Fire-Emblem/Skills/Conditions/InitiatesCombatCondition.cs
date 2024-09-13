namespace Fire_Emblem.Skills.Conditions;

public class InitiatesCombatCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        return unit == roundFight.attackingUnit;
    }
}