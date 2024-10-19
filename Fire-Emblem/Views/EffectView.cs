using Fire_Emblem.Skills.Effects;
using Fire_Emblem.Skills.Effects.NeutralizeEffects;

namespace Fire_Emblem.Views
{
    public  class EffectView
    {

        public static void ShowAllUnitEffects(Unit attackingUnit, Unit defendingUnit)

        {
            
            ShowUnitEffects(attackingUnit);
            ShowDamageEffects(attackingUnit);
            ShowUnitEffects(defendingUnit);
            ShowDamageEffects(defendingUnit);
        }

        private static void ShowUnitEffects(Unit unit)
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

        private static void ShowDamageEffects(Unit unit)
        {
            ShowExtraDamageEffects(unit);
            ShowFirstAttackExtraDamageEffects(unit);
            ShowFollowUpAttackExtraDamageEffects(unit);
            ShowDamagePercentageReductionEffects(unit);
            ShowFirstDamagePercentageReductionEffects(unit);
            ShowFollowUpDamagePercentageReductionEffects(unit);
            ShowDamageAbsoluteReductionEffects(unit);
        }
        private static void ShowExtraDamageEffects(Unit unit)
        {
            if (unit.ExtraDamageStat.Value > 0)
            {
                BaseView.ShowMessage($"{unit.Name} realizará +{unit.ExtraDamageStat.Value} daño extra en cada ataque");
            }
        }

        private static void ShowFirstAttackExtraDamageEffects(Unit unit)
        {
            if (unit.ExtraDamageStat.FirstAttackValue > 0)
            {
                BaseView.ShowMessage($"{unit.Name} realizará +{unit.ExtraDamageStat.FirstAttackValue} daño extra en su primer ataque");

            }
        }
        private static void ShowFollowUpAttackExtraDamageEffects(Unit unit)
        {
            if (unit.ExtraDamageStat.FollowUpAttackValue > 0)
            {
                BaseView.ShowMessage($"{unit.Name} realizará +{unit.ExtraDamageStat.FollowUpAttackValue} daño extra en su Follow-Up");

            }
        }
        private static void ShowDamagePercentageReductionEffects(Unit unit)
        {
            if (1 > unit.DamagePercentageReductionStat.Value)
            {
                int roundedReductionPercentage = CalculateReductionPercentage(unit.DamagePercentageReductionStat.Value);
                BaseView.ShowMessage($"{unit.Name} reducirá el daño de los ataques del rival en un {roundedReductionPercentage}%");
            }
        }

        private static void ShowFirstDamagePercentageReductionEffects(Unit unit)
        {
            if (1 > unit.DamagePercentageReductionStat.FirstAttackValue)
            {
                int roundedReductionPercentage = CalculateReductionPercentage(unit.DamagePercentageReductionStat.FirstAttackValue);
                BaseView.ShowMessage($"{unit.Name} reducirá el daño del primer ataque del rival en un {roundedReductionPercentage}%");
            }
        }
        private static void ShowFollowUpDamagePercentageReductionEffects(Unit unit)
        {
            if (1 > unit.DamagePercentageReductionStat.FollowUpAttackValue)
            {
                int roundedReductionPercentage = CalculateReductionPercentage(unit.DamagePercentageReductionStat.FollowUpAttackValue);
                BaseView.ShowMessage($"{unit.Name} reducirá el daño del Follow-Up del rival en un {roundedReductionPercentage}%");
            }
        }

        private static int CalculateReductionPercentage(double value)
        {
            double reductionPercentage = (1 - value) * 100;
            return (int)Math.Round(reductionPercentage);
        }
        private static void ShowDamageAbsoluteReductionEffects(Unit unit)
        {
            if (unit.DamageAbsoluteReductionStat.Value > 0)
            {
                BaseView.ShowMessage($"{unit.Name} recibirá -{unit.DamageAbsoluteReductionStat.Value} daño en cada ataque");
            }
        }

        private static void ShowBonusEffects(Unit unit)
        {
            ShowMessageIfPositive(new EffectDetail(unit.Attack.Bonus, unit.Name, "Atk"));
            ShowMessageIfPositive(new EffectDetail(unit.Speed.Bonus, unit.Name, "Spd"));
            ShowMessageIfPositive(new EffectDetail(unit.Defense.Bonus, unit.Name, "Def"));
            ShowMessageIfPositive(new EffectDetail(unit.Resistance.Bonus, unit.Name, "Res"));
        }

        private static void ShowFirstAttackBonusEffects(Unit unit)
        {
            ShowMessageIfPositive(new EffectDetail(unit.Attack.FirstAttackBonus, unit.Name, "Atk", " en su primer ataque"));
            ShowMessageIfPositive(new EffectDetail(unit.Defense.FirstAttackBonus, unit.Name, "Def", " en su primer ataque"));
            ShowMessageIfPositive(new EffectDetail(unit.Resistance.FirstAttackBonus, unit.Name, "Res", " en su primer ataque"));
        }

