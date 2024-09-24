using Fire_Emblem_View;

namespace Fire_Emblem;

public class RoundFight
{   
    private View _view;
    private AttackController _attackController;
    public Unit attackingUnit;
    public Unit defendingUnit;
    private Dictionary<string, int> _attackingUnitAtributesBeforeFight;
    private Dictionary<string, int> _defendingUnitAtributesBeforeFight;
    
    
    public RoundFight(View view)
    {
        _view = view;
        _attackController = new AttackController(view, this);
    }
    
    public void Fight(Unit chosenAttackingUnit, Unit chosenDefendingUnit)
    {
        InitializeFight(chosenAttackingUnit, chosenDefendingUnit);
        _attackController.InitialAttack(attackingUnit, defendingUnit);
        Counter();
        FollowUp();
        // Restore attributes after the fight
        FinalizeFight();
    }
    private void InitializeFight(Unit chosenAttackingUnit, Unit chosenDefendingUnit)
    {
        attackingUnit = chosenAttackingUnit;
        defendingUnit = chosenDefendingUnit;
        SaveAttributesBeforeFight();
    }
    private void SaveAttributesBeforeFight()
    {
        _attackingUnitAtributesBeforeFight = attackingUnit.ObtainAttributes();
        _defendingUnitAtributesBeforeFight = defendingUnit.ObtainAttributes();
    }
    private void FinalizeFight()
    {
        RestoreAttributesAfterFight();
        ResetUnitsAfterFight();
        UpdateRecentOpponents();
    }

    private void RestoreAttributesAfterFight()
    {
        attackingUnit.RestoreSpecificAttributes(_attackingUnitAtributesBeforeFight);
        defendingUnit.RestoreSpecificAttributes(_defendingUnitAtributesBeforeFight);
    }
    private void ResetUnitsAfterFight()
    {
        attackingUnit.ResetActiveSkillsEffects();
        defendingUnit.ResetActiveSkillsEffects();
    }

    private void UpdateRecentOpponents()
    {
        attackingUnit.RecentOpponent = defendingUnit;
        defendingUnit.RecentOpponent = attackingUnit;
    }

    private void Counter()
    {
        if (AreBothUnitsAlive())
        {
            _attackController.CounterAttack(defendingUnit, attackingUnit);
        }
        
    }

    private bool AreBothUnitsAlive()
    {
        return (attackingUnit.IsUnitAlive() && defendingUnit.IsUnitAlive());
    }

    private void FollowUp()
    {
        var differenceSpeed = attackingUnit.Speed.Value - defendingUnit.Speed.Value;
        if (AreBothUnitsAlive())
        {
            switch (differenceSpeed)
            {
                case >= 5:
                    _attackController.FollowUpAttack(attackingUnit, defendingUnit);
                    break;
                case <= -5:
                    _attackController.FollowUpAttack(defendingUnit, attackingUnit);
                    break;
                default:
                    _view.WriteLine("Ninguna unidad puede hacer un follow up");
                    break;
            }
        
        }
    }

}