namespace Fire_Emblem.Controllers.Skills
{
    using Fire_Emblem.Models;

    public static class SkillPriority
    {
        public static readonly NameList FirstPrioritySkillTypes = new NameList
        {
            "Bonus", "Penalty", "Hybrid", "Neutralization", "First Attack", "Heal", "Follow Up"
        };

        public static readonly NameList SecondPrioritySkillTypes = new NameList
        {
             "Denial"
        };

        public static readonly NameList FirstPrioritySkills = new NameList
        {
            "Divine Recreation Damage"
        };
        public static readonly NameList AfterCombatSkillTypes = new NameList
        {
            "After Combat"
        };
    }
}