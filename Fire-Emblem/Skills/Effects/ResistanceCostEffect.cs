namespace Fire_Emblem.Skills.Effects;

public class ResistanceCostEffect : Effect, ICostEffect

{
    public   int Cost { get; protected set; }
    public ResistanceCostEffect(int cost)
    {
        Cost = cost;
    }
    
    public override void Apply(Unit unit)
    {
        unit.ActiveSkillsEffects["ResistancePenalty"] -= Cost;
    }
}