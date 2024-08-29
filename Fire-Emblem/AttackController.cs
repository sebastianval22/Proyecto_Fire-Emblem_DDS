using Fire_Emblem_View;

namespace Fire_Emblem;

public class AttackController
{
    private View _view;
    private Damage _damage;


    public AttackController(View view)
    {
        _view = view;
        _damage = new Damage(view);
    }
    
    private void ExecuteAttack(Unit attackingUnit, Unit defendingUnit, bool showAdvantage)
    {
        int damageAttack = _damage.CalculateDamage(attackingUnit, defendingUnit);
        if (showAdvantage)
        {
            _damage.ShowAdvantageMessage();
        }
        _view.WriteLine($"{attackingUnit.Name} ataca a {defendingUnit.Name} con {damageAttack} de daño");
        defendingUnit.UpdateHPStatus(damageAttack);
    }

    public void Attack(Unit attackingUnit, Unit defendingUnit)
    {
        ExecuteAttack(attackingUnit, defendingUnit, false);
    }

    public void FirstAttack(Unit attackingUnit, Unit defendingUnit)
    {
        ExecuteAttack(attackingUnit, defendingUnit, true);
    }

}