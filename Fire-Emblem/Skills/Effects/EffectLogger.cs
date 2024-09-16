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
        if (unit.ActiveSkills["AttackBonus"] > 0)
        {
            ShowEffect($"{unit.Name} obtiene Atk+{unit.ActiveSkills["AttackBonus"]}");
        }
        if (unit.ActiveSkills["DefenseBonus"] > 0)
        {
            ShowEffect($"{unit.Name} obtiene Def+{unit.ActiveSkills["DefenseBonus"]}");
        }
        if (unit.ActiveSkills["SpeedBonus"] > 0)
        {
            ShowEffect($"{unit.Name} obtiene Spd+{unit.ActiveSkills["SpeedBonus"]}");
        }
        if (unit.ActiveSkills["ResistanceBonus"] > 0)
        {
            ShowEffect($"{unit.Name} obtiene Res+{unit.ActiveSkills["ResistanceBonus"]}");
        }

        // Show FirstAttackBonus effects
        if (unit.ActiveSkills["FirstAttackAttackBonus"] > 0)
        {
            ShowEffect($"{unit.Name} obtiene Atk+{unit.ActiveSkills["FirstAttackAttackBonus"]} en su primer ataque");
        }
        if (unit.ActiveSkills["FirstAttackDefenseBonus"] > 0)
        {
            ShowEffect($"{unit.Name} obtiene Def+{unit.ActiveSkills["FirstAttackDefenseBonus"]} en su primer ataque");
        }
        if (unit.ActiveSkills["FirstAttackResistanceBonus"] > 0)
        {
            ShowEffect($"{unit.Name} obtiene Res+{unit.ActiveSkills["FirstAttackResistanceBonus"]} en su primer ataque");
        }

        // Show Penalty effects
        if (unit.ActiveSkills["AttackPenalty"] < 0)
        {
            ShowEffect($"{unit.Name} obtiene Atk{unit.ActiveSkills["AttackPenalty"]}");
        }
        if (unit.ActiveSkills["DefensePenalty"] < 0)
        {
            ShowEffect($"{unit.Name} obtiene Def{unit.ActiveSkills["DefensePenalty"]}");
        }
        if (unit.ActiveSkills["SpeedPenalty"] < 0)
        {
            ShowEffect($"{unit.Name} obtiene Spd{unit.ActiveSkills["SpeedPenalty"]}");
        }
        if (unit.ActiveSkills["ResistancePenalty"] < 0)
        {
            ShowEffect($"{unit.Name} obtiene Res{unit.ActiveSkills["ResistancePenalty"]}");
        }

        // Show FirstAttackPenalty effects
        if (unit.ActiveSkills["FirstAttackAttackPenalty"] < 0)
        {
            ShowEffect($"{unit.Name} obtiene Atk{unit.ActiveSkills["FirstAttackAttackPenalty"]} en su primer ataque");
        }
        if (unit.ActiveSkills["FirstAttackDefensePenalty"] < 0)
        {
            ShowEffect($"{unit.Name} obtiene Def{unit.ActiveSkills["FirstAttackDefensePenalty"]} en su primer ataque");
        }
        if (unit.ActiveSkills["FirstAttackResistancePenalty"] < 0)
        {
            ShowEffect($"{unit.Name} obtiene Res{unit.ActiveSkills["FirstAttackResistancePenalty"]} en su primer ataque");
        }
    }
}