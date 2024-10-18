namespace Fire_Emblem.Skills.Effects;

public class SelfNeutralizeDefenseBonusEffect : Effect, ISelfNeutralizeBonus
{
    public override void Apply(Unit unit)
    {
        unit.Defense.BonusNeutralized = true;
    }
}