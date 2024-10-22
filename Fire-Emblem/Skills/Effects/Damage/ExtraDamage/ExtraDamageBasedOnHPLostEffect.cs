namespace Fire_Emblem.Skills.Effects.Damage.ExtraDamage;

public class ExtraDamageBasedOnHPLostEffect : Effect, IDamageEffect
{
    public override void Apply(Unit unit)
    {
        int extraDamage = Convert.ToInt32(Math.Floor((unit.MaxHP - unit.CurrentHP) / 2.0));
        unit.DamageEffectStat.ExtraDamageValue += extraDamage;
    }
}