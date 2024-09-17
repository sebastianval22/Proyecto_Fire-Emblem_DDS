using Fire_Emblem_View;
using Fire_Emblem.Skills;
using Fire_Emblem.Skills.Effects;

namespace Fire_Emblem;

public class AttackController
{
    private View _view;
    private Damage _damage;
    private RoundFight _roundFight;


    public AttackController(View view, RoundFight roundFight)
    {
        _view = view;
        _damage = new Damage(view);
        _roundFight = roundFight;
    }
    
    private void ExecuteAttack(Unit attackingUnit, Unit defendingUnit)
    {
        
        int damageAttack = _damage.CalculateDamage(attackingUnit, defendingUnit);
        _view.WriteLine($"{attackingUnit.Name} ataca a {defendingUnit.Name} con {damageAttack} de daño");
        defendingUnit.UpdateHPStatus(damageAttack);
    }

    public void FollowUpAttack(Unit attackingUnit, Unit defendingUnit)
    {
        attackingUnit.ApplyFollowUpAttackEffects();
        defendingUnit.ApplyFollowUpAttackEffects();
        ExecuteAttack(attackingUnit, defendingUnit);
    }

    public void InitialAttack(Unit attackingUnit, Unit defendingUnit)
    {
        _damage.ShowAdvantageMessage(attackingUnit, defendingUnit);
        InitializeSkills(attackingUnit, defendingUnit);
        ExecuteAttack(attackingUnit, defendingUnit);
        
    }

    private void InitializeSkills(Unit attackingUnit, Unit defendingUnit)
    {
        ApplySkills(attackingUnit);
        ApplySkills(defendingUnit);
        attackingUnit.ApplyEffects();
        defendingUnit.ApplyEffects();
        EffectLogger.ShowUnitEffects(attackingUnit);
        EffectLogger.ShowUnitEffects(defendingUnit);
    }

    public void CounterAttack(Unit attackingUnit, Unit defendingUnit)
    {
        ExecuteAttack(attackingUnit, defendingUnit);
        if (attackingUnit.HasFirstAttackSkill)

        {
            attackingUnit.RestoreBackupAttributes();
            attackingUnit.HasFirstAttackSkill = false;
        }
        if (defendingUnit.HasFirstAttackSkill)
        {
            defendingUnit.RestoreBackupAttributes();
            defendingUnit.HasFirstAttackSkill = false;
        }
        
    }
    private void ApplySkills( Unit attackingUnit)
    {
        foreach (Skill unitSkill in attackingUnit.Skills.Reverse<Skill>())
        {
             unitSkill.UpdateActiveSkillEffects(attackingUnit, _roundFight);
        }
    }
    
    
}
    
