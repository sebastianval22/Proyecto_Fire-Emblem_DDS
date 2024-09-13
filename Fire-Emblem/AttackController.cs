using Fire_Emblem_View;
using Fire_Emblem.Skills;
using Fire_Emblem.Skills.Effects;

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
    
    private void ExecuteAttack(Unit attackingUnit, Unit defendingUnit)
    {
        
        int damageAttack = _damage.CalculateDamage(attackingUnit, defendingUnit);
        _view.WriteLine($"{attackingUnit.Name} ataca a {defendingUnit.Name} con {damageAttack} de daño");
        defendingUnit.UpdateHPStatus(damageAttack);
    }

    public void Attack(Unit attackingUnit, Unit defendingUnit)
    {
        ExecuteAttack(attackingUnit, defendingUnit);
    }

    public void InitialAttack(Unit attackingUnit, Unit defendingUnit)
    {
        InitializeSkills(attackingUnit, defendingUnit);
        FirstUnitAttack(attackingUnit, defendingUnit);
        
    }

    private void InitializeSkills(Unit attackingUnit, Unit defendingUnit)
    {
        _damage.ShowAdvantageMessage(attackingUnit, defendingUnit);
        attackingUnit.ApplySkills(_roundFight);
        defendingUnit.ApplySkills(_roundFight);
        ApplyFirstAttackBonus(attackingUnit);
        ApplyFirstAttackBonus(defendingUnit);
    }

    public void FirstUnitAttack(Unit attackingUnit, Unit defendingUnit)
    {
        ExecuteAttack(attackingUnit, defendingUnit);
        if (attackingUnit.HasFirstAttackSkill)

        {
            attackingUnit.RestoreBackupAttributes();
            attackingUnit.HasFirstAttackSkill = false;
        }
        
    }
    
    private void ApplyFirstAttackBonus(Unit attackingUnit)
    {
        foreach (var skill in attackingUnit.Skills)
        {
            if (skill.Conditions.All(condition => condition.IsMet(attackingUnit, _roundFight)));
            {
                foreach (var effect in skill.Effects)
                {
                    if (effect is FirstAttackBonusEffect firstAttackBonusEffect) 
                    {
                        firstAttackBonusEffect.Apply(attackingUnit);
                        attackingUnit.HasFirstAttackSkill = true;
                    }
                }
            }
        
        }
    }
}