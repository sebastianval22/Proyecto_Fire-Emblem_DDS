using System.ComponentModel.Design;
using Fire_Emblem.Views;
using Fire_Emblem.Models;
using Fire_Emblem.Controllers.Strategies;

namespace Fire_Emblem.Controllers
{
    public class RoundFightController
    {

        private readonly AttackController _attackController;
        private readonly UnitController _unitController = new UnitController();
        private readonly StrategyApplySkillsPriority _strategyApplySkillsPriority;
        private Unit _attackingUnit;
        private Unit _defendingUnit;
        private Attributes _attackingUnitAttributesBeforeFight;
        private Attributes _defendingUnitAttributesBeforeFight;

        public Unit AttackingUnit
        {
            get => _attackingUnit;
            private set => _attackingUnit = value;
        }

        public Unit DefendingUnit
        {
            get => _defendingUnit;
            private set => _defendingUnit = value;
        }

    public RoundFightController()
        {
            _attackController = new AttackController(this);
            _strategyApplySkillsPriority = new StrategyApplySkillsPriority(this);
        }

        public void Fight(Unit chosenAttackingUnit, Unit chosenDefendingUnit)
        {
            InitializeFight(chosenAttackingUnit, chosenDefendingUnit);
            _attackController.ExecuteInitialAttack(AttackingUnit, DefendingUnit);
            Counter();
            FollowUp();
            FinalizeFight();
        }

        private void InitializeFight(Unit chosenAttackingUnit, Unit chosenDefendingUnit)
        {
            AttackingUnit = chosenAttackingUnit;
            DefendingUnit = chosenDefendingUnit;
            SaveAttributesBeforeFight();
        }
        
        private void SaveAttributesBeforeFight()
        {
            _attackingUnitAttributesBeforeFight = _unitController.ObtainAttributes(AttackingUnit);
            _defendingUnitAttributesBeforeFight = _unitController.ObtainAttributes(DefendingUnit);
        }
        
        private void Counter()
        {
            if (AreBothUnitsAlive() && DefendingUnit.CanCounterAttack)
            {
                _attackController.ExecuteCounterAttack(DefendingUnit, AttackingUnit);
            }
            
            if (!DefendingUnit.CanCounterAttack && DefendingUnit.HasDenialOfAttackDenialEffect)
            {
                _attackController.ExecuteCounterAttack(DefendingUnit, AttackingUnit);
            }
        }
        
        private void FollowUp()
        {
            var differenceSpeed = AttackingUnit.Speed.Value - DefendingUnit.Speed.Value;
            if (AreBothUnitsAlive())
            {
                ExecuteFollowUpBasedOnSpeed(differenceSpeed);
            }
        }
        
        private void ExecuteFollowUpBasedOnSpeed(int differenceSpeed)
        {
            if (differenceSpeed >= 5)
            {
                HandleFollowUpAttackForAttackerSpeedAdvantage(AttackingUnit, DefendingUnit);
            }
            else if (differenceSpeed <= -5)
            {
                HandleFollowUpAttackForDefenderSpeedAdvantage(DefendingUnit, AttackingUnit);
            }
            else
            {
                HandleFollowUpAttackForNoSpeedAdvantage(AttackingUnit, DefendingUnit);
            }
    
            ShowInabilityToFollowUp();
        }
       
        
        private void HandleFollowUpAttackForAttackerSpeedAdvantage(Unit fasterUnit, Unit slowerUnit)
        {
            if (CanFasterUnitFollowUp(fasterUnit))
            {
                _attackController.ExecuteFollowUpAttack(fasterUnit, slowerUnit);
                fasterUnit.HasFollowedUpInRound = true;
            }
            if (CanUnitGuaranteeFollowUpAttack(slowerUnit))
            {
                _attackController.ExecuteFollowUpAttack(slowerUnit, fasterUnit);
                slowerUnit.HasFollowedUpInRound = true;
            }
        }


        private void HandleFollowUpAttackForDefenderSpeedAdvantage(Unit fasterUnit, Unit slowerUnit)
        {
            if (CanUnitGuaranteeFollowUpAttack(slowerUnit))
            {
                _attackController.ExecuteFollowUpAttack(slowerUnit, fasterUnit);
                slowerUnit.HasFollowedUpInRound = true;
            }
            if (CanFasterUnitFollowUp(fasterUnit))
            {
                _attackController.ExecuteFollowUpAttack(fasterUnit, slowerUnit);
                fasterUnit.HasFollowedUpInRound = true;
            }
        }


