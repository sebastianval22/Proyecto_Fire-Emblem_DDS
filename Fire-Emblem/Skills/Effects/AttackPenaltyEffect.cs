namespace Fire_Emblem.Skills.Effects;

public class AttackPenaltyEffect : Effect, IPenaltyEffect
{
    public int Penalty { get; protected set; }
    public AttackPenaltyEffect(int penalty)
    {
        Penalty = penalty;
    }


    public override void Apply(Unit rival)
    {
        rival. ActiveSkillsEffects["AttackPenalty"] -= Penalty;
    }
}