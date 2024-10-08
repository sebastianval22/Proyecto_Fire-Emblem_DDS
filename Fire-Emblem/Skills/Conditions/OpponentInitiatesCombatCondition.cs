namespace Fire_Emblem.Skills.Conditions;

public class OpponentInitiatesCombatCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.attackingUnit ? roundFight.defendingUnit : roundFight.attackingUnit;
        return rival == roundFight.attackingUnit;
    }
}