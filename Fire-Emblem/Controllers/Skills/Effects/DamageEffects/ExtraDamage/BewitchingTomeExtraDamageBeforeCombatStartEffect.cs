using Fire_Emblem.Models;
using Fire_Emblem.Controllers.AdvantageWeapons;

namespace Fire_Emblem.Controllers.Skills.Effects.DamageEffects.ExtraDamage;

public class BewitchingTomeExtraDamageBeforeCombatStartEffect : Effect
{
    
    private Unit _rival;
    private int _extraDamagePercentageValue;
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {

        _rival = GetRival(unit, roundFightController);
        if (HasAdvantage(unit) || HasMoreSpeedThanRival(unit))
        {
            _extraDamagePercentageValue = 40;
        }
        else
        {
            _extraDamagePercentageValue = 20;
        }
        int damage = Convert.ToInt32(Math.Floor(_rival.Attack.Value * _extraDamagePercentageValue / 100.00));
        _rival.DamageEffectStat.ExtraDamageBeforeCombatValue += damage;
        _rival.CurrentHP = Math.Max(_rival.CurrentHP - damage, 1);
    }
    
    private bool HasAdvantage(Unit unit)
    {
        IWeaponAdvantage advantage = unit.Weapon switch
        {
            "Sword" => new SwordAdvantage(),
            "Lance" => new LanceAdvantage(),
            "Axe" => new AxeAdvantage(),
            _ => null
        };
        float advantageFactor = advantage?.DetermineAdvantageFactor(_rival) ?? 1;
        return advantageFactor > 1;
    }
    
    private bool HasMoreSpeedThanRival(Unit unit)
    {
        return unit.Speed.Value > _rival.Speed.Value;
    }
}