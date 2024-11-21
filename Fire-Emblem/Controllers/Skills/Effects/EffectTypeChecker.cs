using System;
using System.Collections.Generic;
using Fire_Emblem.Controllers.Skills.Effects.AttackDenialEffects;
using Fire_Emblem.Controllers.Skills.Effects.BonusEffects;
using Fire_Emblem.Controllers.Skills.Effects.CostEffects;
using Fire_Emblem.Controllers.Skills.Effects.DamageEffects;
using Fire_Emblem.Controllers.Skills.Effects.HealEffects;
using Fire_Emblem.Controllers.Skills.Effects.NeutralizeEffects;
using Fire_Emblem.Controllers.Skills.Effects.PenaltyEffects;
using Fire_Emblem.Controllers.Skills.Effects.FollowUpEffects;

namespace Fire_Emblem.Controllers.Skills.Effects
{
    public static class EffectTypeChecker
    {
        public static bool IsApplyToRivalEffect(Effect effect)
        {
            return (effect is IPenaltyEffect or INeutralizeBonus or IAttackDenialEffect);
        }
        
        public static bool IsApplyToUnitEffect(Effect effect)
        {
            return (effect is IBonusEffect or ICostEffect or INeutralizePenalty or ISelfNeutralizeBonus
                or IDenialOfAttackDenialEffect or IDamageEffect or IHealEffect or ISelfDamageEffect or IGuaranteeFollowUpEffect);
        }
    }
}