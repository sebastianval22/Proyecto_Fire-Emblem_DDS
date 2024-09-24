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

        private static void ShowEffect(string message)
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
            ShowEffectIfPositive(unit.Attack.Bonus, unit.Name, "Atk");
            ShowEffectIfPositive(unit.Speed.Bonus, unit.Name, "Spd");
            ShowEffectIfPositive(unit.Defense.Bonus, unit.Name, "Def");
            ShowEffectIfPositive(unit.Resistance.Bonus, unit.Name, "Res");
        }

        private static void ShowFirstAttackBonusEffects(Unit unit)
        {
            ShowEffectIfPositive(unit.Attack.FirstAttackBonus, unit.Name, "Atk", " en su primer ataque");
            ShowEffectIfPositive(unit.Defense.FirstAttackBonus, unit.Name, "Def", " en su primer ataque");
            ShowEffectIfPositive(unit.Resistance.FirstAttackBonus, unit.Name, "Res", " en su primer ataque");
        }

        private static void ShowFollowUpAttackBonusEffects(Unit unit)
        {
            ShowEffectIfPositive(unit.Attack.FollowUpAttackBonus, unit.Name, "Atk", " en su Follow-Up");
            ShowEffectIfPositive(unit.Defense.FollowUpAttackBonus, unit.Name, "Def", " en su Follow-Up");
            ShowEffectIfPositive(unit.Resistance.FollowUpAttackBonus, unit.Name, "Res", " en su Follow-Up");
        }

        private static void ShowPenaltyEffects(Unit unit)
        {
            ShowEffectIfNegative(unit.Attack.Penalty, unit.Name, "Atk");
            ShowEffectIfNegative(unit.Speed.Penalty, unit.Name, "Spd");
            ShowEffectIfNegative(unit.Defense.Penalty, unit.Name, "Def");
            ShowEffectIfNegative(unit.Resistance.Penalty, unit.Name, "Res");
        }

        private static void ShowFirstAttackPenaltyEffects(Unit unit)
        {
            ShowEffectIfNegative(unit.Attack.FirstAttackPenalty, unit.Name, "Atk", " en su primer ataque");
            ShowEffectIfNegative(unit.Defense.FirstAttackPenalty, unit.Name, "Def", " en su primer ataque");
            ShowEffectIfNegative(unit.Resistance.FirstAttackPenalty, unit.Name, "Res", " en su primer ataque");
        }

        private static void ShowFollowUpAttackPenaltyEffects(Unit unit)
        {
            ShowEffectIfNegative(unit.Attack.FollowUpAttackPenalty, unit.Name, "Atk", " en su Follow-Up");
            ShowEffectIfNegative(unit.Defense.FollowUpAttackPenalty, unit.Name, "Def", " en su Follow-Up");
            ShowEffectIfNegative(unit.Resistance.FollowUpAttackPenalty, unit.Name, "Res", " en su Follow-Up");
        }

        private static void ShowBonusNeutralizationEffects(Unit unit)
        {
            ShowNeutralizationEffect(unit.Attack.BonusNeutralized, unit.Name, "bonus de Atk");
            ShowNeutralizationEffect(unit.Speed.BonusNeutralized, unit.Name, "bonus de Spd");
            ShowNeutralizationEffect(unit.Defense.BonusNeutralized, unit.Name, "bonus de Def");
            ShowNeutralizationEffect(unit.Resistance.BonusNeutralized, unit.Name, "bonus de Res");
        }

        private static void ShowPenaltyNeutralizationEffects(Unit unit)
        {
            ShowNeutralizationEffect(unit.Attack.PenaltyNeutralized, unit.Name, "penalty de Atk");
            ShowNeutralizationEffect(unit.Speed.PenaltyNeutralized, unit.Name, "penalty de Spd");
            ShowNeutralizationEffect(unit.Defense.PenaltyNeutralized, unit.Name, "penalty de Def");
            ShowNeutralizationEffect(unit.Resistance.PenaltyNeutralized, unit.Name, "penalty de Res");
        }

        private static void ShowEffectIfPositive(int effectValue, string unitName, string effectName, string suffix = "")
        {
            if (effectValue > 0)
            {
                ShowEffect($"{unitName} obtiene {effectName}+{effectValue}{suffix}");
            }
        }

        private static void ShowEffectIfNegative(int effectValue, string unitName, string effectName, string suffix = "")
        {
            if (effectValue < 0)
            {
                ShowEffect($"{unitName} obtiene {effectName}{effectValue}{suffix}");
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