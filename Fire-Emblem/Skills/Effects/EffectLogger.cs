using Fire_Emblem_View;

namespace Fire_Emblem.Skills.Effects
{
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
            ShowBonusEffects(unit);
            ShowFirstAttackBonusEffects(unit);
            ShowFollowUpAttackBonusEffects(unit);
            ShowPenaltyEffects(unit);
            ShowFirstAttackPenaltyEffects(unit);
            ShowFollowUpAttackPenaltyEffects(unit);
            ShowBonusNeutralizationEffects(unit);
            ShowPenaltyNeutralizationEffects(unit);
        }

        private static void ShowBonusEffects(Unit unit)
        {
            ShowEffectIfPositive(unit, "AttackBonus", "Atk");
            ShowEffectIfPositive(unit, "SpeedBonus", "Spd");
            ShowEffectIfPositive(unit, "DefenseBonus", "Def");
            ShowEffectIfPositive(unit, "ResistanceBonus", "Res");
        }

        private static void ShowFirstAttackBonusEffects(Unit unit)
        {
            ShowEffectIfPositive(unit, "FirstAttackAttackBonus", "Atk", " en su primer ataque");
            ShowEffectIfPositive(unit, "FirstAttackDefenseBonus", "Def", " en su primer ataque");
            ShowEffectIfPositive(unit, "FirstAttackResistanceBonus", "Res", " en su primer ataque");
        }

        private static void ShowFollowUpAttackBonusEffects(Unit unit)
        {
            ShowEffectIfPositive(unit, "FollowUpAttackAttackBonus", "Atk", " en su Follow-Up");
            ShowEffectIfPositive(unit, "FollowUpAttackDefenseBonus", "Def", " en su Follow-Up");
            ShowEffectIfPositive(unit, "FollowUpAttackResistanceBonus", "Res", " en su Follow-Up");
        }

        private static void ShowPenaltyEffects(Unit unit)
        {
            ShowEffectIfNegative(unit, "AttackPenalty", "Atk");
            ShowEffectIfNegative(unit, "SpeedPenalty", "Spd");
            ShowEffectIfNegative(unit, "DefensePenalty", "Def");
            ShowEffectIfNegative(unit, "ResistancePenalty", "Res");
        }

        private static void ShowFirstAttackPenaltyEffects(Unit unit)
        {
            ShowEffectIfNegative(unit, "FirstAttackAttackPenalty", "Atk", " en su primer ataque");
            ShowEffectIfNegative(unit, "FirstAttackDefensePenalty", "Def", " en su primer ataque");
            ShowEffectIfNegative(unit, "FirstAttackResistancePenalty", "Res", " en su primer ataque");
        }

        private static void ShowFollowUpAttackPenaltyEffects(Unit unit)
        {
            ShowEffectIfNegative(unit, "FollowUpAttackAttackPenalty", "Atk", " en su Follow-Up");
            ShowEffectIfNegative(unit, "FollowUpAttackDefensePenalty", "Def", " en su Follow-Up");
            ShowEffectIfNegative(unit, "FollowUpAttackResistancePenalty", "Res", " en su Follow-Up");
        }

        private static void ShowBonusNeutralizationEffects(Unit unit)
        {
            ShowNeutralizationEffect(unit.AttackBonusNeutralized, unit.Name, "bonus de Atk");
            ShowNeutralizationEffect(unit.SpeedBonusNeutralized, unit.Name, "bonus de Spd");
            ShowNeutralizationEffect(unit.DefenseBonusNeutralized, unit.Name, "bonus de Def");
            ShowNeutralizationEffect(unit.ResistanceBonusNeutralized, unit.Name, "bonus de Res");
        }

        private static void ShowPenaltyNeutralizationEffects(Unit unit)
        {
            ShowNeutralizationEffect(unit.AttackPenaltyNeutralized, unit.Name, "penalty de Atk");
            ShowNeutralizationEffect(unit.SpeedPenaltyNeutralized, unit.Name, "penalty de Spd");
            ShowNeutralizationEffect(unit.DefensePenaltyNeutralized, unit.Name, "penalty de Def");
            ShowNeutralizationEffect(unit.ResistancePenaltyNeutralized, unit.Name, "penalty de Res");
        }

        private static void ShowEffectIfPositive(Unit unit, string effectKey, string effectName, string suffix = "")
        {
            if (unit.ActiveSkillsEffects[effectKey] > 0)
            {
                ShowEffect($"{unit.Name} obtiene {effectName}+{unit.ActiveSkillsEffects[effectKey]}{suffix}");
            }
        }

        private static void ShowEffectIfNegative(Unit unit, string effectKey, string effectName, string suffix = "")
        {
            if (unit.ActiveSkillsEffects[effectKey] < 0)
            {
                ShowEffect($"{unit.Name} obtiene {effectName}{unit.ActiveSkillsEffects[effectKey]}{suffix}");
            }
        }

        private static void ShowNeutralizationEffect(bool isNeutralized, string unitName, string effectName)
        {
            if (isNeutralized)
            {
                ShowEffect($"Los {effectName} de {unitName} fueron neutralizados");
            }
        }
    }
}
