using Fire_Emblem_View;

namespace Fire_Emblem
{
    public class RoundFight
    {
        private View _view;
        private AttackController _attackController;
        private Unit _attackingUnit;
        private Unit _defendingUnit;
        private Dictionary<string, int> _attackingUnitAttributesBeforeFight;
        private Dictionary<string, int> _defendingUnitAttributesBeforeFight;

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

        public RoundFight(View view)
        {
            _view = view;
            _attackController = new AttackController(view, this);
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
            _attackingUnitAttributesBeforeFight = AttackingUnit.ObtainAttributes();
            _defendingUnitAttributesBeforeFight = DefendingUnit.ObtainAttributes();
        }

        private void FinalizeFight()
        {
            RestoreAttributesAfterFight();
            ResetUnitsAfterFight();
            UpdateRecentOpponents();
        }

        private void RestoreAttributesAfterFight()
        {
            AttackingUnit.RestoreSpecificAttributes(_attackingUnitAttributesBeforeFight);
            DefendingUnit.RestoreSpecificAttributes(_defendingUnitAttributesBeforeFight);
        }

        private void ResetUnitsAfterFight()
        {
            AttackingUnit.ResetActiveSkillsEffects();
            DefendingUnit.ResetActiveSkillsEffects();
        }

        private void UpdateRecentOpponents()
        {
            AttackingUnit.RecentOpponent = DefendingUnit;
            DefendingUnit.RecentOpponent = AttackingUnit;
        }

        private void Counter()
        {
            if (AreBothUnitsAlive())
            {
                _attackController.ExecuteCounterAttack(DefendingUnit, AttackingUnit);
            }
        }

        private bool AreBothUnitsAlive()
        {
            return (AttackingUnit.IsUnitAlive() && DefendingUnit.IsUnitAlive());
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
            switch (differenceSpeed)
            {
                case >= 5:
                    _attackController.ExecuteFollowUpAttack(AttackingUnit, DefendingUnit);
                    break;
                case <= -5:
                    _attackController.ExecuteFollowUpAttack(DefendingUnit, AttackingUnit);
                    break;
                default:
                    _view.WriteLine("Ninguna unidad puede hacer un follow up");
                    break;
            }
        }
        
    }
}