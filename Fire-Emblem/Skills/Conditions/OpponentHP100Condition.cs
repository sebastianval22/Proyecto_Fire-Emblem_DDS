namespace Fire_Emblem.Skills.Conditions;

public class OpponentHP100Condition : Condition
{
    public override bool IsMet(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.attackingUnit ? roundFight.defendingUnit : roundFight.attackingUnit;
        return rival.CurrentHP == rival.MaxHP;
    }
}