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
        attackingUnit = chosenAttackingUnit;
        defendingUnit = chosenDefendingUnit;
        // Save attributes before the fight
        _attackingUnitAtributesBeforeFight = attackingUnit.ObtainAttributes();
        _defendingUnitAtributesBeforeFight = defendingUnit.ObtainAttributes();
        _attackController.InitialAttack(attackingUnit, defendingUnit);
        Counter();
        FollowUp();
        // Restore attributes after the fight
        attackingUnit.RestoreSpecificAttributes(_attackingUnitAtributesBeforeFight);
        defendingUnit.RestoreSpecificAttributes(_defendingUnitAtributesBeforeFight);
        attackingUnit.ResetActiveSkillsEffects();
        defendingUnit.ResetActiveSkillsEffects();
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
        var differenceSpeed = attackingUnit.Speed - defendingUnit.Speed;
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