        private void HandleFollowUpAttackForNoSpeedAdvantage(Unit attackingUnit, Unit defendingUnit)
        {
            if (CanUnitGuaranteeFollowUpAttack(attackingUnit))
            {
                _attackController.ExecuteFollowUpAttack(attackingUnit, defendingUnit);
                attackingUnit.HasFollowedUpInRound = true;
            }
            if (CanUnitGuaranteeFollowUpAttack(defendingUnit))
            {
                _attackController.ExecuteFollowUpAttack(defendingUnit, attackingUnit);
                defendingUnit.HasFollowedUpInRound = true;
            }
        }

        private bool CanFasterUnitFollowUp(Unit fasterUnit)
        {
            bool result = (_unitController.IsUnitAlive(fasterUnit)
                           && (fasterUnit.CanFollowUpAttack || fasterUnit.HasDenialOfAttackDenialEffect)
                           && (fasterUnit.NeutralizeFollowUpEffects == 0
                               || fasterUnit.IsImmuneToNeutralizeFollowUpEffects
                               || (fasterUnit.GuaranteedFollowUpEffects >= fasterUnit.NeutralizeFollowUpEffects
                                   && !fasterUnit.IsImmuneToGuaranteedFollowUpEffects)));
            return result;
        }
        
        private bool CanUnitGuaranteeFollowUpAttack(Unit unit)
        {
            bool result = (_unitController.IsUnitAlive(unit)
                           && unit.GuaranteedFollowUpEffects > 0
                           && !unit.IsImmuneToGuaranteedFollowUpEffects
                           && (unit.CanFollowUpAttack || unit.HasDenialOfAttackDenialEffect)
                           && (unit.NeutralizeFollowUpEffects == 0
                               || unit.IsImmuneToNeutralizeFollowUpEffects ||
                               (unit.GuaranteedFollowUpEffects > unit.NeutralizeFollowUpEffects
                                && !unit.IsImmuneToGuaranteedFollowUpEffects)));
            return result;
        }
        
        private void ShowInabilityToFollowUp()
        {
            if (!DefendingUnit.CanFollowUpAttack && !AttackingUnit.HasFollowedUpInRound && !DefendingUnit.HasDenialOfAttackDenialEffect)
            {
                RoundFightView.ShowAttackerInabilityToFollowUp(AttackingUnit.Name);
            }
            else if (!DefendingUnit.HasFollowedUpInRound && !AttackingUnit.HasFollowedUpInRound)
            {
                RoundFightView.ShowInabilityToFollowUp();
            }
        }
        
        private bool AreBothUnitsAlive()
        {
            return (_unitController.IsUnitAlive(AttackingUnit) && _unitController.IsUnitAlive(DefendingUnit));
        }

        private void FinalizeFight()
        {
            _strategyApplySkillsPriority.ApplyAfterCombatSkills(AttackingUnit, DefendingUnit);
            ApplyExtraHPAfterFightEffects();
            UpdateUnitAttributesAfterFight();
            RestoreAttributesAfterFight();
            ResetUnitsAfterFight();
            UpdateRecentOpponents();
        }
        
        private void ApplyExtraHPAfterFightEffects()
        {
            _unitController.ApplyExtraHPAfterCombatEffects(AttackingUnit);
            _unitController.ApplyExtraHPAfterCombatEffects(DefendingUnit);
        }

        private void UpdateUnitAttributesAfterFight()
        {
            AttackingUnit.HasHadFirstCombatStarting = true;
            DefendingUnit.HasHadFirstCombatNotStarting = true;
            AttackingUnit.BeforeRoundHP = AttackingUnit.CurrentHP;
            DefendingUnit.BeforeRoundHP = DefendingUnit.CurrentHP;
        }
        
        private void RestoreAttributesAfterFight()
        {
            _unitController.RestoreSpecificAttributes(_attackingUnitAttributesBeforeFight, AttackingUnit);
            _unitController.RestoreSpecificAttributes(_defendingUnitAttributesBeforeFight, DefendingUnit);
        }

        private void ResetUnitsAfterFight()
        {
            _unitController.ResetActiveSkillsEffects(AttackingUnit);
            _unitController.ResetActiveSkillsEffects(DefendingUnit);
        }

        private void UpdateRecentOpponents()
        {
            AttackingUnit.RecentOpponent = DefendingUnit;
            DefendingUnit.RecentOpponent = AttackingUnit;
        }
    }
}