namespace Fire_Emblem.Skills.Conditions;

public class RivalInitiatesCombatCondition : Condition

    {
        public override bool IsMet(Unit unit, RoundFight roundFight)
        {
            return unit == roundFight.defendingUnit;
        }
    
}