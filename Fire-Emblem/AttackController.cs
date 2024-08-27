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
    
    private void ExecuteAttack(Unit attacking_unit, Unit defending_unit, bool showAdvantage)
    {
        int damage_attack = _damage.CalculateDamage(attacking_unit, defending_unit);
        if (showAdvantage)
        {
            _damage.ShowAdvantageMessage();
        }
        _view.WriteLine($"{attacking_unit.Name} ataca a {defending_unit.Name} con {damage_attack} de daño");
        defending_unit.UpdateHPStatus(damage_attack);
    }

    public void Attack(Unit attacking_unit, Unit defending_unit)
    {
        ExecuteAttack(attacking_unit, defending_unit, false);
    }

    public void FirstAttack(Unit attacking_unit, Unit defending_unit)
    {
        ExecuteAttack(attacking_unit, defending_unit, true);
    }

}