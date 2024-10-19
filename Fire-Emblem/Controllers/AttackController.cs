using Fire_Emblem.Skills;
using Fire_Emblem.Strategies;
using Fire_Emblem.Views;

namespace Fire_Emblem.Controllers;

public class AttackController
{
    private DamageController _damageController = new DamageController();
    private RoundFightController _roundFightController;
    private StrategyApplySkillsPriority _strategyApplySkillsPriority;


    public AttackController( RoundFightController roundFightController)
    {
        _roundFightController = roundFightController;
        _strategyApplySkillsPriority = new StrategyApplySkillsPriority(roundFightController);
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
        _strategyApplySkillsPriority.ApplySkills(attackingUnit, defendingUnit);
        EffectView.ShowAllUnitEffects(attackingUnit, defendingUnit);
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
}
    
