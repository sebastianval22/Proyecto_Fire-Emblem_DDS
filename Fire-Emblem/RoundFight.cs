using Fire_Emblem_View;

namespace Fire_Emblem;

public class RoundFight
{   
    private View _view;
    private AttackController _attackController;
    private Unit _attackingUnit;
    private Unit _defendingUnit;
    
    public RoundFight(View view)
    {
        _view = view;
        _attackController = new AttackController(view, this);
    }
    
    public void Fight(Unit attackingUnit, Unit defendingUnit)
    {
        _attackingUnit = attackingUnit;
        _defendingUnit = defendingUnit;
        // Save attributes before the fight
        _attackingUnit.SaveAttributes();
        _defendingUnit.SaveAttributes();
        _attackController.FirstAttack(_attackingUnit, _defendingUnit);
        CounterAttack();
        FollowUpAttack();
        // Restore attributes after the fight
        _attackingUnit.RestoreAttributes();
        _defendingUnit.RestoreAttributes();
    }
    private void CounterAttack()
    {
        if (AreBothUnitsAlive())
        {
            _attackController.Attack(_defendingUnit, _attackingUnit);
        }
        
    }

    private bool AreBothUnitsAlive()
    {
        return (_attackingUnit.IsUnitAlive() && _defendingUnit.IsUnitAlive());
    }

    private void FollowUpAttack()
    {
        var differenceSpeed = _attackingUnit.Speed - _defendingUnit.Speed;
        if (AreBothUnitsAlive())
        {
            switch (differenceSpeed)
            {
                case >= 5:
                    _attackController.Attack(_attackingUnit, _defendingUnit);
                    break;
                case <= -5:
                    _attackController.Attack(_defendingUnit, _attackingUnit);
                    break;
                default:
                    _view.WriteLine("Ninguna unidad puede hacer un follow up");
                    break;
            }
        
        }
    }

}