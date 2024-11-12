using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.Skills.Effects.BonusEffects;

public class Max15HPBonusEffect : Effect
{
    public override void Apply(Unit unit)
    {
        unit.CurrentHP = unit.MaxHP + 15;
    }
}