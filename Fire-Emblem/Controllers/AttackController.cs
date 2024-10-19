using Fire_Emblem.Skills;
using Fire_Emblem.Views;

namespace Fire_Emblem.Controllers;

public class AttackController
{
    private DamageController _damageController = new DamageController();
    private RoundFightController _roundFightController;


    public AttackController( RoundFightController roundFightController)
    {
        _roundFightController = roundFightController;
    }
    
    private void ExecuteAttack(Unit attackingUnit, Unit defendingUnit, int damageAttack)
    {
        AttackView.ShowAttack(attackingUnit, defendingUnit, damageAttack);
        defendingUnit.UpdateHPStatus(damageAttack);
    }

    public void ExecuteFollowUpAttack(Unit attackingUnit, Unit defendingUnit)
    {
        attackingUnit.ApplyFollowUpAttackEffects();
        defendingUnit.ApplyFollowUpAttackEffects();
        int damageAttack = _damageController.CalculateFollowUpDamage(attackingUnit, defendingUnit);
        ExecuteAttack(attackingUnit, defendingUnit, damageAttack);
    }

    public void ExecuteInitialAttack(Unit attackingUnit, Unit defendingUnit)
    {
        _damageController.ShowAdvantageMessage(attackingUnit, defendingUnit);
        InitializeSkills(attackingUnit, defendingUnit);
        int damageAttack = _damageController.CalculateDamageFirstAttack(attackingUnit, defendingUnit);
        ExecuteAttack(attackingUnit, defendingUnit, damageAttack);
        
    }

    private void InitializeSkills(Unit attackingUnit, Unit defendingUnit)
    {
        InitializeBaseStatsSkills(attackingUnit, defendingUnit);
        InitializeDamageSkills(attackingUnit, defendingUnit);
        EffectView.ShowAllUnitEffects(attackingUnit, defendingUnit);
    }
    
    private void InitializeDamageSkills(Unit attackingUnit, Unit defendingUnit)
    {
        ApplyDamageSkills(defendingUnit);
        ApplyDamageSkills(attackingUnit);
    }
    private void InitializeBaseStatsSkills(Unit attackingUnit, Unit defendingUnit)
    {
        ApplySkills(attackingUnit);
        ApplySkills(defendingUnit);
        attackingUnit.ApplyEffects();
        defendingUnit.ApplyEffects();

    }
    public void ExecuteCounterAttack(Unit attackingUnit, Unit defendingUnit)
    {
        int damageAttack = _damageController.CalculateDamageFirstAttack(attackingUnit, defendingUnit);

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
            unitSkill.UpdateActiveSkillEffects(attackingUnit, _roundFightController);
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
                unitSkill.UpdateActiveSkillEffects(attackingUnit, _roundFightController);
            }
        }

}
    
