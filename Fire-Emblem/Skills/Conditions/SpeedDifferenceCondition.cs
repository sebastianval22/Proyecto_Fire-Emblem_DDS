namespace Fire_Emblem.Skills.Conditions;

public class SpeedDifferenceCondition : Condition
{
    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
        return unit.Speed.Value - rival.Speed.Value > 0;
    }
}