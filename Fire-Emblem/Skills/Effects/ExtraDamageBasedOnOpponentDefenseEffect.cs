namespace Fire_Emblem.Skills.Effects;

public class ExtraDamageBasedOnOpponentDefenseEffect : Effect
{
    private int _percentage;
    public ExtraDamageBasedOnOpponentDefenseEffect(int percentage)
    {
        _percentage = percentage;
    }
    public override void Apply(Unit unit)
    {

    }

    public override void ApplySpecificEffect(Unit unit, RoundFight roundFight)
    {
        Unit rival = unit == roundFight.AttackingUnit ? roundFight.DefendingUnit : roundFight.AttackingUnit;
        var extraDamage = Convert.ToInt32(Math.Floor((rival.Defense.Value * _percentage) / 100.0));
        unit.ExtraDamageStat.Value += extraDamage;
    }
}