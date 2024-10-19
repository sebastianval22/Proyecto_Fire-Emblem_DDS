using Fire_Emblem.Controllers;

namespace Fire_Emblem.Skills.Effects.Damage;

public class DamageDivineRecreationEffect : Effect
{
    public override void Apply(Unit unit)
    {
        
    }

    public override void ApplySpecificEffect(Unit unit, RoundFightController roundFightController)
    {
        Unit rival = unit == roundFightController.AttackingUnit ? roundFightController.DefendingUnit : roundFightController.AttackingUnit;
        if (unit == roundFightController.AttackingUnit)
        {
            Console.WriteLine($"La unidad {unit.Name} ha activado la habilidad Divine Recreation y ha reducido el daño de su primer ataque en un 30%");
            
            DamageController damageController = new DamageController();
            
            int normalDamage = damageController.CalculateDamageFirstAttackWithoutReduction(rival, unit);
            unit.DamagePercentageReductionStat.FirstAttackValue *= 0.7;
            Console.WriteLine($"El daño base de la unidad rival es de {normalDamage} y el daño de su primer ataque es de {damageController.CalculateDamageFirstAttack(rival, unit)}");
            int extraDamage = normalDamage - damageController.CalculateDamageFirstAttack(rival, unit);
            unit.ExtraDamageStat.FollowUpAttackValue += extraDamage;
            
        }
        else
        {
            Console.WriteLine($"La unidad {unit.Name} ha activado la habilidad Divine Recreation y ha reducido el daño de su primer ataque en un 30%");
            DamageController damageController = new DamageController();
            
            int normalDamage = damageController.CalculateDamageFirstAttackWithoutReduction(rival, unit);
            unit.DamagePercentageReductionStat.FirstAttackValue *= 0.7;
            Console.WriteLine($"El daño base de la unidad rival es de {normalDamage} y el daño de su primer ataque es de {damageController.CalculateDamageFirstAttack(rival, unit)}");
            
            int extraDamage = normalDamage - damageController.CalculateDamageFirstAttack(rival, unit);
            unit.ExtraDamageStat.FirstAttackValue += extraDamage;
        }
        
    }
}