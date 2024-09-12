namespace Fire_Emblem.Skills.Effects;

public abstract class Effect
{
    public abstract void Apply(Unit unit);
    
    protected void ShowEffect(string message)
    {
        EffectLogger.ShowEffect(message);
    }
}