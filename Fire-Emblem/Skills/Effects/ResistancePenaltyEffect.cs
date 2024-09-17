namespace Fire_Emblem.Skills.Effects;

public class ResistancePenaltyEffect : Effect, IPenaltyEffect
{
    public int Penalty { get; protected set; }
    public ResistancePenaltyEffect(int penalty)
    {
        Penalty = penalty;
    }

    public override void Apply(Unit rival)
    {
        rival.ActiveSkillsEffects["ResistancePenalty"] -= Penalty;
    }
}