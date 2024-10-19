namespace Fire_Emblem.Skills.Effects.NeutralizeEffects;

public class SelfNeutralizeDefenseBonusEffect : Effect, ISelfNeutralizeBonus
{
    public override void Apply(Unit unit)
    {
        unit.Defense.BonusNeutralized = true;
    }
}