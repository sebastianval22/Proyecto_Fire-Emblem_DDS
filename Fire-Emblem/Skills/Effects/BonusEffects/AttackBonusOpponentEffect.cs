using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Effects.BonusEffects;

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

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = unit == roundFightController.AttackingUnit ? roundFightController.DefendingUnit : roundFightController.AttackingUnit;
        rival.Attack.Bonus += _opponent_bonus;
    }
}