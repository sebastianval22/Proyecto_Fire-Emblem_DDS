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
                ExecuteFollowUpBasedOnActiveEffects();
                ExecuteFollowUpBasedOnSpeed(differenceSpeed);
            }
        }
        
        private void ExecuteFollowUpBasedOnActiveEffects()
        {

        }
        
        private void ExecuteFollowUpBasedOnSpeed(int differenceSpeed)
        {
            
            if (differenceSpeed >= 5)
            {
                _attackController.ExecuteFollowUpAttack(AttackingUnit, DefendingUnit);
                if (DefendingUnit.GuaranteedFollowUpEffects > 0)
                {
                    _attackController.ExecuteFollowUpAttack(DefendingUnit, AttackingUnit);
                }
            }
            else if (differenceSpeed <= -5)
            {
                if (DefendingUnit.CanFollowUpAttack)
                {
                    _attackController.ExecuteFollowUpAttack(DefendingUnit, AttackingUnit);
                }
                else if (DefendingUnit.HasDenialOfAttackDenialEffect)
                {
                    _attackController.ExecuteFollowUpAttack(DefendingUnit, AttackingUnit);
                }
                else if (!DefendingUnit.CanFollowUpAttack)
                {
                    RoundFightView.ShowAttackerInabilityToFollowUp(AttackingUnit.Name);
                }
                if (AttackingUnit.GuaranteedFollowUpEffects > 0)
                {
                    _attackController.ExecuteFollowUpAttack(AttackingUnit, DefendingUnit);
                }
                
            }
            else
            {
                if (AttackingUnit.GuaranteedFollowUpEffects > 0)
                {
                    _attackController.ExecuteFollowUpAttack(AttackingUnit, DefendingUnit);
                }
                else if (DefendingUnit.GuaranteedFollowUpEffects > 0)
                {
                    _attackController.ExecuteFollowUpAttack(DefendingUnit, AttackingUnit);
                }
                else if (!DefendingUnit.CanFollowUpAttack)
                {
                    RoundFightView.ShowAttackerInabilityToFollowUp(AttackingUnit.Name);
                }
                else
                {
                    RoundFightView.ShowInabilityToFollowUp();
                }
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