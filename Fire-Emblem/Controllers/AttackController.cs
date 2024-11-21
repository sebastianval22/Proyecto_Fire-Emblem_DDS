using Fire_Emblem.Controllers.Strategies;
using Fire_Emblem.Views;
using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers;

public class AttackController
{
    private readonly DamageController _damageController = new DamageController();
    private readonly UnitController _unitController = new UnitController();
    private readonly StrategyApplySkillsPriority _strategyApplySkillsPriority;

    public AttackController( RoundFightController roundFightController)
    {
        _strategyApplySkillsPriority = new StrategyApplySkillsPriority(roundFightController);
    }
    
    private void ExecuteAttack(Unit attackingUnit, Unit defendingUnit, int damageAttack)
    {
        attackingUnit.HasAttackedInRound = true;
        AttackView.ShowAttack(attackingUnit, defendingUnit, damageAttack);
        _unitController.UpdateHPStatus(defendingUnit, damageAttack);
        _unitController.ApplyHPEffects(attackingUnit, damageAttack);
    }

    public void ExecuteFollowUpAttack(Unit attackingUnit, Unit defendingUnit)
    {
        _unitController.ApplyFollowUpAttackEffects(attackingUnit);
        _unitController.ApplyFollowUpAttackEffects(defendingUnit);
        _damageController.InitializeCombatants(attackingUnit, defendingUnit);
        int damageAttack = _damageController.CalculateFollowUpDamage(attackingUnit, defendingUnit);
        ExecuteAttack(attackingUnit, defendingUnit, damageAttack);
    }

    public void ExecuteInitialAttack(Unit attackingUnit, Unit defendingUnit)
    {
        InitializeCombat(attackingUnit, defendingUnit);
        ExecuteFirstAttack(attackingUnit, defendingUnit);
    }

    private void InitializeCombat(Unit attackingUnit, Unit defendingUnit)
    {
        _damageController.InitializeCombatants(attackingUnit, defendingUnit);
        double advantage = _damageController.GetAdvantageFactor();
        DamageView.ShowAdvantageMessage(attackingUnit, defendingUnit, advantage);
        InitializeSkills(attackingUnit, defendingUnit);
    }

    private void ExecuteFirstAttack(Unit attackingUnit, Unit defendingUnit)
    {
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
        _damageController.InitializeCombatants(attackingUnit, defendingUnit);
        int damageAttack = _damageController.CalculateDamageFirstAttack(attackingUnit, defendingUnit);

        ExecuteAttack(attackingUnit, defendingUnit, damageAttack);
        if (attackingUnit.HasFirstAttackSkill)

        {
            _unitController.RestoreBackupAttributes(attackingUnit);
            attackingUnit.HasFirstAttackSkill = false;
        }
        if (defendingUnit.HasFirstAttackSkill)
        {
            _unitController.RestoreBackupAttributes(defendingUnit);
            defendingUnit.HasFirstAttackSkill = false;
        }
        
    }
}
    
