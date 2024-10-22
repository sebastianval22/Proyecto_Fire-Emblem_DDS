namespace Fire_Emblem.Controllers
{
    public class StatController
    {
        public void ApplyEffects(Stat stat)
        {
            if (!stat.BonusNeutralized) stat.Value += stat.Bonus;
            if (!stat.PenaltyNeutralized) stat.Value += stat.Penalty;
        }

        public void ApplyFirstAttackEffects(Stat stat)
        {
            if (!stat.BonusNeutralized) stat.Value += stat.FirstAttackBonus;
            if (!stat.PenaltyNeutralized) stat.Value += stat.FirstAttackPenalty;
        }

        public void ApplyFollowUpAttackEffects(Stat stat)
        {
            if (!stat.BonusNeutralized) stat.Value += stat.FollowUpAttackBonus;
            if (!stat.PenaltyNeutralized) stat.Value += stat.FollowUpAttackPenalty;
        }

        public void ResetEffects(Stat stat)
        {
            stat.Bonus = 0;
            stat.Penalty = 0;
            stat.FirstAttackBonus = 0;
            stat.FirstAttackPenalty = 0;
            stat.FollowUpAttackBonus = 0;
            stat.FollowUpAttackPenalty = 0;
            stat.BonusNeutralized = false;
            stat.PenaltyNeutralized = false;
        }

}
}