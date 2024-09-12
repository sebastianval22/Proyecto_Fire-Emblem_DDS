using Fire_Emblem_View;
using Fire_Emblem.Skills;

namespace Fire_Emblem;

public class AttackController
{
    private View _view;
    private Damage _damage;
    private RoundFight _roundFight;


    public AttackController(View view, RoundFight roundFight)
    {
        _view = view;
        _damage = new Damage(view);
        _roundFight = roundFight;
    }
    
    private void ExecuteAttack(Unit attackingUnit, Unit defendingUnit, bool showAdvantage)
    {
        if (showAdvantage)
        {
            _damage.ShowAdvantageMessage(attackingUnit, defendingUnit);
            foreach (Skill attackingUnitSkill in attackingUnit.Skills.Reverse<Skill>())
            {
                if (attackingUnitSkill.SkillType != "Base Stats")
                {
                    attackingUnitSkill.ApplyEffects(attackingUnit, _roundFight);
                }
            }
            foreach (Skill defendingUnitSkill in defendingUnit.Skills.Reverse<Skill>())
            {
                if (defendingUnitSkill.SkillType != "Base Stats")
                {
                    defendingUnitSkill.ApplyEffects(defendingUnit, _roundFight);
                }
            }
            
        }
        int damageAttack = _damage.CalculateDamage(attackingUnit, defendingUnit);
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