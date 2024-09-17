using Fire_Emblem_View;

namespace Fire_Emblem.Skills.Effects;

public static class EffectLogger
{
    private static View _view;

    public static void Initialize(View view)
    {
        _view = view;
    }

    public static void ShowEffect(string message)
    {
        _view?.WriteLine(message);
    }
    public static void ShowUnitEffects(Unit unit)
    {
        // Show Bonus effects
        if (unit.ActiveSkillsEffects["AttackBonus"] > 0)
        {
            ShowEffect($"{unit.Name} obtiene Atk+{unit.ActiveSkillsEffects["AttackBonus"]}");
        }
        if (unit.ActiveSkillsEffects["SpeedBonus"] > 0)
        {
            ShowEffect($"{unit.Name} obtiene Spd+{unit.ActiveSkillsEffects["SpeedBonus"]}");
        }
        if (unit.ActiveSkillsEffects["DefenseBonus"] > 0)
        {
            ShowEffect($"{unit.Name} obtiene Def+{unit.ActiveSkillsEffects["DefenseBonus"]}");
        }
        if (unit.ActiveSkillsEffects["ResistanceBonus"] > 0)
        {
            ShowEffect($"{unit.Name} obtiene Res+{unit.ActiveSkillsEffects["ResistanceBonus"]}");
        }

        // Show FirstAttackBonus effects
        if (unit.ActiveSkillsEffects["FirstAttackAttackBonus"] > 0)
        {
            ShowEffect($"{unit.Name} obtiene Atk+{unit.ActiveSkillsEffects["FirstAttackAttackBonus"]} en su primer ataque");
        }
        if (unit.ActiveSkillsEffects["FirstAttackDefenseBonus"] > 0)
        {
            ShowEffect($"{unit.Name} obtiene Def+{unit.ActiveSkillsEffects["FirstAttackDefenseBonus"]} en su primer ataque");
        }
        if (unit.ActiveSkillsEffects["FirstAttackResistanceBonus"] > 0)
        {
            ShowEffect($"{unit.Name} obtiene Res+{unit.ActiveSkillsEffects["FirstAttackResistanceBonus"]} en su primer ataque");
        }

        // Show Penalty effects
        if (unit.ActiveSkillsEffects["AttackPenalty"] < 0)
        {
            ShowEffect($"{unit.Name} obtiene Atk{unit.ActiveSkillsEffects["AttackPenalty"]}");
        }
        if (unit.ActiveSkillsEffects["SpeedPenalty"] < 0)
        {
            ShowEffect($"{unit.Name} obtiene Spd{unit.ActiveSkillsEffects["SpeedPenalty"]}");
        }
        if (unit.ActiveSkillsEffects["DefensePenalty"] < 0)
        {
            ShowEffect($"{unit.Name} obtiene Def{unit.ActiveSkillsEffects["DefensePenalty"]}");
        }
        if (unit.ActiveSkillsEffects["ResistancePenalty"] < 0)
        {
            ShowEffect($"{unit.Name} obtiene Res{unit.ActiveSkillsEffects["ResistancePenalty"]}");
        }

        // Show FirstAttackPenalty effects
        if (unit.ActiveSkillsEffects["FirstAttackAttackPenalty"] < 0)
        {
            ShowEffect($"{unit.Name} obtiene Atk{unit.ActiveSkillsEffects["FirstAttackAttackPenalty"]} en su primer ataque");
        }
        if (unit.ActiveSkillsEffects["FirstAttackDefensePenalty"] < 0)
        {
            ShowEffect($"{unit.Name} obtiene Def{unit.ActiveSkillsEffects["FirstAttackDefensePenalty"]} en su primer ataque");
        }
        if (unit.ActiveSkillsEffects["FirstAttackResistancePenalty"] < 0)
        {
            ShowEffect($"{unit.Name} obtiene Res{unit.ActiveSkillsEffects["FirstAttackResistancePenalty"]} en su primer ataque");
        }
        
        // Show Bonus Neutralization effects
        if (unit.BonusesHaveBeenNeutralized)
        {
            ShowEffect($"Los bonus de Atk de {unit.Name} fueron neutralizados");
            ShowEffect($"Los bonus de Spd de {unit.Name} fueron neutralizados");
            ShowEffect($"Los bonus de Def de {unit.Name} fueron neutralizados");
            ShowEffect($"Los bonus de Res de {unit.Name} fueron neutralizados");
        }
        
        // Show Penalty Neutralization effects
        if (unit.PenaltyHasBeenNeutralized)
        {
            ShowEffect($"Los penalty de Atk de {unit.Name} fueron neutralizados");
            ShowEffect($"Los penalty de Spd de {unit.Name} fueron neutralizados");
            ShowEffect($"Los penalty de Def de {unit.Name} fueron neutralizados");
            ShowEffect($"Los penalty de Res de {unit.Name} fueron neutralizados");
        }
    }
}