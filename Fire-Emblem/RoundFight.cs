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
        CounterAttack();
        FollowUpAttack();
        // Restore attributes after the fight
        attackingUnit.RestoreSpecificAttributes(_attackingUnitAtributesBeforeFight);
        defendingUnit.RestoreSpecificAttributes(_defendingUnitAtributesBeforeFight);
        attackingUnit.ResetActiveSkills();
        defendingUnit.ResetActiveSkills();
        attackingUnit.RecentOpponent = defendingUnit;
        defendingUnit.RecentOpponent = attackingUnit;
    }
    private void CounterAttack()
    {
        if (AreBothUnitsAlive())
        {
            _attackController.FirstUnitAttack(defendingUnit, attackingUnit);
        }
        
    }

    private bool AreBothUnitsAlive()
    {
        return (attackingUnit.IsUnitAlive() && defendingUnit.IsUnitAlive());
    }

    private void FollowUpAttack()
    {
        var differenceSpeed = attackingUnit.Speed - defendingUnit.Speed;
        if (AreBothUnitsAlive())
        {
            switch (differenceSpeed)
            {
                case >= 5:
                    _attackController.Attack(attackingUnit, defendingUnit);
                    break;
                case <= -5:
                    _attackController.Attack(defendingUnit, attackingUnit);
                    break;
                default:
                    _view.WriteLine("Ninguna unidad puede hacer un follow up");
                    break;
            }
        
        }
    }

}