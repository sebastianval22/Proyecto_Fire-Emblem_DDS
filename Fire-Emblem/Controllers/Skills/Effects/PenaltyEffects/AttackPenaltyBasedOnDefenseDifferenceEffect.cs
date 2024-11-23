using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.PenaltyEffects;

public class AttackPenaltyBasedOnDefenseDifferenceEffect : Effect
{
    
    private int _attackPenaltyPercentage;
    
    public AttackPenaltyBasedOnDefenseDifferenceEffect(int attackPenaltyPercentage)
    {
        _attackPenaltyPercentage = attackPenaltyPercentage;
    }
    
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        int defenseDifference = unit.Defense.Value - rival.Defense.Value;
        if (defenseDifference < 0)
        {
            return;
        }
        int attackPenalty = Convert.ToInt32(Math.Floor(defenseDifference * (_attackPenaltyPercentage / 100.0)));
        attackPenalty = int.Min(attackPenalty, _attackPenaltyPercentage/10);
        rival.Attack.Penalty -= attackPenalty;
    }
    
}