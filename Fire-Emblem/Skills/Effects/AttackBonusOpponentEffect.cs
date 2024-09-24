namespace Fire_Emblem.Skills.Effects;

public class AttackBonusOpponentEffect : Effect
{
    public int _opponent_bonus { get; protected set; }
    public AttackBonusOpponentEffect(int bonus)
    {
        _opponent_bonus = bonus;
    }

    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.attackingUnit ? roundFight.defendingUnit : roundFight.attackingUnit;
        rival.Attack.Bonus += _opponent_bonus;
    }
}