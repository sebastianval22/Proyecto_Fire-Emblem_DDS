using Fire_Emblem_View;
using Fire_Emblem.Skills;
using Fire_Emblem.Skills.Effects;

namespace Fire_Emblem;

public class AttackController
{
    private View _view;
    private DamageCalculator _damageCalculator;
    private RoundFight _roundFight;


    public AttackController(View view, RoundFight roundFight)
    {
        _view = view;
        _damageCalculator = new DamageCalculator(view);
        _roundFight = roundFight;
    }
    
    private void ExecuteAttack(Unit attackingUnit, Unit defendingUnit, int damageAttack)
    {
        
        _view.WriteLine($"{attackingUnit.Name} ataca a {defendingUnit.Name} con {damageAttack} de daño");
        defendingUnit.UpdateHPStatus(damageAttack);
    }

    public void ExecuteFollowUpAttack(Unit attackingUnit, Unit defendingUnit)
    {
        attackingUnit.ApplyFollowUpAttackEffects();
        defendingUnit.ApplyFollowUpAttackEffects();
        int damageAttack = _damageCalculator.CalculateFollowUpDamage(attackingUnit, defendingUnit);
        ExecuteAttack(attackingUnit, defendingUnit, damageAttack);
    }

    public void ExecuteInitialAttack(Unit attackingUnit, Unit defendingUnit)
    {
        _damageCalculator.ShowAdvantageMessage(attackingUnit, defendingUnit);
        InitializeSkills(attackingUnit, defendingUnit);
        int damageAttack = _damageCalculator.CalculateDamageFirstAttack(attackingUnit, defendingUnit);
        ExecuteAttack(attackingUnit, defendingUnit, damageAttack);
        
    }

    private void InitializeSkills(Unit attackingUnit, Unit defendingUnit)
    {
        InitializeBaseStatsSkills(attackingUnit, defendingUnit);
        InitializeDamageSkills(attackingUnit, defendingUnit);
    }
    
    private void InitializeDamageSkills(Unit attackingUnit, Unit defendingUnit)
    {
        ApplyDamageSkills(attackingUnit);
        ApplyDamageSkills(defendingUnit);
        EffectLogger.ShowDamageEffects(attackingUnit);
        EffectLogger.ShowDamageEffects(defendingUnit);
    }
    private void InitializeBaseStatsSkills(Unit attackingUnit, Unit defendingUnit)
    {
        ApplySkills(attackingUnit);
        ApplySkills(defendingUnit);
        attackingUnit.ApplyEffects();
        defendingUnit.ApplyEffects();
        EffectLogger.ShowUnitEffects(attackingUnit);
        EffectLogger.ShowUnitEffects(defendingUnit);
    }
    public void ExecuteCounterAttack(Unit attackingUnit, Unit defendingUnit)
    {
        int damageAttack = _damageCalculator.CalculateDamageFirstAttack(attackingUnit, defendingUnit);

        ExecuteAttack(attackingUnit, defendingUnit, damageAttack);
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
             UpdateActiveSkillEffects(attackingUnit,unitSkill);
        }
    }
    
    private void UpdateActiveSkillEffects(Unit attackingUnit, Skill unitSkill)
    {
        if (unitSkill.SkillData.SkillType != "Damage")
        {
            unitSkill.UpdateActiveSkillEffects(attackingUnit, _roundFight);
        }
    }
    private void ApplyDamageSkills(Unit attackingUnit)
    {
        foreach (Skill unitSkill in attackingUnit.Skills.Reverse<Skill>())
        {
            UpdateDamageSkillEffects(attackingUnit, unitSkill);
        }
    
    }
        private void UpdateDamageSkillEffects(Unit attackingUnit, Skill unitSkill)
        {
            if (unitSkill.SkillData.SkillType == "Damage")
            {
                Console.WriteLine($"Activando skill {unitSkill.SkillData.Name}");
                unitSkill.UpdateActiveSkillEffects(attackingUnit, _roundFight);
            }
        }

}
    
