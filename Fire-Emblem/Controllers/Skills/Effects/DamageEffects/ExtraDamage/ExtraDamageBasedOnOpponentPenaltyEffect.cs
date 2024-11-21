using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.ExtraDamage;

public class ExtraDamageBasedOnOpponentPenaltyEffect : Effect
{
    
    private readonly int _extraDamagePercentage;
    
    public ExtraDamageBasedOnOpponentPenaltyEffect(int extraDamagePercentage)
    {
        _extraDamagePercentage = extraDamagePercentage;
    }
    
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = GetRival(unit, roundFightController);
        int totalPenalty = 0;

        if (!rival.Attack.PenaltyNeutralized)
        {
            totalPenalty += rival.Attack.Penalty;
        }
        
        if (!rival.Defense.PenaltyNeutralized)
        {
            totalPenalty += rival.Defense.Penalty;
        }
        
        if (!rival.Speed.PenaltyNeutralized)
        {
            totalPenalty += rival.Speed.Penalty;
        }
        
        if (!rival.Resistance.PenaltyNeutralized)
        {
            totalPenalty += rival.Resistance.Penalty;
        }
        
        int extraDamage = Convert.ToInt32(Math.Floor((totalPenalty*-1) * _extraDamagePercentage / 100.0));
        unit.DamageEffectStat.ExtraDamageValue += extraDamage;
    }
}