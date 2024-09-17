namespace Fire_Emblem.Skills.Effects;

public class ResistanceBonusEffect : Effect, IBonusEffect
{
    public int Bonus { get; protected set; }

    public ResistanceBonusEffect(int bonus)
    {
        Bonus = bonus;
    }


    public override void Apply(Unit unit)
    {
        unit.ActiveSkillsEffects["ResistanceBonus"] += Bonus;
    }
}