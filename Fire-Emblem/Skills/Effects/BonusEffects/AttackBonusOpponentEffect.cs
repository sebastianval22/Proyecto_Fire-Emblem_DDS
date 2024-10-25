using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Effects.BonusEffects;

public class AttackBonusOpponentEffect : Effect
{
    private int _opponentBonus;
    public AttackBonusOpponentEffect(int bonus)
    {
        _opponentBonus = bonus;
    }

    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController); 
        rival.Attack.Bonus += _opponentBonus;
    }
}