namespace Fire_Emblem.Models
{
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

        public void SaveValue()
        {
            _backupValue = Value;
        }

        public void RestoreValue()
        {
            Value = _backupValue;
        }
    }
}