        private static void ShowFollowUpAttackBonusEffects(Unit unit)
        {
            ShowMessageIfPositive(new EffectDetail(unit.Attack.FollowUpAttackBonus, unit.Name, "Atk", " en su Follow-Up"));
            ShowMessageIfPositive(new EffectDetail(unit.Defense.FollowUpAttackBonus, unit.Name, "Def", " en su Follow-Up"));
            ShowMessageIfPositive(new EffectDetail(unit.Resistance.FollowUpAttackBonus, unit.Name, "Res", " en su Follow-Up"));
        }

        private static void ShowPenaltyEffects(Unit unit)
        {
            ShowMessageIfNegative(new EffectDetail(unit.Attack.Penalty, unit.Name, "Atk"));
            ShowMessageIfNegative(new EffectDetail(unit.Speed.Penalty, unit.Name, "Spd"));
            ShowMessageIfNegative(new EffectDetail(unit.Defense.Penalty, unit.Name, "Def"));
            ShowMessageIfNegative(new EffectDetail(unit.Resistance.Penalty, unit.Name, "Res"));
        }

        private static void ShowFirstAttackPenaltyEffects(Unit unit)
        {
            ShowMessageIfNegative(new EffectDetail(unit.Attack.FirstAttackPenalty, unit.Name, "Atk", " en su primer ataque"));
            ShowMessageIfNegative(new EffectDetail(unit.Defense.FirstAttackPenalty, unit.Name, "Def", " en su primer ataque"));
            ShowMessageIfNegative(new EffectDetail(unit.Resistance.FirstAttackPenalty, unit.Name, "Res", " en su primer ataque"));
        }

        private static void ShowFollowUpAttackPenaltyEffects(Unit unit)
        {
            ShowMessageIfNegative(new EffectDetail(unit.Attack.FollowUpAttackPenalty, unit.Name, "Atk", " en su Follow-Up"));
            ShowMessageIfNegative(new EffectDetail(unit.Defense.FollowUpAttackPenalty, unit.Name, "Def", " en su Follow-Up"));
            ShowMessageIfNegative(new EffectDetail(unit.Resistance.FollowUpAttackPenalty, unit.Name, "Res", " en su Follow-Up"));
        }

        private static void ShowBonusNeutralizationEffects(Unit unit)
        {
            ShowNeutralizationEffect(new NeutralizationDetail(unit.Attack.BonusNeutralized, unit.Name, "bonus de Atk"));
            ShowNeutralizationEffect(new NeutralizationDetail(unit.Speed.BonusNeutralized, unit.Name, "bonus de Spd"));
            ShowNeutralizationEffect(new NeutralizationDetail(unit.Defense.BonusNeutralized, unit.Name, "bonus de Def"));
            ShowNeutralizationEffect(new NeutralizationDetail(unit.Resistance.BonusNeutralized, unit.Name, "bonus de Res"));
        }

        private static void ShowPenaltyNeutralizationEffects(Unit unit)
        {
            ShowNeutralizationEffect(new NeutralizationDetail(unit.Attack.PenaltyNeutralized, unit.Name, "penalty de Atk"));
            ShowNeutralizationEffect(new NeutralizationDetail(unit.Speed.PenaltyNeutralized, unit.Name, "penalty de Spd"));
            ShowNeutralizationEffect(new NeutralizationDetail(unit.Defense.PenaltyNeutralized, unit.Name, "penalty de Def"));
            ShowNeutralizationEffect(new NeutralizationDetail(unit.Resistance.PenaltyNeutralized, unit.Name, "penalty de Res"));
        }

        private static void ShowMessageIfPositive(EffectDetail effectDetail)
        {
            if (effectDetail.EffectValue > 0)
            {
                BaseView.ShowMessage($"{effectDetail.UnitName} obtiene {effectDetail.EffectName}+{effectDetail.EffectValue}{effectDetail.Suffix}");
            }
        }

        private static void ShowMessageIfNegative(EffectDetail effectDetail)
        {
            if (effectDetail.EffectValue < 0)
            {
                BaseView.ShowMessage($"{effectDetail.UnitName} obtiene {effectDetail.EffectName}{effectDetail.EffectValue}{effectDetail.Suffix}");
            }
        }

        private static void ShowNeutralizationEffect(NeutralizationDetail neutralizationDetail)
        {
            if (neutralizationDetail.IsNeutralized)
            {
                BaseView.ShowMessage($"Los {neutralizationDetail.EffectName} de {neutralizationDetail.UnitName} fueron neutralizados");
            }
        }
    }
}