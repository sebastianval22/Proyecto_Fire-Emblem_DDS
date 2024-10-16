namespace Fire_Emblem.Skills.Effects;

public class AttackBonusOpponentEffect : Effect
{
    private int _opponent_bonus;
    public AttackBonusOpponentEffect(int bonus)
    {
        _opponent_bonus = bonus;
    }

    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
        rival.Attack.Bonus += _opponent_bonus;
    }
}