namespace Fire_Emblem;

public abstract class Stat
{

        public int Value { get; set; }
        public int Bonus { get; set; }
        public int Penalty { get; set; }
        public int FirstAttackBonus { get; set; }
        public int FirstAttackPenalty { get; set; }
        public int FollowUpAttackBonus { get; set; }
        public int FollowUpAttackPenalty { get; set; }
        public bool BonusNeutralized { get; set; }
        public bool PenaltyNeutralized { get; set; }

        private int _backupValue;

        public void ApplyEffects()
        {
            if (!BonusNeutralized) Value += Bonus;
            if (!PenaltyNeutralized) Value += Penalty;
        }

        public void ApplyFirstAttackEffects()
        {
            if (!BonusNeutralized) Value += FirstAttackBonus;
            if (!PenaltyNeutralized) Value += FirstAttackPenalty;
        }

        public void ApplyFollowUpAttackEffects()
        {
            if (!BonusNeutralized) Value += FollowUpAttackBonus;
            if (!PenaltyNeutralized) Value += FollowUpAttackPenalty;
        }

        public void ResetEffects()
        {
            Bonus = 0;
            Penalty = 0;
            FirstAttackBonus = 0;
            FirstAttackPenalty = 0;
            FollowUpAttackBonus = 0;
            FollowUpAttackPenalty = 0;
            BonusNeutralized = false;
            PenaltyNeutralized = false;
        }

        public void SaveValue()
        {
            _backupValue = Value;
        }

        public void RestoreValue()
        {
            Value = _backupValue;
        }
    
}
